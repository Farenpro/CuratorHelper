using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for EditStudentInfoPage.xaml
    /// </summary>
    public partial class EditStudentInfoPage : Page
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
#nullable enable
        public string? Middlename { get; set; }
        public Gender Gender { get; set; }
#nullable enable
        public DateTime? Birthdate { get; set; }
#nullable enable
        public string? BirthPlace { get; set; }
#nullable enable
        public byte? CompletedClasses { get; set; }
#nullable enable
        public DateTime? SchoolGraduate { get; set; }
#nullable enable
        public string? SchoolName { get; set; }
#nullable enable
        public string? GuardianAddress { get; set; }
#nullable enable
        public string? AimedAt { get; set; }
#nullable enable
        public string? CommunityService { get; set; }

        public EditInfoWindow Window;
        public Student Student { get; set; }
        public EditStudentInfoPage(Student student)
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Student = student;
            Window.DataContext = this;
            Surname = Student.Surname;
            Firstname = Student.Firstname;
            Middlename = Student.Middlename;
            BirthPlace = Student.BirthPlace;
            SchoolName = Student.SchoolName;
            GuardianAddress = Student.GuardianAddress;
            AimedAt = Student.AimedAt;
            CommunityService = Student.CommunityService;
            DataContext = this;
            CBoxGender.ItemsSource = App.Database.Genders.ToList();
            CBoxGender.SelectedItem = Student.Gender;
            DPSchoolGraduate.DisplayDateStart = DateTime.Now.AddYears(-99);
            DPSchoolGraduate.DisplayDateEnd = DateTime.Now.AddYears(-14);
            DPBirthdate.DisplayDateStart = DateTime.Now.AddYears(-99);
            DPBirthdate.DisplayDateEnd = DateTime.Now.AddYears(-14);
            DPBirthdate.SelectedDate = Student.Birthdate;
            CBoxCompletedClasses.SelectedItem = Student.CompletedClassesID;
            DPSchoolGraduate.SelectedDate = Student.SchoolGraduateDate;
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Surname != "" && Firstname != "" && Gender != null)
            {
                Student.Surname = Surname;
                Student.Firstname = Firstname;
                Student.Middlename = Middlename;
                Student.Birthdate = Birthdate;
                Student.GenderID = Gender.ID;
                Student.BirthPlace = BirthPlace;
                Student.CompletedClassesID = CompletedClasses;
                Student.SchoolGraduateDate = SchoolGraduate;
                Student.SchoolName = SchoolName;
                Student.GuardianAddress = GuardianAddress;
                Student.AimedAt = AimedAt;
                Student.CommunityService = CommunityService;
                App.DBRefresh();
                App.Messages.ShowInfo(Properties.Resources.EditCongrats);
                Window.Close();
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
