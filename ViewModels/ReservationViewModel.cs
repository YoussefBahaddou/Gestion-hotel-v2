//using Management_Hotel.Connection;
using Management_Hotel.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Management_Hotel.ViewModels
{
    public class ReservationViewModel
    {
        private readonly HotelDbContext _context;
        public ObservableCollection<Reservation> Reservations { get; set; }

        public ReservationViewModel()
        {
            _context = new HotelDbContext();
            LoadReservations();
        }


        private void LoadReservations()
        {
            var reservations = _context.Reservations
                .Include(r => r.IdclientNavigation)
                .Include(r => r.IdutilisateurNavigation)
                .ToList();
            Reservations = new ObservableCollection<Reservation>(reservations);
        }



        public bool AddReservation(Reservation reservation)
        {
            try
            {
                _context.Reservations.Add(reservation);
                _context.SaveChanges();
                LoadReservations();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
            LoadReservations();
        }

        public void DeleteReservation(int reservationId)
        {
            var reservation = _context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
                LoadReservations();
            }
        }

        public void GenerateReservationPDF(int reservationId)
        {
            // PDF generation logic will be implemented here
        }

        public void SendConfirmationEmail(int reservationId)
        {
            // Email sending logic will be implemented here
        }
    }
}
