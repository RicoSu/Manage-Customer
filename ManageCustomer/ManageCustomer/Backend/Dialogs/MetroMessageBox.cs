using ManageCustomer.Backend.Settings;

namespace ManageCustomer.Backend.Dialogs
{
    public static class MetroMessageBox
    {
        /// <summary>
        /// Show a Metro Message Box
        /// </summary>
        /// <param name="title">The title of the Message Box</param>
        /// <param name="message">The message to be displayed in the Message Box</param>
        public static void Show(string title, string message)
        {
            if (ManageCustomerSettings.HomeWindow != null)
            {
                ManageCustomerSettings.HomeWindow.ShowMask();
            }
            Backend.Dialogs.MessageBox msgBox = new Backend.Dialogs.MessageBox(title, message)
            {
                Owner = ManageCustomerSettings.HomeWindow,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
            };
            msgBox.ShowDialog();
            if (ManageCustomerSettings.HomeWindow != null)
            {
                ManageCustomerSettings.HomeWindow.HideMask();
            }
        }
        /// <summary>
        /// Show a Metro Message Box
        /// </summary>
        /// <param name="message">The message to be displayed in the Message Box</param>
        public static void Show(string message)
        {
            if (ManageCustomerSettings.HomeWindow != null)
            {
                ManageCustomerSettings.HomeWindow.ShowMask();
            }

            Backend.Dialogs.MessageBox msgBox = new Backend.Dialogs.MessageBox("Message Box", message)
            {
                Owner = ManageCustomerSettings.HomeWindow,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
            };
            msgBox.ShowDialog();

            if (ManageCustomerSettings.HomeWindow != null)
            {
                ManageCustomerSettings.HomeWindow.HideMask();
            }

        }

        /// <summary>
        /// The Results a Metro MessageBox can return
        /// </summary>
        public enum MessageBoxResults
        {
            Ok,
            Yes,
            No,
            Cancel
        }
        /// <summary>
        /// The diffrent Button Combinations that Metro Message Box's support
        /// </summary>
        public enum MessageBoxButtons
        {
            Ok,
            OkCancel,
            YesNo,
            YesNoCancel
        }
        /// <summary>
        /// Show a Metro Message Box
        /// </summary>
        /// <param name="title">The title of the Message Box</param>
        /// <param name="message">The message to be displayed in the Message Box</param>
        /// <param name="extendedmessage">The message to be displayed in the Extended Message Box</param>
        /// <param name="buttons">The buttons to show in the Message Box</param>
        /// <returns>The button the user clicked</returns>
        public static MessageBoxResults Show(string title, string message, string extendedmessage, MessageBoxButtons buttons)
        {
            if (ManageCustomerSettings.HomeWindow != null)
            {
                ManageCustomerSettings.HomeWindow.ShowMask();
            }
            MessageBoxOptions msgBox = new MessageBoxOptions(title, message, extendedmessage, buttons)
            {
                Owner = ManageCustomerSettings.HomeWindow,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner
            };
            msgBox.ShowDialog();
            if (ManageCustomerSettings.HomeWindow != null)
            {
                ManageCustomerSettings.HomeWindow.HideMask();
            }

            return TempStorage.MessageBoxButtonStorage;
        }
    }
}
