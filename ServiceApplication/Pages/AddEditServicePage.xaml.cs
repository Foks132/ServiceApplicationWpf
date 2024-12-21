using ServiceApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        Service Service { get; set; }
        bool isEdit { get; set; }
        public AddEditServicePage()
        {
            InitializeComponent();
            this.Title = "Новая заявка";
            this.Service = new Service();
            isEdit = false;
            update();
        }

        public AddEditServicePage(Service service)
        {
            InitializeComponent();
            this.Title = "Изменение статуса заявки";
            if (service != null)
            {
                this.Service = service;
                isEdit = true;
                update();
            }
        }

        private void update()
        {
            try
            {
                CbClient.ItemsSource = App.GetContext().Clients.ToList();
                CbManager.ItemsSource = App.GetContext().Users.ToList();
                CbStatus.ItemsSource = App.GetContext().Status.ToList();
                var _context = new BindContext()
                {
                    Service = this.Service,
                    IsEdit = this.isEdit,
                };
                DataContext = _context;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Service.id == 0)
                {
                    App.GetContext().Services.Add(this.Service);
                }
                App.GetContext().SaveChanges();
                MessageBox.Show("Заявка сохранена.", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
