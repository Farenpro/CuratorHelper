using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddDemoExamName.xaml
    /// </summary>
    public partial class AddDemoExamNamePage : Page
    {
        public string DemoExamName { get; set; }
        public EditInfoWindow Window;
        public AddDemoExamNamePage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().LastOrDefault();
            Window.DataContext = this;
            DataContext = this;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DemoExamName != "")
            {
                if (App.Database.DemoExamNames.Where(p => p.Name == DemoExamName).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.DemoExamNames.Count() > 0)
                        id = App.Database.DemoExamNames.Select(p => p.ID).Max() + 1;
                    DemoExamName demoExamName = new DemoExamName()
                    {
                        ID = id,
                        Name = DemoExamName
                    };
                    App.Database.DemoExamNames.Add(demoExamName);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.DemoExamNameExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }
    }
}
