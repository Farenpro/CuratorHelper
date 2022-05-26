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

        private void BtnCancel_Click(object sender, RoutedEventArgs e){ Window.Close(); }

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
