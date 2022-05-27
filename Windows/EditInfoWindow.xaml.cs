using CuratorHelper.Models;
using CuratorHelper.Pages.EditPages;
using System.Windows;

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
                case 7:
                    MainFrame.Navigate(new CreateOrderPage());
                    break;
                case 8:
                    MainFrame.Navigate(new AddDisciplinePage());
                    break;
                case 9:
                    MainFrame.Navigate(new AddObjectPage());
                    break;
                case 10:
                    MainFrame.Navigate(new AddCourseWorkPage());
                    break;
                case 11:
                    MainFrame.Navigate(new AddGraduateWorkPage());
                    break;
                case 12:
                    MainFrame.Navigate(new AddQualificationPage());
                    break;
                case 13:
                    MainFrame.Navigate(new AddPracticsPage());
                    break;
                case 14:
                    MainFrame.Navigate(new AddPracticeNamePage());
                    break;
            }
        }

        public EditInfoWindow(Student student, byte type)
        {
            InitializeComponent();
            switch (type)
            {
                case 1:
                    MainFrame.Navigate(new CreateOrderPage(student));
                    break;
                case 2:
                    MainFrame.Navigate(new EditStudentInfoPage(student));
                    break;
            }
        }
    }
}
