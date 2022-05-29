using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddCourseWorkPage.xaml
    /// </summary>
    public partial class AddCourseWorkPage : Page
    {
        public Student Student { get; set; }
        public Discipline Discipline { get; set; }
        public string Theme { get; set; }
        public byte Term { get; set; }
        public byte Mark { get; set; }
        public DateTime FinishDate { get; set; }
        public EditInfoWindow Window;
        public AddCourseWorkPage()
        {
            InitializeComponent();
            DPFinishDate.DisplayDateStart = DateTime.Now.AddYears(-5);
            DPFinishDate.DisplayDateEnd = DateTime.Now;
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxDisciplines.ItemsSource = App.Database.Disciplines.ToList();
            CBoxStudents.ItemsSource = App.Database.Students.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Student != null && Discipline != null && Theme != "" && Term != 0 && Mark != 0 && FinishDate != null)
            {
                if (App.Database.CourseWorks.Where(p => p.StudentID == Student.ID && p.DisciplineID == Discipline.ID && p.Term == Term).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.CourseWorks.Count() > 0)
                        id = App.Database.CourseWorks.Select(p => p.ID).Max() + 1;
                    CourseWork courseWork = new CourseWork()
                    {
                        ID = id,
                        Name = Theme,
                        Term = Term,
                        FinishDate = FinishDate,
                        DisciplineID = Discipline.ID,
                        Mark = Mark,
                        StudentID = Student.ID
                    };
                    App.Database.CourseWorks.Add(courseWork);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.CourseWorkExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
