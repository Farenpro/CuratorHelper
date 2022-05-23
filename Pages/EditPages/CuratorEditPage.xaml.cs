using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for CuratorEditPage.xaml
    /// </summary>
    public partial class CuratorEditPage : Page
    {
        public EditInfoWindow Window;
        public string GroupName { get; set; }
        public string CuratorName { get; set; }
        public User Curator { get; set; }
        public CuratorEditPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            CuratorName = App.CurGroup.User.FIO;
            Window.DataContext = this;
            DataContext = this;
            CBoxCurators.ItemsSource = App.Database.Users.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }
        private void CuratorEdit()
        {
            App.CurGroup.CuratorUserID = Curator.ID;
            App.DBRefresh();
            App.Messages.ShowInfo(Properties.Resources.EditCongrats);
            Window.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Curator != null)
            {
                if (App.Database.Users.Where(p => p.ID == Curator.ID).SingleOrDefault().Groups.Count() > 2)
                {
                    if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.TooMuchGroups))
                        CuratorEdit();
                }
                else
                    CuratorEdit();
            }
        }
    }
}
