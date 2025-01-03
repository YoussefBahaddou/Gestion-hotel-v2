using Management_Hotel.Models;
using System.Windows;

namespace Management_Hotel.Views.Dialogs
{
    public partial class AddEditClientDialog : Window
    {
        public Client Client { get; private set; }
        private bool IsEditMode;

        public AddEditClientDialog(Client client = null)
        {
            InitializeComponent();
            IsEditMode = client != null;

            if (IsEditMode)
            {
                Client = client;
                LoadClientData();
                Title = "Modifier un client";
            }
            else
            {
                Title = "Ajouter un client";
                Client = new Client();
            }
        }

        private void LoadClientData()
        {
            NomTextBox.Text = Client.Nom;
            PrenomTextBox.Text = Client.Prenom;
            EmailTextBox.Text = Client.Email;
            TelephoneTextBox.Text = Client.Telephone;
            AdresseTextBox.Text = Client.Adresse;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                string.IsNullOrWhiteSpace(TelephoneTextBox.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Client.Nom = NomTextBox.Text;
            Client.Prenom = PrenomTextBox.Text;
            Client.Email = EmailTextBox.Text;
            Client.Telephone = TelephoneTextBox.Text;
            Client.Adresse = AdresseTextBox.Text;

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
