//using Management_Hotel.Connection;
using Management_Hotel.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Management_Hotel.ViewModels
{
    public class PaymentViewModel
    {
        private readonly HotelDbContext _context;
        public ObservableCollection<Paiement> Payments { get; set; }


        public PaymentViewModel()
        {
            _context = new HotelDbContext();
            LoadPayments();
        }

        private void LoadPayments()
        {
            var payments = _context.Paiements
                .Include(p => p.IdreservationNavigation)
                .ThenInclude(r => r.IdclientNavigation)
                .ToList();
            Payments = new ObservableCollection<Paiement>(payments);
        }

        public bool AddPayment(Paiement payment)
        {
            try
            {
                _context.Paiements.Add(payment);
                _context.SaveChanges();
                LoadPayments();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdatePayment(Paiement payment)
        {
            _context.Paiements.Update(payment);
            _context.SaveChanges();
            LoadPayments();
        }

        public decimal GetTotalPayments(int reservationId)
        {
            return _context.Paiements
                .Where(p => p.Idreservation == reservationId)
                .Sum(p => p.Montant);
        }

        public void DeletePayment(int paymentId)
        {
            var payment = _context.Paiements.Find(paymentId);
            if (payment != null)
            {
                _context.Paiements.Remove(payment);
                _context.SaveChanges();
                LoadPayments();
            }
        }
        public Paiement GetPaymentWithDetails(int paymentId)
        {
            return _context.Paiements
                .Include(p => p.IdreservationNavigation)
                .ThenInclude(r => r.IdclientNavigation)
                .FirstOrDefault(p => p.Idpaiement == paymentId);
        }


    }
}
