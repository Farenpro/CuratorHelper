using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddGroupPage.xaml
    /// </summary>
    public partial class AddGroupPage : Page
    {
        public string GroupName { get; set; }
        public User Curator { get; set; }
        public Specialization Specialization { get; set; }
        public Department Department { get; set; }
        public DateTime StartStudyDate { get; set; }
        public EditInfoWindow Window;
        public AddGroupPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            DPStartStudyDate.DisplayDateStart = DateTime.Now.AddYears(-5);
            DPStartStudyDate.DisplayDateEnd = DateTime.Now.AddYears(1);
            CBoxCurator.ItemsSource = App.Database.Users.ToList();
            CBoxSpecialization.ItemsSource = App.Database.Specializations.ToList();
            CBoxDepartment.ItemsSource = App.Database.Departments.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void GroupAdd()
        {
            if (App.Database.Groups.Where(p => p.Name == GroupName).Count() <= 0)
            {
                int id = 1;
                if (App.Database.Groups.Count() > 0)
                    id = App.Database.Groups.Select(p => p.ID).Max() + 1;
                Group group = new Group()
                {
                    ID = id,
                    CuratorUserID = Curator.ID,
                    SpecializationCode = Specialization.Code,
                    DepartmentID = Department.ID,
                    StartStudyDate = StartStudyDate
                };
                App.Database.Groups.Add(group);
                App.DBRefresh();
                App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                Window.Close();
            }
            else
                App.Messages.ShowError(Properties.Resources.GroupExists);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (GroupName != "" && Curator != null && Specialization != null && Department != null)
            {
                if (App.Database.Users.Where(p => p.ID == Curator.ID).SingleOrDefault().Groups.Count() > 2)
                {
                    if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.TooMuchGroups))
                        GroupAdd();
                }
                else
                    GroupAdd();
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
