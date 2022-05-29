using CuratorHelper.Classes;
using CuratorHelper.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.ModulePages
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public OrdersPage()
        {
            InitializeComponent();
            FillDGOrders();
        }

        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(7);
            FillDGOrders();
        }

        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (DGOrders.SelectedItems.Count > 0)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    foreach (Order order in DGOrders.SelectedItems)
                        App.Database.Orders.Remove(order);
                    App.DBRefresh();
                    FillDGOrders();
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.OrdersCountZero);
        }

        private void FillDGOrders() { DGOrders.ItemsSource = App.Database.Orders.ToList(); }
    }
}
