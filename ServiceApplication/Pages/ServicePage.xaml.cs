using ServiceApplication.Entities;
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

namespace ServiceApplication.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        private Service _service { get; set; }

        public ServicePage()
        {
            InitializeComponent();
            Update();
        }

        private void DgService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgService.SelectedItem is Service service)
            {
                this._service = service;
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditServicePage());
        }

        private void btnEditStatus_Click(object sender, RoutedEventArgs e)
        {
            if (this._service == null)
            {
                MessageBox.Show("Следует выбрать запись!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            NavigationService.Navigate(new AddEditServicePage(this._service));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this._service == null)
                {
                    MessageBox.Show("Следует выбрать запись!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (MessageBox.Show($"Удалить запись с номером {_service.id}", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    App.GetContext().Services.Remove(this._service);
                    App.GetContext().SaveChanges();
                    Update();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            DgService.ItemsSource = App.GetContext().Services.ToList();
        }
    }
}
