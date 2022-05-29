using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AppointedTeachersEditPage.xaml
    /// </summary>
    public partial class AppointedTeachersEditPage : Page
    {
        public EditInfoWindow Window;
        public Teacher Teacher { get; set; }
        public string GroupName { get; set; }
        public AppointedTeachersEditPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            GroupName = App.CurGroup.Name;
            Window.DataContext = this;
            DataContext = this;
            CBoxTeachers.ItemsSource = App.Database.Teachers.ToList();
            DGTeachersRefresh();
        }

        private void BtnUnpin_Click(object sender, RoutedEventArgs e)
        {
            if (DGTeachers.SelectedItems.Count > 0)
            {
                foreach (AppointedTeacher appointedTeacher in DGTeachers.SelectedItems)
                    App.Database.AppointedTeachers.Remove(appointedTeacher);
                App.DBRefresh();
                DGTeachersRefresh();
            }
            else
                App.Messages.ShowError(Properties.Resources.TeachersCountZero);
        }

        private void BtnPin_Click(object sender, RoutedEventArgs e)
        {
            if (Teacher != null)
            {
                if (App.Database.AppointedTeachers.Where(p => p.TeacherID == Teacher.ID && p.GroupID == App.CurGroup.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.AppointedTeachers.Count() > 0)
                        id = App.Database.AppointedTeachers.Select(p => p.ID).Max() + 1;
                    AppointedTeacher appointedTeacher = new AppointedTeacher()
                    {
                        ID = id,
                        TeacherID = Teacher.ID,
                        GroupID = App.CurGroup.ID
                    };
                    App.Database.AppointedTeachers.Add(appointedTeacher);
                    App.DBRefresh();
                    DGTeachersRefresh();
                }
                else
                    App.Messages.ShowError(Properties.Resources.TeacherAlreadyPined);
            }
        }

        private void DGTeachersRefresh() { DGTeachers.ItemsSource = App.Database.AppointedTeachers.Where(p => p.GroupID == App.CurGroup.ID).ToList(); }
    }
}
