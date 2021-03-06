using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for StudentMarksPage.xaml
    /// </summary>
    public partial class StudentMarksPage : Page
    {
        public Student Student { get; set; }
        public EditInfoWindow Window;
        public StudentMarksPage(Student student)
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            Student = student;
            LStudentName.Content = Student.FIO;
            FillDGMarks();
        }

        private void BtnAddMarks_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(Student, 6);
            FillDGMarks();
        }

        private void BtnDeleteMarks_Click(object sender, RoutedEventArgs e)
        {
            if (DGMarks.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (Credit credit in DGMarks.SelectedItems)
                        App.Database.Credits.Remove(credit);
                    App.DBRefresh();
                    FillDGMarks();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.MarksCountZero);
        }

        private void FillDGMarks() { DGMarks.ItemsSource = App.Database.Credits.Where(p => p.StudentID == Student.ID).ToList(); }
    }
}
