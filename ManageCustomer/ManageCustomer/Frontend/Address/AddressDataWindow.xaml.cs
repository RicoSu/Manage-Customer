using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ManageCustomer.Backend.DataAccessLayer;
using ManageCustomer.Backend.Dialogs;
using ManageCustomer.Backend.Models;
using ManageCustomer.Backend.Native;

namespace ManageCustomer.Frontend.Address
{
    /// <summary>
    /// Interaction logic for AddressDataWindow.xaml
    /// </summary>
    public partial class AddressDataWindow
    {
        public AddressDataWindow(bool newData, int someonesId, AddressOwner addressOwner, CustomerAddress customerAddress, bool showsaveButton)
        {
            InitializeComponent();
            DropShadow.DropShadowToWindow(this);
            _newData = newData;
            _someonesId = someonesId;
            _addressOwner = addressOwner;
            _customerAddress = customerAddress;
            SetShowSaveButton(showsaveButton);
            SetComboboxEntrys();
            MakeAllTextBoxesReadOnly(showsaveButton);

            DataContext = new Backend.Models.Address();
        }

        private readonly bool _newData;
        private readonly int _someonesId;
        private readonly AddressOwner _addressOwner;
        private readonly CustomerAddress _customerAddress;
        private int _errorsOnScreen;

        private void AddressDataWindow_OnContentRendered(object sender, EventArgs e)
        {
            if (_newData)
            {
                KundennummerTextBlock.Visibility = Visibility.Hidden;
                KundennummerTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                if (_addressOwner == AddressOwner.Customer)
                {
                    // ToDo: Was soll das?
                    //KundennummerTextBlock.Visibility = Visibility.Visible;
                    //KundennummerTextBlock.Text = "Name des Kunden:";
                    //KundennummerTextBox.Visibility = Visibility.Visible;

                    //KundennummerTextBox.Text = _customerAddress.Cusotmer.Name;
                    AdressartComboBox.Text = _customerAddress.Adressart.ToString();
                    StrasseTextBox.Text = _customerAddress.Strasse;
                    HausnummerTextBox.Text = _customerAddress.Hausnummer;
                    PostleitzahlTextBox.Text = _customerAddress.Postleitzahl;
                    OrtTextBox.Text = _customerAddress.Ort;
                    LandTextBox.Text = _customerAddress.Land;
                    BemerkungTextBox.Text = _customerAddress.Bemerkung;
                }
            }
        }

        private void SetShowSaveButton(bool showsavebutton)
        {
            SaveAddressDataButton.Visibility = showsavebutton ? Visibility.Visible : Visibility.Collapsed;
        }

        private void MakeAllTextBoxesReadOnly(bool enableTextBoxes)
        {
            if (enableTextBoxes) return;
            {
                AdressartComboBox.IsEnabled = false;
                StrasseTextBox.IsEnabled = false;
                HausnummerTextBox.IsEnabled = false;
                PostleitzahlTextBox.IsEnabled = false;
                OrtTextBox.IsEnabled = false;
                LandTextBox.IsEnabled = false;
                BemerkungTextBox.IsEnabled = false;
            }
        }

        private void MainHeaderThumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }

        private void SetComboboxEntrys()
        {
            foreach (var entry in Enum.GetValues(typeof(AddressType)))
            {
                AdressartComboBox.Items.Add(entry);
            }
        }

        private void SaveAddressDataButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_errorsOnScreen == 0)
            {
                if (_addressOwner == AddressOwner.Customer)
                {
                    var customerAddress = new CustomerAddress { Customer = Database.GetSingelCustomerData(_someonesId), Adressart = (AddressType)Enum.Parse(typeof(AddressType), AdressartComboBox.Text, true), Strasse = StrasseTextBox.Text, Hausnummer = HausnummerTextBox.Text, Postleitzahl = PostleitzahlTextBox.Text, Ort = OrtTextBox.Text, Land = LandTextBox.Text, Bemerkung = BemerkungTextBox.Text };

                    if (_newData)
                    {
                        Database.InsertCustomerAddressData(customerAddress);
                    }
                    else
                    {
                        customerAddress.Id = _customerAddress.Id;
                        Database.UpdateCustomerAddressData(customerAddress);
                    }
                }

                Close();
            }
            else
            {
                MetroMessageBox.Show("Eingabefehler!", "Alle Pflichtfelder müssen richtig ausgefüllt werden!");
            }
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region Error Validating
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                _errorsOnScreen++;
            }
            else
            {
                _errorsOnScreen--;
            }
        }

        #endregion

        private void AddressDataWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e != null && e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
