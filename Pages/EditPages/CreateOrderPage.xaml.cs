using CuratorHelper.Models;
using CuratorHelper.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for AddOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        public Student Student { get; set; }
        public OrderType OrderType { get; set; }
#nullable enable
        public byte? Course { get; set; }
        public EditInfoWindow Window;
        public CreateOrderPage() { Initializing(); }

        public CreateOrderPage(Student student)
        {
            Initializing();
            CBoxStudents.SelectedItem = student;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (Student != null && OrderType != null)
            {
                if (App.Database.Orders.Where(p => p.StudentID == Student.ID && p.OrderTypeID == OrderType.ID && p.Date.Day == DateTime.Now.Day && p.Course == Course).Count() <= 0)
                {
                    int id = 1;
                    if (App.Database.Orders.Count() > 0)
                        id = App.Database.Orders.Select(p => p.ID).Max() + 1;
                    Order order = new Order()
                    {
                        ID = id,
                        OrderTypeID = OrderType.ID,
                        Date = DateTime.Now,
                        StudentID = Student.ID,
                        Course = Course
                    };
                    App.Database.Orders.Add(order);
                    App.DBRefresh();
                    App.Messages.ShowInfo(Properties.Resources.AddCongrats);
                    Window.Close();
                }
                else
                    App.Messages.ShowError(Properties.Resources.OrderExists);
            }
            else
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void Initializing()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxStudents.ItemsSource = App.Database.Students.ToList();
            CBoxOrderTypes.ItemsSource = App.Database.OrderTypes.ToList();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }
    }
}
