using Management_Hotel.Models;
using System.Windows;

namespace Management_Hotel.Views.Dialogs 
{ 
    public partial class AddEditReservationDialog : Window
    {
        private Reservation _reservation;
    
        public AddEditReservationDialog()
        {
            InitializeComponent();
            _reservation = new Reservation();
        }
    
        public void SetReservation(Reservation reservation)
        {
            _reservation = reservation;
            // Load reservation data into form fields
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
    }
}