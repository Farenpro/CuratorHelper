using CuratorHelper.Classes;
using CuratorHelper.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.ModulePages
{
    /// <summary>
    /// Interaction logic for DisciplineObjectsPage.xaml
    /// </summary>
    public partial class DisciplineObjectsPage : Page
    {
        public DisciplineObjectsPage()
        {
            InitializeComponent();
            FillDGDisciplines();
        }

        private void BtnAddDiscipline_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(8);
            FillDGDisciplines();
        }

        private void BtnDeleteDisciplines_Click(object sender, RoutedEventArgs e)
        {
            if (DGDisciplines.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (Discipline discipline in DGDisciplines.SelectedItems)
                        App.Database.Disciplines.Remove(discipline);
                    App.DBRefresh();
                    FillDGDisciplines();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.DisciplinesCountZero);
        }

        private void FillDGDisciplines() { DGDisciplines.ItemsSource = App.Database.Disciplines.ToList(); }
    }
}
