
using CuratorHelper.Pages.EditPages;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CuratorHelper.Windows
{
    /// <summary>
    /// Interaction logic for EditInfoWindow.xaml
    /// </summary>
    public partial class EditInfoWindow : Window
    {
        public EditInfoWindow(byte type)
        {
            InitializeComponent();
            switch (type)
            {
                case 1:
                    MainFrame.Navigate(new AddTeacherPage());
                    break;
                case 2:
                    MainFrame.Navigate(new TeacherEditPage());
                    break;
                case 3:
                    MainFrame.Navigate(new AddGroupPage());
                    break;
                case 4:
                    MainFrame.Navigate(new AppointedTeachersEditPage());
                    break;
                case 5:
                    MainFrame.Navigate(new CuratorEditPage());
                    break;
                case 6:
                    MainFrame.Navigate(new AddStudentPage());
                    break;
            }
        }
    }
}
