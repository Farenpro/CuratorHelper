using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddStudentMarksPage.xaml
    /// </summary>
    public partial class AddStudentMarksPage : Page
    {
        public Student Student { get; set; }
        public Discipline Discipline { get; set; }
#nullable enable
        public byte? Term1Mark { get; set; }
#nullable enable
        public byte? Term2Mark { get; set; }
#nullable enable
        public byte? Term3Mark { get; set; }
#nullable enable
        public byte? Term4Mark { get; set; }
#nullable enable
        public byte? Term5Mark { get; set; }
#nullable enable
        public byte? Term6Mark { get; set; }
#nullable enable
        public byte? Term7Mark { get; set; }
#nullable enable
        public byte? Term8Mark { get; set; }
        public EditInfoWindow Window;
        public AddStudentMarksPage(Student student)
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().LastOrDefault();
            Window.DataContext = this;
            Student = student;
            DataContext = this;
            LStudentName.Content = Student.FIO;
            CBoxDisciplines.ItemsSource = App.Database.Disciplines.ToList();
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Discipline != null)
            {
                if (App.Database.Credits.Where(p => p.Student.ID == Student.ID && p.DisciplineID == Discipline.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.Credits.Count() > 0)
                        id = App.Database.Credits.Select(p => p.ID).Max() + 1;
                    Credit credit = new Credit()
                    {
                        ID = id,
                        DisciplineID = Discipline.ID,
                        StudentID = Student.ID,
                        Term1Mark = Term1Mark,
                        Term2Mark = Term2Mark,
                        Term3Mark = Term3Mark,
                        Term4Mark = Term4Mark,
                        Term5Mark = Term5Mark,
                        Term6Mark = Term6Mark,
                        Term7Mark = Term7Mark,
                        Term8Mark = Term8Mark,
                    };
                    App.Database.Credits.Add(credit);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                {
                    Credit credit = App.Database.Credits.Where(p => p.StudentID == Student.ID && p.Discipline.ID == Discipline.ID).SingleOrDefault();
                    credit.Term1Mark = Term1Mark;
                    credit.Term2Mark = Term2Mark;
                    credit.Term3Mark = Term3Mark;
                    credit.Term4Mark = Term4Mark;
                    credit.Term5Mark = Term5Mark;
                    credit.Term6Mark = Term6Mark;
                    credit.Term7Mark = Term7Mark;
                    credit.Term8Mark = Term8Mark;
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.EditCongrats);
                    Window.Close();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void CBoxDisciplines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Credit credit = App.Database.Credits.Where(p => p.StudentID == Student.ID && p.DisciplineID == Discipline.ID).SingleOrDefault();
            if (credit != null)
            {
                CBoxTerm1Mark.SelectedItem = credit.Term1Mark;
                CBoxTerm2Mark.SelectedItem = credit.Term2Mark;
                CBoxTerm3Mark.SelectedItem = credit.Term3Mark;
                CBoxTerm4Mark.SelectedItem = credit.Term4Mark;
                CBoxTerm5Mark.SelectedItem = credit.Term5Mark;
                CBoxTerm6Mark.SelectedItem = credit.Term6Mark;
                CBoxTerm7Mark.SelectedItem = credit.Term7Mark;
                CBoxTerm8Mark.SelectedItem = credit.Term8Mark;
                DataContext = this;
            }
        }
    }
}
