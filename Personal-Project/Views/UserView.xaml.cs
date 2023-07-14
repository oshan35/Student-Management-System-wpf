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
using System.Windows.Shapes;

namespace Personal_Project.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : Window
    {
        public UserView()
        {
            InitializeComponent();

            MainContentFrame.Navigate(new StudentDataView());
        }

     

        private void ShowAddUserView(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new StudentRegistrationView());
        }

        private void ShowEditUserView(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new EditView());
        }

        private void ShowStudentDataView(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new StudentDataView());
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
            }
        }

        private void MinimizeBtn(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

    }
}
