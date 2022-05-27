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

        private void BtnOrderForm_Click(object sender, RoutedEventArgs e)
        {
            EditInfoWindow editInfoWindow = new EditInfoWindow(DGStudents.SelectedItem as Student, 1);
            editInfoWindow.ShowDialog();
        }

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
