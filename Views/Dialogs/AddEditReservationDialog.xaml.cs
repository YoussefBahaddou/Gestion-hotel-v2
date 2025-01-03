using Management_Hotel.Models;
using System.Windows;

namespace Management_Hotel.Views.Dialogs 
{ 
    public partial class AddEditReservationDialog : Window
    {
        private Reservation _reservation;
        private readonly HotelDbContext _context;

        public AddEditReservationDialog()
        {
            InitializeComponent();
            _context = new HotelDbContext();
            _reservation = new Reservation();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            // Load Clients
            var clients = _context.Clients.ToList();
            ClientComboBox.ItemsSource = clients;
            ClientComboBox.DisplayMemberPath = "NomComplet"; // We'll add this property
            ClientComboBox.SelectedValuePath = "Idclient";

            // Load Room Types
            var roomTypes = _context.Typechambres.ToList();
            RoomTypeComboBox.ItemsSource = roomTypes;
            RoomTypeComboBox.DisplayMemberPath = "Libelle";
            RoomTypeComboBox.SelectedValuePath = "Idtype";
        }


        public void SetReservation(Reservation reservation)
        {
            _reservation = reservation;
            ClientComboBox.SelectedValue = reservation.Idclient;
            DateArriveePicker.SelectedDate = reservation.Datearrivee.ToDateTime(TimeOnly.MinValue);
            DateDepartPicker.SelectedDate = reservation.Datedepart.ToDateTime(TimeOnly.MinValue);
            StatusComboBox.Text = reservation.Statut;
        }


        public Reservation GetReservation()
        {
            _reservation.Idclient = (int)ClientComboBox.SelectedValue;
            _reservation.Datearrivee = DateOnly.FromDateTime(DateArriveePicker.SelectedDate.Value);
            _reservation.Datedepart = DateOnly.FromDateTime(DateDepartPicker.SelectedDate.Value);
            _reservation.Statut = StatusComboBox.Text;
            _reservation.Datereservation = DateOnly.FromDateTime(DateTime.Now);

            return _reservation;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ClientComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}