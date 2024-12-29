//using Management_Hotel.Connection;
using Management_Hotel.Models;
using System;
using System.Linq;

namespace Management_Hotel.ViewModels
{
    public class DashboardViewModel
    {
        private readonly HotelDbContext _context;

        public DashboardViewModel()
        {
            _context = new HotelDbContext();
        }

        public int GetCurrentReservationsCount()
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return _context.Reservations.Count(r =>
                r.Datearrivee <= today &&
                r.Datedepart >= today &&
                r.Statut == "Confirmée");
        }
        
        public decimal GetOccupancyRate()
        {
            var totalRooms = _context.Typechambres.Sum(t => t.Capacite);
            var occupiedRooms = GetCurrentReservationsCount();
            return totalRooms > 0 ? (decimal)occupiedRooms / totalRooms * 100 : 0;
        }

        public decimal GetMonthlyRevenue()
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);


            return _context.Paiements
                .Where(p => p.Datepaiement >= firstDayOfMonth &&
                           p.Datepaiement <= lastDayOfMonth)
                .Sum(p => p.Montant);
        }
        
        public void UpdateDashboard()
        {
            // Implementation for updating the dashboard UI
        }
    }
}
