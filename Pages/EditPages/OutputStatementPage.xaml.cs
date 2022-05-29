using CuratorHelper.Classes;
using CuratorHelper.Windows;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.EditPages
{
    /// <summary>
    /// Interaction logic for OutputStatementPage.xaml
    /// </summary>
    public partial class OutputStatementPage : Page
    {
        public EditInfoWindow Window;
        public string GroupName { get; set; }
#nullable enable
        public byte? Term { get; set; }
        public OutputStatementPage()
        {
            InitializeComponent();
            Window = App.Current.Windows.OfType<EditInfoWindow>().SingleOrDefault();
            GroupName = App.CurGroup.Name;
            Window.DataContext = this;
            DataContext = this;
        }

        private void BtnOutput_Click(object sender, RoutedEventArgs e)
        {
            if (Term != null)
                SubFunctions.OutputStatement(Term);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e) { Window.Close(); }
    }
}
