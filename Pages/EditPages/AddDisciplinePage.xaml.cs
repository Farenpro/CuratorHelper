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
    /// Interaction logic for AddDisciplinePage.xaml
    /// </summary>
    public partial class AddDisciplinePage : Page
    {
        public Models.Object Object { get; set; }
        public DisciplineIndex DisciplineIndex { get; set; }
        public EditInfoWindow Window;
        public AddDisciplinePage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxIndexes.ItemsSource = App.Database.DisciplineIndexes.ToList();
            FillCBObjects();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Object != null && DisciplineIndex != null)
            {
                if (App.Database.Disciplines.Where(p => p.ObjectID == Object.ID && p.DisciplineIndexID == DisciplineIndex.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.Disciplines.Count() > 0)
                        id = App.Database.Disciplines.Select(p => p.ID).Max() + 1;
                    Discipline discipline = new Discipline()
                    {
                        ID = id,
                        ObjectID = Object.ID,
                        DisciplineIndexID = DisciplineIndex.ID
                    };
                    App.Database.Disciplines.Add(discipline);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.DisciplineExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void FillCBObjects() { CBoxObjects.ItemsSource = App.Database.Objects.ToList(); }

        private void BtnObjectAdd_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(9);
            FillCBObjects();
        }
    }
}
