using CuratorHelper.Classes;
using CuratorHelper.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.ModulePages
{
    /// <summary>
    /// Interaction logic for CourseWorksPage.xaml
    /// </summary>
    public partial class CourseWorksPage : Page
    {
        public CourseWorksPage()
        {
            InitializeComponent();
            FillDGCourseWorks();
        }

        private void BtnAddCourseWork_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(10);
            FillDGCourseWorks();
        }

        private void BtnDeleteCourseWorks_Click(object sender, RoutedEventArgs e)
        {
            if (DGCourseWorks.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (CourseWork courseWork in DGCourseWorks.SelectedItems)
                        App.Database.CourseWorks.Remove(courseWork);
                    App.DBRefresh();
                    FillDGCourseWorks();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.CourseWorksCountZero);
        }

        private void FillDGCourseWorks() { DGCourseWorks.ItemsSource = App.Database.CourseWorks.ToList(); }
    }
}
