using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Classes
{
    public static class SubFunctions
    {
        public static void TBShowHide(TextBox tbox, PasswordBox pbox, bool check)
        {
            if (check)
            {
                tbox.Text = pbox.Password;
                pbox.Clear();
                tbox.Visibility = Visibility.Visible;
                pbox.Visibility = Visibility.Collapsed;
            }
            else
            {
                pbox.Password = tbox.Text;
                tbox.Text = string.Empty;
                tbox.Visibility = Visibility.Collapsed;
                pbox.Visibility = Visibility.Visible;
            }
        }
    }
}
