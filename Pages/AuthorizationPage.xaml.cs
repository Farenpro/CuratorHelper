﻿using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            (App.Current.MainWindow as MainMenuWindow).DataContext = this;
        }

        private void TBDisplay_Checked(object sender, RoutedEventArgs e) { SubFunctions.TBShowHide(PBoxPasswordVisible, PBoxPassword, true); }
        private void TBDisplay_Unchecked(object sender, RoutedEventArgs e){ SubFunctions.TBShowHide(PBoxPasswordVisible, PBoxPassword, false); } 

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxLogin.Text != "" && (PBoxPassword.Password != "" | PBoxPasswordVisible.Text != ""))
            {
                if (App.Database.Users.Where(p => (p.Login == TBoxLogin.Text || p.Password == TBoxLogin.Text) && (p.Password == PBoxPassword.Password || p.Password == PBoxPasswordVisible.Text)).SingleOrDefault() is User user)
                {
                    App.CurUser = user;
                    App.CurUserDefaultPage();
                }
                else
                    App.Messages.ShowError(Properties.Resources.LogOrPassError);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
