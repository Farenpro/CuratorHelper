using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddDemoExamPage.xaml
    /// </summary>
    public partial class AddDemoExamPage : Page
    {
        public Student Student { get; set; }
        public DemoExamName DemoExamName { get; set; }
        public byte Mark { get; set; }
        public EditInfoWindow Window;
        public AddDemoExamPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxStudents.ItemsSource = App.Database.Students.ToList();
            FillCBDemoExamNames();
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Student != null && DemoExamName != null && Mark != 0)
            {
                if (App.Database.DemoExams.Where(p => p.StudentID == Student.ID && p.DemoExamNameID == DemoExamName.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.DemoExams.Count() > 0)
                        id = App.Database.DemoExams.Select(p => p.ID).Max() + 1;
                    DemoExam demoExam = new DemoExam()
                    {
                        ID = id,
                        DemoExamNameID = DemoExamName.ID,
                        Mark = Mark,
                        StudentID = Student.ID
                    };
                    App.Database.DemoExams.Add(demoExam);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.DemoExamExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void BtnAddDemoExamName_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(16);
            FillCBDemoExamNames();
        }

        private void FillCBDemoExamNames() { CBoxDemoExamNames.ItemsSource = App.Database.DemoExamNames.ToList(); }
    }
}
