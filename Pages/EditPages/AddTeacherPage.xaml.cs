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
    /// Interaction logic for AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public Gender Gender { get; set; }
        public EditInfoWindow Window;
        public AddTeacherPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxGender.ItemsSource = App.Database.Genders.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Surname != "" && Firstname != "" && Middlename != "" && Gender != null)
            {
                if (App.Database.Teachers.Where(p => p.Surname == Surname && p.Name ==  Firstname && p.Middlename == Middlename && p.GenderID == Gender.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.Teachers.Count() > 0)
                        id = App.Database.Teachers.Select(p => p.ID).Max() + 1;
                    Teacher teacher = new Teacher()
                    {
                        ID = id,
                        Surname = Surname,
                        Name = Firstname,
                        Middlename = Middlename,
                        GenderID = Gender.ID
                    };
                    App.Database.Teachers.Add(teacher);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.TeacherExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
