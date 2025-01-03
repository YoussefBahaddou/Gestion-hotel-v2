using System.Windows;
using Management_Hotel.Models;

namespace Management_Hotel.Views.Dialogs
{
    public partial class AddEditRoomTypeDialog : Window
    {
        private Typechambre _roomType;


        public AddEditRoomTypeDialog()
        {
            InitializeComponent();
            _roomType = new Typechambre();
        }
        
        public void SetRoomType(Typechambre roomType)
        {
            _roomType = roomType;
            LibelleTextBox.Text = roomType.Libelle;
            DescriptionTextBox.Text = roomType.Description;
            CapaciteTextBox.Text = roomType.Capacite.ToString();
            PrixTextBox.Text = roomType.Prixnuit.ToString();
        }
        
        public Typechambre GetRoomType()
        {
            _roomType.Libelle = LibelleTextBox.Text;
            _roomType.Description = DescriptionTextBox.Text;
            _roomType.Capacite = int.Parse(CapaciteTextBox.Text);
            _roomType.Prixnuit = decimal.Parse(PrixTextBox.Text);
            return _roomType;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LibelleTextBox.Text) ||
                string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                string.IsNullOrWhiteSpace(CapaciteTextBox.Text) ||
                string.IsNullOrWhiteSpace(PrixTextBox.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }

        /*private void DeleteRoomType_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Typechambre roomType)
            {
                if (_viewModel.HasReservations(roomType.Idtype))
                {
                    MessageBox.Show(
                        "Ce type de chambre ne peut pas être supprimé car il est associé à des réservations.",
                        "Suppression impossible",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer ce type de chambre ?",
                    "Confirmation",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _viewModel.DeleteRoomType(roomType.Idtype);
                    LoadRoomTypes();
                }
            }
        }
        */

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
