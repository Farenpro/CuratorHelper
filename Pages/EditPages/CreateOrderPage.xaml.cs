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
    /// Interaction logic for AddOrderPage.xaml
    /// </summary>
    public partial class CreateOrderPage : Page
    {
        public Student Student { get; set; }
        public OrderType OrderType { get; set; }
#nullable enable
        public byte? Course { get; set; }
        public EditInfoWindow Window;
        public CreateOrderPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            Window.DataContext = this;
            DataContext = this;
            CBoxStudents.ItemsSource = App.Database.Students.ToList();
            CBoxOrderTypes.ItemsSource = App.Database.OrderTypes.ToList();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (Student != null && OrderType != null)
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
                App.Messages.ShowError(Properties.Resources.NeedToFillRequired);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }
    }
}
