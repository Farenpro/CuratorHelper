using CuratorHelper.Classes;
using CuratorHelper.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CuratorHelper.Pages.ModulePages
{
    /// <summary>
    /// Interaction logic for GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        public GroupsPage()
        {
            InitializeComponent();
            FillDGGroups();
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            SubFunctions.ShowEditWindow(3);
            FillDGGroups();
        }

        private void BtnEditCurator_Click(object sender, RoutedEventArgs e)
        {
            App.CurGroup = App.Database.Groups.Where(p => p.ID.ToString() == DGGroups.SelectedValue.ToString()).SingleOrDefault();
            SubFunctions.ShowEditWindow(5);
            FillDGGroups();
        }

        private void BtnEditTeachers_Click(object sender, RoutedEventArgs e)
        {
            App.CurGroup = App.Database.Groups.Where(p => p.ID.ToString() == DGGroups.SelectedValue.ToString()).SingleOrDefault();
            SubFunctions.ShowEditWindow(4);
        }

        private void FillDGGroups() { DGGroups.ItemsSource = App.Database.Groups.ToList(); }

        private void BtnDeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (DGGroups.SelectedItem != null)
            {
                if (MessageBoxResult.OK == App.Messages.ShowQuestion(Properties.Resources.AreYouSureDelete))
                {
                    try
                    {
                        App.Database.Groups.Remove(DGGroups.SelectedItem as Group);
                        App.DBRefresh();
                        FillDGGroups();
                    }
                    catch (InvalidOperationException) { App.Messages.ShowError(Properties.Resources.HaveConnectionsError); }
                }
            }
            else
                App.Messages.ShowError(Properties.Resources.GroupsCountZero);
        }

        private void BtnOutputStatement_Click(object sender, RoutedEventArgs e)
        {
            App.CurGroup = App.Database.Groups.Where(p => p.ID.ToString() == DGGroups.SelectedValue.ToString()).SingleOrDefault();
            SubFunctions.ShowEditWindow(17);
        }
    }
}
