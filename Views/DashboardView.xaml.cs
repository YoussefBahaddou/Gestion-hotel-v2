using Management_Hotel.ViewModels;
using System.Windows.Controls;

namespace Management_Hotel.Views
{
    public partial class DashboardView : UserControl
    {
        private readonly DashboardViewModel _viewModel;

        public DashboardView()
        {
            InitializeComponent();
            _viewModel = new DashboardViewModel();
            UpdateDashboardData();
        }

        private void UpdateDashboardData()
        {
            // Update statistics cards
            ReservationsCount.Text = _viewModel.GetCurrentReservationsCount().ToString();
            OccupancyRate.Text = $"{_viewModel.GetOccupancyRate():F1}%";
            MonthlyRevenue.Text = $"{_viewModel.GetMonthlyRevenue():C}";

            // TODO: Implement chart updates
            UpdateRevenueChart();
            UpdateOccupancyChart();
        }

        private void UpdateRevenueChart()
        {
            // Revenue chart implementation will go here
            RevenueChart.Children.Clear();
            // Add chart elements
        }

        private void UpdateOccupancyChart()
        {
            // Occupancy chart implementation will go here
            OccupancyChart.Children.Clear();
            // Add chart elements
        }
    }
}
