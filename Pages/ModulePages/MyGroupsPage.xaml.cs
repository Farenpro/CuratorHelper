using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.ModulePages
{
    /// <summary>
    /// Interaction logic for MyGroupsPage.xaml
    /// </summary>
    public partial class MyGroupsPage : Page
    {
        public MyGroupsPage()
        {
            InitializeComponent();
            var studentsInGroups = App.Database.Groups.Where(p => p.CuratorUserID == App.CurUser.ID).ToList();
            studentsInGroups.Insert(0, new Group { Name = "Все группы" });
            CBoxMyGroups.ItemsSource = studentsInGroups;
            CBoxMyGroups.SelectedIndex = 0;
            FillDGMyGroupsStudents();
        }

        private void BtnStudentInfoEdit_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(DGMyGroupsStudents.SelectedItem as Student, 2);
            FillDGMyGroupsStudents();
        }

        private void BtnStudentMarks_Click(object sender, RoutedEventArgs e) 
        { 
            SubFunctions.ShowEditWindow(DGMyGroupsStudents.SelectedItem as Student, 5);
            FillDGMyGroupsStudents();
        }

        private void BtnStudentOmissions_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(DGMyGroupsStudents.SelectedItem as Student, 7);
            FillDGMyGroupsStudents();
        }

        private void BtnStudentPenAndInc_Click(object sender, RoutedEventArgs e) 
        { 
            SubFunctions.ShowEditWindow(DGMyGroupsStudents.SelectedItem as Student, 3);
            FillDGMyGroupsStudents();
        }

        private void BtnStudentPerCard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillDGMyGroupsStudents()
        {
            if (CBoxMyGroups.SelectedIndex > 0)
            {
                Group group = CBoxMyGroups.SelectedItem as Group;
                DGMyGroupsStudents.ItemsSource = App.Database.Students.Where(p => p.Group.CuratorUserID == App.CurUser.ID && p.Group.ID == group.ID).ToList();
            }
            else
                DGMyGroupsStudents.ItemsSource = App.Database.Students.Where(p => p.Group.CuratorUserID == App.CurUser.ID).ToList();
        }

        private void CBoxMyGroups_SelectionChanged(object sender, SelectionChangedEventArgs e) { FillDGMyGroupsStudents(); }
    }
}
