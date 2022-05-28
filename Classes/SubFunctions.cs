using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        public static void ShowEditWindow(byte type)
        {
            EditInfoWindow editInfoWindow = new EditInfoWindow(type);
            editInfoWindow.ShowDialog();
        }
        public static void ShowEditWindow(Student student, byte type)
        {
            EditInfoWindow editInfoWindow = new EditInfoWindow(student, type);
            editInfoWindow.ShowDialog();
        }
    }
}
