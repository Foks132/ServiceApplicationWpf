using ServiceApplication.Entities;
using ServiceApplication.Pages;
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

namespace ServiceApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new AuthPage());
        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            App.LogoutUser();
            while (mainFrame.CanGoBack)
            {
                mainFrame.RemoveBackEntry();
            }
            mainFrame.Navigate(new AuthPage());
        }

        private void mainFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (App.GetUser() is User)
            {
                btnlogout.Visibility = Visibility.Visible;
                return;
            }
            btnlogout.Visibility = Visibility.Collapsed;
        }
    }
}
