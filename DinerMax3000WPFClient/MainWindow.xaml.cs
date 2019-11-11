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

namespace DinerMax3000WPFClient
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DinerMax3000.WPFClient.DinerMax3000ViewModel currentViewModel =
                 (DinerMax3000.WPFClient.DinerMax3000ViewModel)DataContext;
            currentViewModel.NewMenuItems.ForEach(newMenuItem => currentViewModel.SelectedMenu.SaveNewMenuItem(newMenuItem.Title, newMenuItem.Description, newMenuItem.Price));
            BindingOperations.GetBindingExpressionBase(cboAllMenus, ComboBox.ItemsSourceProperty).UpdateTarget();
            
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.Row.Item is DinerMax3000.Business.MenuItem newMenuItem && e.EditAction == DataGridEditAction.Commit && e.Row.IsNewItem)
            {
                DinerMax3000.WPFClient.DinerMax3000ViewModel currentViewModel =
                    (DinerMax3000.WPFClient.DinerMax3000ViewModel)DataContext;
                currentViewModel.NewMenuItems.Add(newMenuItem);
            }
        }
    }
}
