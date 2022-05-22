using CuratorHelper.Windows;
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
        }
        private void Binding()
        {
            InitializeComponent();
            (App.Current.MainWindow as MainMenuWindow).DataContext = this;
            //CBoxProfile.DataContext = App.CurUser;
        }
    }
}
