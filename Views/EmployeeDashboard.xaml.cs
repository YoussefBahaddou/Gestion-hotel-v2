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
            var clientDialog = new Dialogs.AddEditClientDialog();
            clientDialog.ShowDialog();
        }

        private void AvailabilityButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to availability view
            MainContent.Navigate(new DashboardView());
        }

        private void ReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            var reservationDialog = new Dialogs.AddEditReservationDialog();
            reservationDialog.ShowDialog();
        }

        private void PaymentsButton_Click(object sender, RoutedEventArgs e)
        {
            var paymentDialog = new Dialogs.AddEditPaymentDialog();
            paymentDialog.ShowDialog();
        }
    }
}
