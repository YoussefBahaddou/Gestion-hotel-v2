using Management_Hotel.Models;
using Management_Hotel.ViewModels;
using Management_Hotel.Views.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace Management_Hotel.Views
{
    public partial class PaymentManagementView : UserControl
    {
        private readonly PaymentViewModel _viewModel;

        public PaymentManagementView()
        {
            InitializeComponent();
            _viewModel = new PaymentViewModel();
            LoadPayments();
        }

        private void LoadPayments()
        {
            PaymentsGrid.ItemsSource = _viewModel.Payments;
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEditPaymentDialog();
            if (dialog.ShowDialog() == true)
            {
                var result = _viewModel.AddPayment(dialog.GetPayment());
                if (result)
                {
                    MessageBox.Show("Paiement ajouté avec succès!", "Succès",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadPayments();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du paiement", "Erreur",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        private void EditPayment_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Paiement payment)
            {
                // TODO: Implement edit payment dialog
                MessageBox.Show("Fonctionnalité de modification de paiement à implémenter");
            }
        }

        private void GenerateReceipt_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Paiement payment)
            {
                // TODO: Implement receipt generation
                MessageBox.Show($"Génération du reçu pour le paiement {payment.Idpaiement}");
            }
        }

        private void ExportPayments_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement export functionality
            MessageBox.Show("Fonctionnalité d'exportation à implémenter");
        }
    }
}
