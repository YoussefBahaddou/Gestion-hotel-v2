using Management_Hotel.ViewModels;
using Management_Hotel.Views.Dialogs;
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

namespace Management_Hotel.Views
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        private readonly DashboardViewModel _dashboardViewModel;

        public AdminDashboard()
        {
            InitializeComponent();
            _dashboardViewModel = new DashboardViewModel();
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new DashboardView());
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new EmployeeManagementView());
        }


        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ClientManagementView());
        }

        private void RoomTypesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new RoomTypeManagementView());
        }

        private void ReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ReservationManagementView());
        }


        private void PaymentsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new PaymentManagementView());
        }


        private void AvailabilityButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to availability view
            // Add custom availability logic
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            // Generate and display reports based on DashboardViewModel data
            var currentReservations = _dashboardViewModel.GetCurrentReservationsCount();
            var occupancyRate = _dashboardViewModel.GetOccupancyRate();
            var monthlyRevenue = _dashboardViewModel.GetMonthlyRevenue();

            // Add logic to display reports
        }

        private void NotificationsButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle notifications display
            // Add custom notification logic
        }
    }
}
