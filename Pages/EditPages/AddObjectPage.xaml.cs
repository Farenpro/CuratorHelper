using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
