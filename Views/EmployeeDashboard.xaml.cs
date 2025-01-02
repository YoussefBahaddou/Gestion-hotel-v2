using System.Windows;
using System.Windows.Controls;

namespace Management_Hotel.Views
{
    public partial class EmployeeDashboard : Window
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ClientManagementView());
        }


        private void AvailabilityButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to availability view
            MainContent.Navigate(new DashboardView());
        }

        private void ReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ReservationManagementView());
        }


        private void PaymentsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new PaymentManagementView());
        }

    }
}
