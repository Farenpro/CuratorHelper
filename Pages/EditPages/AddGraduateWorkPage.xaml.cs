using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddGraduateWorkPage.xaml
    /// </summary>
    public partial class AddGraduateWorkPage : Page
    {
        public Student Student { get; set; }
        public GraduateWorkType GWKType { get; set; }
        public Qualification Qualification { get; set; }
        public string Theme { get; set; }
        public byte Mark { get; set; }
        public DateTime ProtectDate { get; set; }
        public EditInfoWindow Window;
        public AddGraduateWorkPage()
        {
            InitializeComponent();
            DPProtectDate.DisplayDateStart = DateTime.Now.AddMonths(-2);
            DPProtectDate.DisplayDateEnd = DateTime.Now;
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxGWKType.ItemsSource = App.Database.GraduateWorkTypes.ToList();
            CBoxStudents.ItemsSource = App.Database.Students.ToList();
            FillCBQualification();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Student != null && GWKType != null && Qualification != null && Theme != "" && Mark != 0 && ProtectDate != null)
            {
                if (App.Database.GraduateWorks.Where(p => p.StudentID == Student.ID && p.GraduateWorkTypeID == GWKType.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.GraduateWorks.Count() > 0)
                        id = App.Database.GraduateWorks.Select(p => p.ID).Max() + 1;
                    GraduateWork graduateWork = new GraduateWork()
                    {
                        ID = id,
                        GraduateWorkTypeID = GWKType.ID,
                        Name = Theme,
                        ProtectDate = ProtectDate,
                        Mark = Mark,
                        StudentID = Student.ID,
                        QualificationID = Qualification.ID
                    };
                    App.Database.GraduateWorks.Add(graduateWork);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.GraduateWorkExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void BtnQualificationAdd_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(12);
            FillCBQualification();
        }

        private void FillCBQualification() { CBoxQualification.ItemsSource = App.Database.Qualifications.ToList(); }
    }
}
