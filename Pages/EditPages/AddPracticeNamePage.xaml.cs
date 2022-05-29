using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddPracticeNamePage.xaml
    /// </summary>
    public partial class AddPracticeNamePage : Page
    {
        public string PracticeName { get; set; }
        public PracticeIndex PracticeIndex { get; set; }
        public EditInfoWindow Window;
        public AddPracticeNamePage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().LastOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxPracticeIndex.ItemsSource = App.Database.PracticeIndexes.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (PracticeName != "")
            {
                if (App.Database.PracticeNames.Where(p => p.Name == PracticeName && p.PracticeIndex.ID == PracticeIndex.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.PracticeNames.Count() > 0)
                        id = App.Database.PracticeNames.Select(p => p.ID).Max() + 1;
                    PracticeName practiceName = new PracticeName()
                    {
                        ID = id,
                        Name = PracticeName,
                        PracticeIndexID = PracticeIndex.ID
                    };
                    App.Database.PracticeNames.Add(practiceName);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.PracticeNameExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
