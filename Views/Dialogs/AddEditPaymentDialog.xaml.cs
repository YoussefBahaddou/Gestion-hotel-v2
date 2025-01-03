using Management_Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Management_Hotel.Views.Dialogs
{
    public partial class AddEditPaymentDialog : Window
    {
        private Paiement _payment;
        private readonly HotelDbContext _context;
        public AddEditPaymentDialog()
        {
            InitializeComponent();
            _context = new HotelDbContext();
            _payment = new Paiement();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            var reservations = _context.Reservations
                .Include(r => r.IdclientNavigation)
                .ToList();
            ReservationComboBox.ItemsSource = reservations;
            ReservationComboBox.DisplayMemberPath = "Idreservation";
            ReservationComboBox.SelectedValuePath = "Idreservation";
        }

        public void SetPayment(Paiement payment)
        {
            _payment = payment;
            ReservationComboBox.SelectedValue = payment.Idreservation;
            MontantTextBox.Text = payment.Montant.ToString();
            DatePaiementPicker.SelectedDate = payment.Datepaiement;
            ModePaiementComboBox.Text = payment.Modepaiement;
        }

        public Paiement GetPayment()
        {
            _payment.Idreservation = (int)ReservationComboBox.SelectedValue;
            _payment.Montant = decimal.Parse(MontantTextBox.Text);
            _payment.Datepaiement = DatePaiementPicker.SelectedDate ?? DateTime.Now;
            _payment.Modepaiement = ModePaiementComboBox.Text;
            return _payment;
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationComboBox.SelectedValue == null ||
                string.IsNullOrWhiteSpace(MontantTextBox.Text) ||
                DatePaiementPicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(ModePaiementComboBox.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
