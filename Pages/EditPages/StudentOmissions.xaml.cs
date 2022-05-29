using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for StudentOmissions.xaml
    /// </summary>
    public partial class StudentOmissions : Page
    {
        public Student Student { get; set; }
        public EditInfoWindow Window;
        public StudentOmissions(Student student)
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            Student = student;
            LStudentName.Content = Student.FIO;
            FillDGOmissions();
        }

        private void BtnAddOmission_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(Student, 8);
            FillDGOmissions();
        }

        private void BtnDeleteOmissions_Click(object sender, RoutedEventArgs e)
        {
            if (DGOmissions.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (Omission omission in DGOmissions.SelectedItems)
                        App.Database.Omissions.Remove(omission);
                    App.DBRefresh();
                    FillDGOmissions();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.PenAndIncsCountZero);
        }

        private void FillDGOmissions() { DGOmissions.ItemsSource = App.Database.Omissions.Where(p => p.StudentID == Student.ID).ToList(); }
    }
}
