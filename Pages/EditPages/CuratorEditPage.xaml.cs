using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
