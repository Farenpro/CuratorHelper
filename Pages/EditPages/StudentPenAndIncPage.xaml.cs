using CuratorHelper.Classes;
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
    /// Interaction logic for StudentPenAndIncPage.xaml
    /// </summary>
    public partial class StudentPenAndIncPage : Page
    {
        public Student Student { get; set; }
        public EditInfoWindow Window;
        public StudentPenAndIncPage(Student student)
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            Student = student;
            LStudentName.Content = Student.FIO;
            FillDGPenAndIncs();
        }

        private void BtnAddPenAndInc_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(Student, 4);
            FillDGPenAndIncs();
        }

        private void BtnDeletePenAndIncs_Click(object sender, RoutedEventArgs e)
        {
            if (DGPenAndIncs.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (PenAndInc penAndInc in DGPenAndIncs.SelectedItems)
                        App.Database.PenAndIncs.Remove(penAndInc);
                    App.DBRefresh();
                    FillDGPenAndIncs();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.PenAndIncsCountZero);
        }

        private void FillDGPenAndIncs() { DGPenAndIncs.ItemsSource = App.Database.PenAndIncs.Where(p => p.StudentID == Student.ID).ToList(); ; }
    }
}
