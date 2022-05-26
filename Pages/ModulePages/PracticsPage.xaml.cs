using CuratorHelper.Classes;
using CuratorHelper.Models;
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
    /// Interaction logic for PracticsPage.xaml
    /// </summary>
    public partial class PracticsPage : Page
    {
        public PracticsPage()
        {
            InitializeComponent();
            FillDGPractics();
        }

        private void BtnAddPractice_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(13);
            FillDGPractics();
        }

        private void BtnDeletePractics_Click(object sender, RoutedEventArgs e)
        {
            if (DGPractics.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (Practice practice in DGPractics.SelectedItems)
                        App.Database.Practices.Remove(practice);
                    App.DBRefresh();
                    FillDGPractics();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.PracticsCountZero);
        }

        private void FillDGPractics() { DGPractics.ItemsSource = App.Database.Practices.ToList(); }
    }
}
