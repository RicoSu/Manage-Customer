using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ManageCustomer.Backend.Native;

namespace ManageCustomer.Backend.Dialogs
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : Window
    {
        public MessageBox(string title, string message)
        {
            InitializeComponent();
            DropShadow.DropShadowToWindow(this);

            TitleLabel.Content = title;
            MessageText.Text = message;
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
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

        private void MessageBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e != null && e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
