using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for TeacherEditPage.xaml
    /// </summary>
    public partial class TeacherEditPage : Page
    {
        public EditInfoWindow Window;
        public Models.Object Object { get; set; }
        public string TeacherName { get; set; }
        public TeacherEditPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            TeacherName = App.CurTeacher.FIO;
            Window.DataContext = this;
            DataContext = this;
            CBoxObject.ItemsSource = App.Database.Objects.ToList();
            ListTOTRefresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Object != null)
            {
                if (App.Database.TeacherObjectTaughts.Where(p => p.TeacherID == App.CurTeacher.ID && p.ObjectID == Object.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.TeacherObjectTaughts.Count() > 0)
                        id = App.Database.TeacherObjectTaughts.Select(p => p.ID).Max() + 1;
                    TeacherObjectTaught teacherObjectTaught = new TeacherObjectTaught()
                    {
                        ID = id,
                        TeacherID = App.CurTeacher.ID,
                        ObjectID = Object.ID
                    };
                    App.Database.TeacherObjectTaughts.Add(teacherObjectTaught);
                    App.DBRefresh();
                    ListTOTRefresh();
                }
                else
                    App.Messages.ShowError(Properties.Resources.TeacherAlreadyTaught);
            }
        }

        private void ListTOTRefresh() { DGTeacherObjects.ItemsSource = App.Database.TeacherObjectTaughts.Where(p => p.TeacherID == App.CurTeacher.ID).ToList(); }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DGTeacherObjects.SelectedItems.Count > 0)
            {
                foreach (TeacherObjectTaught teacherObjectTaught in DGTeacherObjects.SelectedItems)
                    App.Database.TeacherObjectTaughts.Remove(teacherObjectTaught);
                App.DBRefresh();
                ListTOTRefresh();
            }
            else
                App.Messages.ShowError(Properties.Resources.ObjectCountZero);
        }
    }
}
