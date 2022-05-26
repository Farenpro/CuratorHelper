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
    /// Interaction logic for GraduateWorksPage.xaml
    /// </summary>
    public partial class GraduateWorksPage : Page
    {
        public GraduateWorksPage()
        {
            InitializeComponent();
            FillDGGraduateWorks();
        }

        private void BtnAddGraduateWork_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(11);
            FillDGGraduateWorks();
        }

        private void BtnDeleteGraduateWorks_Click(object sender, RoutedEventArgs e)
        {
            if (DGGraduateWorks.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (GraduateWork graduateWork in DGGraduateWorks.SelectedItems)
                        App.Database.GraduateWorks.Remove(graduateWork);
                    App.DBRefresh();
                    FillDGGraduateWorks();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.GraduateWorksCountZero);
        }

        private void FillDGGraduateWorks() { DGGraduateWorks.ItemsSource = App.Database.GraduateWorks.ToList(); }
    }
}
