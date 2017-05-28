using System;
using System.Windows;
using System.Windows.Controls;
using ManageCustomer.Backend.DataAccessLayer;
using ManageCustomer.Backend.Dialogs;
using ManageCustomer.Backend.Models;
using ManageCustomer.Backend.Settings;

namespace ManageCustomer.Frontend.Address
{
    /// <summary>
    /// Interaction logic for AddressUserControl.xaml
    /// </summary>
    public partial class AddressUserControl : UserControl
    {
        //someonesid steht dafür das man anhand der id alleine nicht sagen kann von welcher Tabelle dieser Wert kommt.
        //public AddressUserControl(int someonesid, Backend.Models.People.AddressOwner addressOwner)
        public AddressUserControl()
        {
            InitializeComponent();
            _someonesid = ManageAddresses.SomeonesId;
            _addressOwner = ManageAddresses.AddressOwner;
            SetDataGridItems();
            SelectSingleItem();
        }

        private static Backend.Models.Address _selectedAddress;
        private static int _someonesid;
        private static AddressOwner _addressOwner;

        private void SetDataGridItems()
        {
            if (_addressOwner == AddressOwner.Customer)
            {
                AddressDataGrid.ItemsSource = Database.GetAllCustomerAdressesById(_someonesid);
            }
        }

        private void NewAddressData_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = AddressDataGrid.SelectedIndex;
            ShowAddressDataWindow(0, true);

            if (selectedItem != -1)
            {
                AddressDataGrid.SelectedItem = AddressDataGrid.Items[selectedItem];
            }
        }

        private void ShowAddressDataWindow(int selectedId, bool showsaveButton)
        {
            ManageCustomerSettings.HomeWindow.ShowMask();
            if (selectedId == 0)
            {
                //selectedId == 0 --> newData in AddressDataWindwo
                var addressDataWindow = new Frontend.Address.AddressDataWindow(true, _someonesid, _addressOwner, null, showsaveButton)
                {
                    Owner = ManageCustomerSettings.HomeWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                addressDataWindow.ShowDialog();
            }
            else
            {
                if (_addressOwner == AddressOwner.Customer)
                {
                    var addressDataWindow = new Frontend.Address.AddressDataWindow(false, _someonesid, _addressOwner, Database.GetSingelCustomerAddressData(selectedId), showsaveButton)
                    {
                        Owner = ManageCustomerSettings.HomeWindow,
                        WindowStartupLocation = WindowStartupLocation.CenterOwner
                    };
                    addressDataWindow.ShowDialog();
                }
            }

            SetDataGridItems();
            SelectSingleItem();

            ManageCustomerSettings.HomeWindow.HideMask();
        }

        private void AddressDataView_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckIfOnlyOneAddressIsSelected() == false) return;
            {
                if (_addressOwner == AddressOwner.Customer)
                {
                    ShowAddressDataWindow(GetSelcetedCustomerAddress().Id, false);
                }

                SelectSingleItem();
            }
        }

        private void DeleteAddress_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckIfOnlyOneAddressIsSelected() == false) return;
            {
                var extendedtext = string.Empty;

                if (_addressOwner == AddressOwner.Customer)
                {
                    var cachedAddress = GetSelcetedCustomerAddress();

                    extendedtext = cachedAddress.Strasse + " " + cachedAddress.Hausnummer + Environment.NewLine +
                                   cachedAddress.Postleitzahl + " " + cachedAddress.Ort;
                }


                if (MetroMessageBox.Show("Achtung!", "Möchten Sie diese Adresse wirklich löschen?", extendedtext, MetroMessageBox.MessageBoxButtons.YesNo) == MetroMessageBox.MessageBoxResults.Yes)
                {
                    if (_addressOwner == AddressOwner.Customer)
                    {
                        Database.DeleteCustomerAddress(GetSelcetedCustomerAddress().Id);
                    }
                }

                SetDataGridItems();
            }
        }

        private bool CheckIfOnlyOneAddressIsSelected()
        {
            if (AddressDataGrid.SelectedItems.Count == 0)
            {
                MetroMessageBox.Show("Auswahl falsch", "Wählen Sie zuerst eine Adresse aus.");
            }
            else
            {
                if (AddressDataGrid.SelectedItems.Count > 1)
                {
                    MetroMessageBox.Show("Auswahl falsch", "Wählen Sie nur 1 Adress aus!");
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        // Call Only if only one Item is Selected!
        private CustomerAddress GetSelcetedCustomerAddress()
        {
            var customerAddress = AddressDataGrid.SelectedItem as CustomerAddress;
            return customerAddress;
        }

        // Call Only if only one Item is Selected!

        private void AddressDataEdit_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckIfOnlyOneAddressIsSelected() == false) return;
            {
                //Workaround to set previous selected Item after filtering!
                var selectedItem = AddressDataGrid.SelectedIndex;

                if (_addressOwner == AddressOwner.Customer)
                {
                    ShowAddressDataWindow(GetSelcetedCustomerAddress().Id, true);
                }

                AddressDataGrid.SelectedItem = AddressDataGrid.Items[selectedItem];
            }
        }

        private void AddressDataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString().ToUpper() == "ID")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.Column.Header.ToString().ToUpper() == "CUSTOMER")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.Column.Header.ToString().ToUpper() == "BEMERKUNG")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.Column.Header.ToString().ToUpper() == "ERROR")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void AddressDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetCustomerItemsCount();
            _selectedAddress = AddressDataGrid.SelectedItem as Backend.Models.Address;
        }

        private void SetCustomerItemsCount()
        {
            AddressItemsCount.Text = "Einträge: " + AddressDataGrid.Items.Count;
        }

        private void SelectSingleItem()
        {
            AddressDataGrid.SelectedItem = AddressDataGrid.Items.Count == 1 ? AddressDataGrid.Items[0] : null;
        }
    }
}
