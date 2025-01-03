using Management_Hotel.Models;
using Management_Hotel.ViewModels;
using Management_Hotel.Views.Dialogs;
using System.Windows;
using System.Windows.Controls;

namespace Management_Hotel.Views
{
    public partial class ClientManagementView : UserControl
    {
        private readonly ClientViewModel _viewModel;

        public ClientManagementView()
        {
            InitializeComponent();
            _viewModel = new ClientViewModel();
            LoadClients();
        }

        private void LoadClients()
        {
            ClientsGrid.ItemsSource = _viewModel.Clients;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddEditClientDialog();
            if (dialog.ShowDialog() == true)
            {
                var result = _viewModel.AddClient(dialog.Client);
                if (result)
                {
                    MessageBox.Show("Client ajouté avec succès!", "Succès",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadClients();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout du client", "Erreur",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UpdateClient_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Client client)
            {
                var dialog = new AddEditClientDialog(client);
                if (dialog.ShowDialog() == true)
                {
                    _viewModel.UpdateClient(dialog.Client);
                    LoadClients();
                }
            }
        }


        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Client client)
            {
                var hasReservations = _viewModel.HasReservations(client.Idclient);

                if (hasReservations)
                {
                    MessageBox.Show(
                        "Ce client ne peut pas être supprimé car il a des réservations associées.",
                        "Suppression impossible",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ce client ?",
                    "Confirmation de suppression",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteClient(client.Idclient);
                    LoadClients();
                }
            }
        }


        private void ViewReservations_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Client client)
            {
                // TODO: Implement reservation view logic
                MessageBox.Show($"Afficher les réservations pour {client.Nom} {client.Prenom}");
            }
        }

        private void ExportClients_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement export functionality
            MessageBox.Show("Fonctionnalité d'exportation à implémenter");
        }

        private void ImportClients_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Implement import functionality
            MessageBox.Show("Fonctionnalité d'importation à implémenter");
        }
    }
}
