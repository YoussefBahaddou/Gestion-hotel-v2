using Management_Hotel.ViewModels;
using System.Windows;

namespace Management_Hotel.Views
{
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _viewModel;

        public LoginWindow()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordBox.Password;

            var (success, role) = _viewModel.ValidateLogin(email, password);

            if (success)
            {
                Window dashboard;
                if (role.ToLower() == "admin")
                {
                    dashboard = new AdminDashboard();
                }
                else
                {
                    dashboard = new EmployeeDashboard();
                }

                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email ou mot de passe incorrect", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
