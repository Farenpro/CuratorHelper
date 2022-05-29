using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
#nullable enable
        public string? Middlename { get; set; }
        public Gender Gender { get; set; }
        public Specialization Specialization { get; set; }
        public Group Group { get; set; }
        public EditInfoWindow Window;
        public AddStudentPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxGender.ItemsSource = App.Database.Genders.ToList();
            CBoxSpecialization.ItemsSource = App.Database.Specializations.ToList();
            CBoxGroup.ItemsSource = App.Database.Groups.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Surname != "" && Firstname != "" && Gender != null && Specialization != null && Group != null)
            {
                if (App.Database.Students.Where(p => p.Surname == Surname && p.Firstname == Firstname && p.GroupID == Group.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.Students.Count() > 0)
                        id = App.Database.Students.Select(p => p.ID).Max() + 1;
                    if (Middlename == "")
                        Middlename = null;
                    Student student = new Student()
                    {
                        ID = id,
                        Firstname = Firstname,
                        Surname = Surname,
                        Middlename = Middlename,
                        GenderID = Gender.ID,
                        SpecializationCode = Specialization.Code,
                        GroupID = Group.ID
                    };
                    App.Database.Students.Add(student);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.StudentExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
