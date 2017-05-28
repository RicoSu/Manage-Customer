using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using ManageCustomer.Backend.Models;
using ManageCustomer.Backend.Native;

namespace ManageCustomer.Frontend.Address
{
    /// <summary>
    /// Interaction logic for ManageAddresses.xaml
    /// </summary>
    public partial class ManageAddresses : Window
    {
        public ManageAddresses(int someonesid, AddressOwner addressOwner)
        {
            SomeonesId = someonesid;
            AddressOwner = addressOwner;
            InitializeComponent();
            DropShadow.DropShadowToWindow(this);
        }

        internal static int SomeonesId;
        internal static AddressOwner AddressOwner;

        private void MainHeaderThumb_OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = Left + e.HorizontalChange;
            Top = Top + e.VerticalChange;
        }

        private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ManageAddresses_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e != null && e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
