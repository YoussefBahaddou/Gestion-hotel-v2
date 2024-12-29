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

        public void AddPayment(Paiement payment)
        {
            _context.Paiements.Add(payment);
            _context.SaveChanges();
            LoadPayments();
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
    }
}
