using CuratorHelper.Classes;
using CuratorHelper.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.ModulePages
{
    /// <summary>
    /// Interaction logic for DemoExamsPage.xaml
    /// </summary>
    public partial class DemoExamsPage : Page
    {
        public DemoExamsPage()
        {
            InitializeComponent();
            FillDGDemoExams();
        }

        private void BtnAddDemoExam_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(15);
            FillDGDemoExams();
        }

        private void BtnDeleteDemoExams_Click(object sender, RoutedEventArgs e)
        {
            if (DGDemoExams.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (DemoExam demoExam in DGDemoExams.SelectedItems)
                        App.Database.DemoExams.Remove(demoExam);
                    App.DBRefresh();
                    FillDGDemoExams();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.CourseWorksCountZero);
        }

        private void FillDGDemoExams() { DGDemoExams.ItemsSource = App.Database.DemoExams.ToList(); }
    }
}
