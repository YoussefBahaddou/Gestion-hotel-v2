using Management_Hotel.Models;
using System.Windows;

namespace Management_Hotel.Views.Dialogs
{
    public partial class AddEditPaymentDialog : Window
    {
        private Paiement _payment;

        public AddEditPaymentDialog()
        {
            InitializeComponent();
            _payment = new Paiement();
        }

        public void SetPayment(Paiement payment)
        {
            _payment = payment;
            ReservationComboBox.SelectedValue = payment.Idreservation;
            MontantTextBox.Text = payment.Montant.ToString();
            //DatePaiementPicker.SelectedDate = payment.Datepaiement.ToDateTime(TimeOnly.MinValue);
            ModePaiementComboBox.Text = payment.Modepaiement;
        }

        public Paiement GetPayment()
        {
            _payment.Idreservation = (int)ReservationComboBox.SelectedValue;
            _payment.Montant = decimal.Parse(MontantTextBox.Text);
            //_payment.Datepaiement = DateOnly.FromDateTime(DatePaiementPicker.SelectedDate.Value);
            _payment.Modepaiement = ModePaiementComboBox.Text;
            return _payment;
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
