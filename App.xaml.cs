using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Pages;
using CuratorHelper.Windows;
using System.Windows;
using res = CuratorHelper.Properties;
using System.Linq;


namespace CuratorHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MessagesClass Messages { get; } = new MessagesClass();
        public static CuratorHelperEntities Database { get; set; } = new CuratorHelperEntities();
        public static User CurUser { get; set; } = new User();
        public static Teacher CurTeacher { get; set; } = new Teacher();
        public static Group CurGroup { get; set; } = new Group();

        public App()
        {
            try
            {
                Database.Database.Connection.Open();
                Database.Database.Connection.Close();
            }
            catch
            {
                App.Messages.ShowError(res.Resources.DatabaseError);
                App.Current.Shutdown();
            }
        }

        public static void CurUserDefaultPage()
        {
            App.CurUser.Role = App.Database.Users.Where(p => p.ID == App.CurUser.ID).SingleOrDefault().Role;
            switch (CurUser.RoleID)
            {
                case 1:
                    if (MessageBoxResult.OK == Messages.ShowQuestion("Войти как секретарь?"))
                        (Current.MainWindow as MainMenuWindow).MainFrame.Navigate(new MainPage());
                    else
                    {
                        App.CurUser.Role = App.Database.Roles.Where(p => p.ID == 2).SingleOrDefault();
                        (Current.MainWindow as MainMenuWindow).MainFrame.Navigate(new MainPage(false));
                    }
                    break;
                case 2:
                    (Current.MainWindow as MainMenuWindow).MainFrame.Navigate(new MainPage(false));
                    break;
            }
        }

        public static void DBRefresh()
        {
            App.Database.SaveChanges();
            App.Database = new CuratorHelperEntities();
        }
    }
}
