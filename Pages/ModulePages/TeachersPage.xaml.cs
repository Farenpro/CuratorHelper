using CuratorHelper.Classes;
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

namespace CuratorHelper.Pages.ModulePages
{
    /// <summary>
    /// Interaction logic for TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        public TeachersPage()
        {
            InitializeComponent();
            FillDGTeachers();
        }

        private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(1);
            FillDGTeachers();
        }

        private void FillDGTeachers() { DGTeachers.ItemsSource = App.Database.Teachers.ToList(); }

        private void BtnEditTeachObjects_Click(object sender, RoutedEventArgs e)
        {
            App.CurTeacher = App.Database.Teachers.Where(p => p.ID.ToString() == DGTeachers.SelectedValue.ToString()).SingleOrDefault();
            SubFunctions.ShowEditWindow(2);
        }
    }
}
