using Personal_Project.Models;
using Personal_Project.Views;
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


namespace Personal_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var dataGridRow = FindVisualParent<DataGridRow>(checkBox);

            if (dataGridRow != null && checkBox.IsChecked == true)
            {
                // Unselect all other rows
                foreach (var item in membersDataGrid.Items)
                {
                    var row = (DataGridRow)membersDataGrid.ItemContainerGenerator.ContainerFromItem(item);
                    if (row != dataGridRow)
                        row.IsSelected = false;
                }


            }
        }

        private static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            var parent = parentObject as T;
            return parent ?? FindVisualParent<T>(parentObject);
        }

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
