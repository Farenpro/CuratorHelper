using CuratorHelper.Pages.ModulePages;
using CuratorHelper.Windows;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage() { Binding(); }

        public MainPage(bool a)
        {
            Binding();
            BtnTeachers.Visibility = BtnGroups.Visibility = BtnStudents.Visibility = BtnOrders.Visibility = BtnObjAndDisc.Visibility = BtnPractics.Visibility =
            BtnDemoExams.Visibility = Visibility.Collapsed;
            BtnMyGroups.Visibility = BtnMarks.Visibility = BtnOmissions.Visibility = Visibility.Visible;
        }
        private void Binding()
        {
            InitializeComponent();
            (App.Current.MainWindow as MainMenuWindow).DataContext = this;
            DataContext = App.CurUser;
        }

        private void CBoxProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBoxProfile.SelectedIndex == 1)
                (App.Current.MainWindow as MainMenuWindow).MainFrame.Navigate(new AuthorizationPage());
        }

        private void BtnTeachers_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new TeachersPage()); }

        private void BtnGroups_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new GroupsPage()); }

        private void BtnStudents_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new StudentPage()); }

        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnObjAndDisc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPractics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDemoExams_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMyGroups_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMarks_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOmissions_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
