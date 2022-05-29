using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddQualificationPage.xaml
    /// </summary>
    public partial class AddQualificationPage : Page
    {
        public string QualificationName { get; set; }
        public EditInfoWindow Window;
        public AddQualificationPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().LastOrDefault();
            Window.DataContext = this;
            DataContext = this;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (QualificationName != "")
            {
                if (App.Database.Qualifications.Where(p => p.Name == QualificationName).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.Qualifications.Count() > 0)
                        id = App.Database.Qualifications.Select(p => p.ID).Max() + 1;
                    Qualification qualification = new Qualification()
                    {
                        ID = id,
                        Name = QualificationName
                    };
                    App.Database.Qualifications.Add(qualification);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.QualificationExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
