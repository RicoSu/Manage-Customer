using System.Windows;
using System.Windows.Controls.Primitives;
using ManageCustomer.Backend.Native;
using ManageCustomer.Backend.Settings;

namespace ManageCustomer.Backend.Dialogs
{
    /// <summary>
    /// Interaction logic for MessageBoxOptions.xaml
    /// </summary>
    public partial class MessageBoxOptions
    {
        public MessageBoxOptions(string title, string message, string extendedmessage, MetroMessageBox.MessageBoxButtons buttons)
        {
            InitializeComponent();
            DropShadow.DropShadowToWindow(this);

            TitleLabel.Content = title;
            MessageText.Text = message;
            ExtendedMessageText.Text = extendedmessage;

            ButtonCancel.Visibility = Visibility.Collapsed;
            ButtonNo.Visibility = Visibility.Collapsed;
            ButtonYes.Visibility = Visibility.Collapsed;
            ButtonOkay.Visibility = Visibility.Collapsed;

            switch (buttons)
            {
                case MetroMessageBox.MessageBoxButtons.Ok:
                    ButtonOkay.Visibility = Visibility.Visible;

                    ButtonOkay.IsDefault = true;
                    ButtonOkay.IsCancel = true;
                    break;
                case MetroMessageBox.MessageBoxButtons.OkCancel:
                    ButtonOkay.Visibility = Visibility.Visible;
                    ButtonCancel.Visibility = Visibility.Visible;

                    ButtonOkay.IsDefault = true;
                    ButtonCancel.IsCancel = true;
                    break;
                case MetroMessageBox.MessageBoxButtons.YesNo:
                    ButtonYes.Visibility = Visibility.Visible;
                    ButtonNo.Visibility = Visibility.Visible;

                    ButtonYes.IsDefault = true;
                    break;
                case MetroMessageBox.MessageBoxButtons.YesNoCancel:
                    ButtonYes.Visibility = Visibility.Visible;
                    ButtonNo.Visibility = Visibility.Visible;
                    ButtonCancel.Visibility = Visibility.Visible;

                    ButtonYes.IsDefault = true;
                    ButtonCancel.IsCancel = true;
                    break;
            }
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            TempStorage.MessageBoxButtonStorage = MetroMessageBox.MessageBoxResults.Ok;
            Close();
        }
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            TempStorage.MessageBoxButtonStorage = MetroMessageBox.MessageBoxResults.Yes;
            Close();
        }
        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            TempStorage.MessageBoxButtonStorage = MetroMessageBox.MessageBoxResults.No;
            Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            TempStorage.MessageBoxButtonStorage = MetroMessageBox.MessageBoxResults.Cancel;
            Close();
        }

        private void MainHeaderThumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
