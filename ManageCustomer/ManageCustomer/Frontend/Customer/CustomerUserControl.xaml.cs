using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Threading;
using ManageCustomer.Backend.DataAccessLayer;
using ManageCustomer.Backend.Dialogs;
using ManageCustomer.Backend.Models;
using ManageCustomer.Backend.Settings;
using Application = System.Windows.Application;

namespace ManageCustomer.Frontend.Customer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CustomerUserControl : Window, INotifyPropertyChanged
    {
        private ICollectionView _dataGridCollection;
        private string _filterString;
        internal static Backend.Models.Customer SelectedCustomer;

        public CustomerUserControl()
        {
            InitializeComponent();
            
            Database.CreateDatabase();
            ManageCustomerSettings.HomeWindow = this;

            SetDataGridAndFilter();
            SetCustomerItemsCount();
            SelectSingleItem();

            IsVisibleChanged += LoginControl_IsVisibleChanged;
        }

        // Mit dieser Methode wird der Focus in die Textbox gesetzt
        void LoginControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                Dispatcher.BeginInvoke(
                    DispatcherPriority.ContextIdle,
                    new Action(delegate {
                        SearchTextBox.Focus();
                    }));
            }
        }

        private void SetDataGridAndFilter()
        {
            var newvalue = Database.CustomersTable;

            DataGridCollection = CollectionViewSource.GetDefaultView(newvalue);
            DataGridCollection.Filter = (Filter);
        }

        private void CustomerDataEdit_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckIfOnlyOneCustomerIsSelected() == false) return;
            {
                //Workaround to set previous selected Item after filtering!
                var selectedItem = CustomerDataGrid.SelectedIndex;

                ShowCustomerWindow(GetSelcetedCustomer().Id, true);

                SetDataGridAndFilter();

                CustomerDataGrid.SelectedItem = CustomerDataGrid.Items[selectedItem];
            }
        }

        private void ShowCustomerWindow(int customerId, bool showsaveButton)
        {
            ManageCustomerSettings.HomeWindow.ShowMask();
            var about = new CustomerDataWindow(customerId, showsaveButton)
            {
                Owner = ManageCustomerSettings.HomeWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            about.ShowDialog();
            ManageCustomerSettings.HomeWindow.HideMask();

            SearchTextBox.Focus();
        }

        private void NewCustomerData_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = CustomerDataGrid.SelectedIndex;
            ShowCustomerWindow(0, true);

            SetDataGridAndFilter();
            if (selectedItem != -1)
            {
                CustomerDataGrid.SelectedItem = CustomerDataGrid.Items[selectedItem];
            }
        }

        private void CustomerDataView_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckIfOnlyOneCustomerIsSelected() == false) return;
            {
                ShowCustomerWindow(GetSelcetedCustomer().Id, false);
            }
        }

        private void DeleteCustomer_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckIfOnlyOneCustomerIsSelected() == false) return;
            {
                var cachedCustomer = GetSelcetedCustomer();
                var extendedtext = "Kunde: " + cachedCustomer.Vorname + " " + cachedCustomer.Name;

                if (MetroMessageBox.Show("Achtung!", "Möchten Sie diesen Kunden wirklich löschen?", extendedtext, MetroMessageBox.MessageBoxButtons.YesNo) == MetroMessageBox.MessageBoxResults.Yes)
                {
                    Database.DeleteCustomer(GetSelcetedCustomer().Id);
                }

                SetDataGridAndFilter();
                SelectSingleItem();
            }
        }

        private bool CheckIfOnlyOneCustomerIsSelected()
        {
            if (CustomerDataGrid.SelectedItems.Count == 0)
            {
                MetroMessageBox.Show("Auswahl falsch", "Wählen Sie zuerst einen Kunden aus.");
                SearchTextBox.Focus();
            }
            else
            {
                if (CustomerDataGrid.SelectedItems.Count > 1)
                {
                    MetroMessageBox.Show("Auswahl falsch", "Wählen Sie nur 1 Kunde aus!");
                    SearchTextBox.Focus();
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        //// Call Only if only one Item is Selected!
        //private int GetSelcetedCustomerId()
        //{
        //    var customer = CustomerDataGrid.SelectedItem as Backend.Models.People.Customer;
        //    return customer?.Id ?? 0;
        //}

        // Call Only if only one Item is Selected!
        private Backend.Models.Customer GetSelcetedCustomer()
        {
            var customer = CustomerDataGrid.SelectedItem as Backend.Models.Customer;
            return customer;
        }

        private void ManageAddresses_OnClick(object sender, RoutedEventArgs e)
        {
            if (!CheckIfOnlyOneCustomerIsSelected()) return;
            {
                ManageCustomerSettings.HomeWindow.ShowMask();
                var about = new Address.ManageAddresses(GetSelcetedCustomer().Id, AddressOwner.Customer)
                {
                    Owner = ManageCustomerSettings.HomeWindow,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                about.ShowDialog();
                ManageCustomerSettings.HomeWindow.HideMask();
            }
        }

        #region CustomerDatagrid
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; NotifyPropertyChanged("DataGridCollection"); }
        }

        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                NotifyPropertyChanged("FilterString");
                FilterCollection();

                SetCustomerItemsCount();
                SelectSingleItem();
            }
        }

        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        private bool Filter(object obj)
        {
            var data = obj as Backend.Models.Customer;
            if (data == null) return false;
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return data.Id.ToString().ToUpper().Contains(_filterString.ToUpper()) || data.Anrede.ToUpper().Contains(_filterString.ToUpper()) || data.Vorname.ToUpper().Contains(_filterString.ToUpper()) || data.Name.ToUpper().Contains(_filterString.ToUpper()) || data.Vorname.ToUpper().Contains(_filterString.ToUpper()) || data.Zusatz.ToUpper().Contains(_filterString.ToUpper()) || data.Firma.ToUpper().Contains(_filterString.ToUpper()) || data.Telefon.ToUpper().Contains(_filterString.ToUpper()) || data.Mobil.ToUpper().Contains(_filterString.ToUpper()) || data.Fax.ToUpper().Contains(_filterString.ToUpper()) || data.Mail.ToUpper().Contains(_filterString.ToUpper()) || data.Bemerkung.ToUpper().Contains(_filterString.ToUpper());
                }
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void CustomerDataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column is DataGridCheckBoxColumn)
            {
                var checkBoxColumn = e.Column as DataGridCheckBoxColumn;
                var resource = Application.Current.FindResource("DataGridCheckBox");
                checkBoxColumn.ElementStyle = resource as Style;
            }

            if (e.Column.Header.ToString().ToUpper() == "ID")
            {
                e.Column.Header = "Kundennummer";
            }
            if (e.Column.Header.ToString().ToUpper() == "ZUSATZ")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString().ToUpper() == "FAX")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString().ToUpper() == "BEMERKUNG")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString().ToUpper() == "ERROR")
            {
                e.Cancel = true;
            }
            if (e.Column.Header.ToString().ToUpper() == "DELETED")
            {
                e.Cancel = true;
            }
        }

        public static DataGridView RemoveEmptyColumns(DataGridView grdView)
        {
            foreach (DataGridViewColumn clm in grdView.Columns)
            {
                bool notAvailable = true;

                foreach (DataGridViewRow row in grdView.Rows)
                {
                    if (!string.IsNullOrEmpty(row.Cells[clm.Index].Value.ToString()))
                    {
                        notAvailable = false;
                        break;
                    }
                }
                if (notAvailable)
                {
                    grdView.Columns[clm.Index].Visible = false;
                }
            }

            return grdView;
        }

        private void CustomerDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetCustomerItemsCount();
            SelectedCustomer = CustomerDataGrid.SelectedItem as Backend.Models.Customer;
        }

        private void SetCustomerItemsCount()
        {
            CustomerItemsCount.Text = "Einträge: " + CustomerDataGrid.Items.Count;
        }

        private void SelectSingleItem()
        {
            CustomerDataGrid.SelectedItem = CustomerDataGrid.Items.Count == 1 ? CustomerDataGrid.Items[0] : null;
        }

        #endregion

        #region Opacity Masking

        private int _opacityIndex;

        public void ShowMask()
        {
            _opacityIndex++;
            OpacityMaskRectangel.Visibility = Visibility.Visible;
        }

        public void HideMask()
        {
            _opacityIndex--;

            if (_opacityIndex == 0)
            {
                OpacityMaskRectangel.Visibility = Visibility.Collapsed;
            }
        }

        #endregion
    }
}
