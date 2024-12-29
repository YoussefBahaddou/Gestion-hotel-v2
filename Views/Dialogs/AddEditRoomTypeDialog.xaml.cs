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
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
