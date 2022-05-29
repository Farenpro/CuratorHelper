using CuratorHelper.Models;
using CuratorHelper.Windows;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddStudentOmission.xaml
    /// </summary>
    public partial class AddStudentOmission : Page
    {
        public static string NumSymbPattern = @"^[0-9]+$";
        public Student Student { get; set; }
        public OmissionType OmissionType { get; set; }
#nullable enable
        public int? Term1Count { get; set; }
#nullable enable
        public int? Term2Count { get; set; }
#nullable enable
        public int? Term3Count { get; set; }
#nullable enable
        public int? Term4Count { get; set; }
#nullable enable
        public int? Term5Count { get; set; }
#nullable enable
        public int? Term6Count { get; set; }
#nullable enable
        public int? Term7Count { get; set; }
#nullable enable
        public int? Term8Count { get; set; }
        public const int MaxOmissions = 540;
        public EditInfoWindow Window;
        public AddStudentOmission(Student student)
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().LastOrDefault();
            Window.DataContext = this;
            Student = student;
            DataContext = this;
            LStudentName.Content = Student.FIO;
            CBoxOmissionTypes.ItemsSource = App.Database.OmissionTypes.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            if (OmissionType != null)
            {
                if (Term1Count > MaxOmissions || Term2Count > MaxOmissions || Term3Count > MaxOmissions || Term4Count > MaxOmissions || Term6Count > MaxOmissions || Term7Count > MaxOmissions || Term8Count > MaxOmissions)
                {
                    App.Messages.ShowError(Properties.Resources.OmissionCountError);
                    return;
                }
                if (App.Database.Omissions.Where(p => p.Student.ID == Student.ID && p.OmissionTypeID == OmissionType.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.Omissions.Count() > 0)
                        id = App.Database.Omissions.Select(p => p.ID).Max() + 1;
                    Omission omission = new Omission()
                    {
                        ID = id,
                        OmissionTypeID = OmissionType.ID,
                        StudentID = Student.ID,
                        Term1Count = Term1Count,
                        Term2Count = Term2Count,
                        Term3Count = Term3Count,
                        Term4Count = Term4Count,
                        Term5Count = Term5Count,
                        Term6Count = Term6Count,
                        Term7Count = Term7Count,
                        Term8Count = Term8Count
                    };
                    App.Database.Omissions.Add(omission);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                {
                    Omission omission = App.Database.Omissions.Where(p => p.StudentID == Student.ID && p.OmissionTypeID == OmissionType.ID).SingleOrDefault();
                    omission.Term1Count = Term1Count;
                    omission.Term2Count = Term2Count;
                    omission.Term3Count = Term3Count;
                    omission.Term4Count = Term4Count;
                    omission.Term5Count = Term5Count;
                    omission.Term6Count = Term6Count;
                    omission.Term7Count = Term7Count;
                    omission.Term8Count = Term8Count;
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.EditCongrats);
                    Window.Close();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void TBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, NumSymbPattern) || e.Text == "")
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void CBoxOmissionTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Omission omission = App.Database.Omissions.Where(p => p.StudentID == Student.ID && p.OmissionTypeID == OmissionType.ID).SingleOrDefault();
            if (omission != null)
            {
                TBoxTerm1Count.Text = omission.Term1Count.ToString();
                TBoxTerm2Count.Text = omission.Term2Count.ToString();
                TBoxTerm3Count.Text = omission.Term3Count.ToString();
                TBoxTerm4Count.Text = omission.Term4Count.ToString();
                TBoxTerm5Count.Text = omission.Term5Count.ToString();
                TBoxTerm6Count.Text = omission.Term6Count.ToString();
                TBoxTerm7Count.Text = omission.Term7Count.ToString();
                TBoxTerm8Count.Text = omission.Term8Count.ToString();
            }
        }
    }
}
