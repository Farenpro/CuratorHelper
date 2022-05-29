using CuratorHelper.Classes;
using CuratorHelper.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.ModulePages
{
    /// <summary>
    /// Interaction logic for StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            FillDGStudents();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(6);
            FillDGStudents();
        }

        private void BtnOrderForm_Click(object sender, RoutedEventArgs e) { SubFunctions.ShowEditWindow(DGStudents.SelectedItem as Student, 1); }

        private void FillDGStudents() { DGStudents.ItemsSource = App.Database.Students.ToList(); }

        private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if (DGStudents.SelectedItem != null)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    try
                    {
                        App.Database.Students.Remove(DGStudents.SelectedItem as Student);
                        App.DBRefresh();
                        FillDGStudents();
                    }
                    catch (InvalidOperationException) { App.Messages.ShowError(Properties.Resources.HaveConnectionsError); }
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.StudentCountZero);
        }
    }
}
