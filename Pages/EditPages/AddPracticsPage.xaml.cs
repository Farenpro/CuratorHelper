using CuratorHelper.Classes;
using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddPracticsPage.xaml
    /// </summary>
    public partial class AddPracticsPage : Page
    {
        public static string NumSymbPattern = @"^[0-9]+$";
        public Student Student { get; set; }
        public PracticeName PracticeName { get; set; }
        public byte Term { get; set; }
        public byte Mark { get; set; }
        public EditInfoWindow Window;
        public AddPracticsPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            FillCBPracticeName();
            CBoxStudents.ItemsSource = App.Database.Students.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Student != null && PracticeName != null && Term != 0 && Mark != 0 && TBoxDayDuration.Text != "")
            {
                if (Convert.ToInt32(TBoxDayDuration.Text) >= 1 && Convert.ToInt32(TBoxDayDuration.Text) <= 90)
                {
                    if (App.Database.Practices.Where(p => p.StudentID == Student.ID && p.PracticeName.ID == PracticeName.ID && p.Term == Term).Count() <= 0)
                    {
                        int id = 1;
                        if (App.Database.Practices.Count() > 0)
                            id = App.Database.Practices.Select(p => p.ID).Max() + 1;
                        Practice practice = new Practice()
                        {
                            ID = id,
                            PracticeNameID = PracticeName.ID,
                            Term = Term,
                            DaysDuration = Convert.ToInt32(TBoxDayDuration.Text),
                            Mark = Mark,
                            StudentID = Student.ID
                        };
                        App.Database.Practices.Add(practice);
                        App.DBRefresh();
                        App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                        Window.Close();
                    }
                    else
                        App.Messages.ShowError(Properties.Resources.PracticeExists);
                }
                else
                    App.Messages.ShowError(Properties.Resources.DaysDurationError);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void TBoxDayDuration_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Regex.IsMatch(e.Text, NumSymbPattern))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void BtnAddPracticeName_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(14);
            FillCBPracticeName();
        }
        private void FillCBPracticeName() { CBoxPracticeName.ItemsSource = App.Database.PracticeNames.ToList(); }
    }
}
