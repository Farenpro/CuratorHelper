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
    /// Interaction logic for AddObjectPage.xaml
    /// </summary>
    public partial class AddObjectPage : Page
    {
        public string ObjectName { get; set; }
        public EditInfoWindow Window;
        public AddObjectPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().LastOrDefault();
            Window.DataContext = this;
            DataContext = this;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ObjectName != "")
            {
                if (App.Database.Objects.Where(p => p.Name == ObjectName).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.Objects.Count() > 0)
                        id = App.Database.Objects.Select(p => p.ID).Max() + 1;
                    Models.Object @object = new Models.Object()
                    {
                        ID = id,
                        Name = ObjectName
                    };
                    App.Database.Objects.Add(@object);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.ObjectExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
