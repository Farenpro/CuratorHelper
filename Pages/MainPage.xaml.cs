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
            BtnTeachers.Visibility = BtnGroups.Visibility = BtnStudents.Visibility = BtnOrders.Visibility = 
            BtnObjAndDisc.Visibility = BtnCourseWorks.Visibility = BtnGraduateWorks.Visibility = BtnPractics.Visibility = Visibility.Collapsed;
            BtnMyGroups.Visibility = Visibility.Visible;
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

        private void BtnOrders_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new OrdersPage()); }

        private void BtnObjAndDisc_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new DisciplineObjectsPage()); }

        private void BtnCourseWorks_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new CourseWorksPage()); }
        private void BtnGraduateWorks_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new GraduateWorksPage()); }
        private void BtnPractics_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new PracticsPage()); }
        private void BtnMyGroups_Click(object sender, RoutedEventArgs e) { MainPageFrame.Navigate(new MyGroupsPage()); }
    }
}
