using Management_Hotel.Models;
using Management_Hotel.ViewModels;
using Management_Hotel.Views.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace Management_Hotel.Views
{
    public partial class ReservationManagementView : UserControl
    {
        private readonly ReservationViewModel _viewModel;

        public ReservationManagementView()
        {
            InitializeComponent();
            _viewModel = new ReservationViewModel();
            LoadReservations();
        }

        private void LoadReservations()
        {
            ReservationsGrid.ItemsSource = _viewModel.Reservations;
        }

        private void AddReservation_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEditReservationDialog();
            if (dialog.ShowDialog() == true)
            {
                var newReservation = dialog.GetReservation();
                _viewModel.AddReservation(newReservation);
                LoadReservations();
            }
        }

        private void EditReservation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Reservation reservation)
            {
                var dialog = new AddEditReservationDialog();
                dialog.SetReservation(reservation);
                if (dialog.ShowDialog() == true)
                {
                    var updatedReservation = dialog.GetReservation();
                    _viewModel.UpdateReservation(updatedReservation);
                    LoadReservations();
                }
            }
        }

        private void DeleteReservation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Reservation reservation)
            {
                var result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cette réservation ?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteReservation(reservation.Idreservation);
                    LoadReservations();
                }
            }
        }

        private void GeneratePDF_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Reservation reservation)
            {
                _viewModel.GenerateReservationPDF(reservation.Idreservation);
            }
        }

        private void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Reservation reservation)
            {
                _viewModel.SendConfirmationEmail(reservation.Idreservation);
            }
        }

        private void RefreshReservations_Click(object sender, RoutedEventArgs e)
        {
            LoadReservations();
        }
    }
}
