using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ManageCustomer.Backend.DataAccessLayer;
using ManageCustomer.Backend.Dialogs;
using ManageCustomer.Backend.Native;

namespace ManageCustomer.Frontend.Customer
{
    /// <summary>
    /// Interaction logic for CustomerDataWindow.xaml
    /// </summary>
    public partial class CustomerDataWindow
    {
        public CustomerDataWindow(int customerId, bool showsaveButton)
        {
            InitializeComponent();
            DropShadow.DropShadowToWindow(this);
            _customerId = customerId;
            SetShowSaveButton(showsaveButton);
            MakeAllTextBoxesReadOnly(showsaveButton);

            KundennummerTextBox.Visibility = Visibility.Hidden;
            KundennummerTextBlock.Visibility = Visibility.Hidden;
            AnredeComboBox.Focus();

            DataContext = new Backend.Models.Customer();
        }

        private readonly int _customerId;
        private int _errorsOnScreen;

        private void CustomerDataWindow_OnContentRendered(object sender, EventArgs e)
        {
            if (_customerId == 0) return;
            KundennummerTextBox.Text = _customerId.ToString();
            KundennummerTextBox.Visibility = Visibility.Visible;
            KundennummerTextBlock.Visibility = Visibility.Visible;
            SetTextBoxesText(_customerId);
        }

        private void SetShowSaveButton(bool showsavebutton)
        {
            SaveCustomerDataButton.Visibility = showsavebutton ? Visibility.Visible : Visibility.Collapsed;
        }

        private void MakeAllTextBoxesReadOnly(bool enableTextBoxes)
        {
            if (enableTextBoxes) return;
            {
                AnredeComboBox.IsEnabled = false;
                VornameTextBox.IsEnabled = false;
                NameTextBox.IsEnabled = false;
                FirmaTextBox.IsEnabled = false;
                ZusatzTextBox.IsEnabled = false;
                MobilTextBox.IsEnabled = false;
                Telefon1TextBox.IsEnabled = false;
                Telefon2TextBox.IsEnabled = false;
                Mail1TextBox.IsEnabled = false;
                Mail2TextBox.IsEnabled = false;
                FaxTextBox.IsEnabled = false;
                BemerkungTextBox.IsEnabled = false;
            }
        }

        private void MainHeaderThumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }

        private void SaveCustomerDataButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_errorsOnScreen == 0)
            {
                var customer = new Backend.Models.Customer
                {
                    Anrede = AnredeComboBox.Text,
                    Vorname = VornameTextBox.Text,
                    Name = NameTextBox.Text,
                    Firma = FirmaTextBox.Text,
                    Zusatz = ZusatzTextBox.Text,
                    Mobil = MobilTextBox.Text,
                    Telefon = Telefon1TextBox.Text,
                    Mail = Mail1TextBox.Text,
                    Fax = FaxTextBox.Text,
                    Bemerkung = BemerkungTextBox.Text
                };

                if (_customerId == 0)
                {
                    Database.InsertCustomerData(customer);
                }
                else
                {
                    customer.Id = _customerId;
                    Database.UpdateCustomerData(customer);
                }

                Close();
            }
            else
            {
                MetroMessageBox.Show("Eingabefehler!", "Alle Pflichtfelder müssen richtig ausgefüllt werden!");
            }
        }

        private void SetTextBoxesText(int id)
        {
            var customerData = Database.GetSingelCustomerData(id);
            AnredeComboBox.Text = customerData.Anrede;
            VornameTextBox.Text = customerData.Vorname;
            NameTextBox.Text = customerData.Name;
            FirmaTextBox.Text = customerData.Firma;
            ZusatzTextBox.Text = customerData.Zusatz;
            MobilTextBox.Text = customerData.Mobil;
            Telefon1TextBox.Text = customerData.Telefon;
            Mail1TextBox.Text = customerData.Mail;
            FaxTextBox.Text = customerData.Fax;
            BemerkungTextBox.Text = customerData.Bemerkung;
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

        private void CustomerDataWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e != null && e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
