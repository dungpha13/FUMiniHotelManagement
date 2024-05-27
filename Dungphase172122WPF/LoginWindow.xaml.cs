using BusinessObjects;
using Services;
using Microsoft.Extensions.Configuration;
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
using Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Dungphase172122WPF
{
    public class DefaultAdminAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomerService _service;
        private DefaultAdminAccount _adminAccount;
        public LoginWindow()
        {
            InitializeComponent();
            LoadAdminAccount();
            _service = ((App)Application.Current).ServiceProvider.GetRequiredService<ICustomerService>() ?? throw new ArgumentNullException(nameof(CustomerService));
        }

        private void LoadAdminAccount()
        {
            var config = ConfigurationManager.Configuration;
            var defaultAdminAccount = config.GetSection("DefaultAdminAccount").Get<DefaultAdminAccount>();

            if (defaultAdminAccount != null)
            {
                _adminAccount = defaultAdminAccount;
            }
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(pwdPassword.Password))
            {
                if (IsAdmin(txtEmail.Text, pwdPassword.Password))
                {
                    MessageBox.Show("Login admin successful!");

                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();

                    Close();
                }
                else
                {
                    Customer? customer = await _service.CheckLogin(txtEmail.Text, pwdPassword.Password);

                    if (customer != null)
                    {
                        MessageBox.Show("Login successful!");

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.customer = customer;
                        mainWindow.Show();

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong email or password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool IsAdmin(string email, string password)
        {
            return _adminAccount.Email.Equals(email) && _adminAccount.Password.Equals(password) ? true : false;
        }
    }


}
