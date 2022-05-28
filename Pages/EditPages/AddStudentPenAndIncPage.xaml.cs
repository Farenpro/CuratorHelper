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
    /// Interaction logic for StudentPenAndIncPage.xaml
    /// </summary>
    public partial class AddStudentPenAndIncPage : Page
    {
        public Student Student { get; set; }
        public PenAndIncType PenAndIncType { get; set; }
        public string Nature { get; set; }
        public Order Order { get; set; }
        public EditInfoWindow Window;
        public AddStudentPenAndIncPage(Student student)
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().LastOrDefault();
            Window.DataContext = this;
            DataContext = this;
            Student = student;
            LStudentName.Content = Student.FIO;
            CBoxOrder.ItemsSource = App.Database.Orders.Where(p => p.Student.ID == Student.ID && (p.OrderType.Name == "Поощрение студента" || p.OrderType.Name == "Взыскание к студенту")).ToList();
            CBoxPenAndIncType.ItemsSource = App.Database.PenAndIncTypes.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (PenAndIncType != null && Nature != "" && Order!=null)
            {
                if (App.Database.PenAndIncs.Where(p => p.Student.ID == Student.ID && p.Order.ID == Order.ID).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.PenAndIncs.Count() > 0)
                        id = App.Database.PenAndIncs.Select(p => p.ID).Max() + 1;
                    PenAndInc penAndInc = new PenAndInc()
                    {
                        ID = id,
                        Nature = Nature,
                        OrderID = Order.ID,
                        StudentID = Student.ID,
                        PenAndIncTypeID = PenAndIncType.ID
                    };
                    App.Database.PenAndIncs.Add(penAndInc);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.PenAndIncExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }
    }
}
