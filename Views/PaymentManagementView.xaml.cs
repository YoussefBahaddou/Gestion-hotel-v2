using Hotel_Management.Services;
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
        private readonly PDFService _pdfService;
        private readonly EmailService _emailService;
        private readonly NotificationService _notificationService;
        private readonly ReceiptService _receiptService;


        public PaymentManagementView()
        {
            InitializeComponent();
            _viewModel = new PaymentViewModel();
            _pdfService = new PDFService();
            _emailService = new EmailService();
            _notificationService = new NotificationService();
            _receiptService = new ReceiptService();
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



        private void UpdatePayment_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Paiement payment)
            {
                var dialog = new AddEditPaymentDialog();
                dialog.SetPayment(payment);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdatePayment(dialog.GetPayment());
                    LoadPayments();
                }
            }
        }

        private void DeletePayment_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Paiement payment)
            {
                var result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ce paiement ?",
                    "Confirmation de suppression",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeletePayment(payment.Idpaiement);
                    LoadPayments();
                }
            }
        }


        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentsGrid.SelectedItem is Paiement selectedPayment)
            {
                var payment = _viewModel.GetPaymentWithDetails(selectedPayment.Idpaiement);
                var reservation = payment.IdreservationNavigation;

                if (reservation.Statut.ToLower() == "confirmée")
                {
                    try
                    {
                        var pdfPath = _receiptService.GenerateReceipt(payment);

                        var result = MessageBox.Show(
                            $"Le reçu a été généré avec succès!\nVoulez-vous ouvrir le fichier?",
                            "Génération PDF",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Information);

                        if (result == MessageBoxResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = pdfPath,
                                UseShellExecute = true
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la génération du PDF: {ex.Message}",
                            "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Le reçu ne peut être généré que pour les réservations confirmées.",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un paiement dans la liste.",
                    "Sélection requise", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SendConfirmation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Paiement payment)
            {
                try
                {
                    _emailService.SendReservationConfirmation(payment.IdreservationNavigation);
                    _notificationService.CreateNotification((int)payment.Idreservation, "Confirmation de paiement");

                    MessageBox.Show("Email de confirmation envoyé avec succès!",
                        "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'envoi de l'email: {ex.Message}",
                        "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
