using Management_Hotel.Models;
//using Management_Hotel.Connection;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management.Services
{
    public class NotificationService
    {
        private readonly HotelDbContext _context;
        private readonly EmailService _emailService;

        public NotificationService()
        {
            _context = new HotelDbContext();
            _emailService = new EmailService();
        }

        public void CreateNotification(int reservationId, string type)
        {
            var notification = new Notification
            {
                Idreservation = reservationId,
                Typenotification = type,
                Dateenvoi = DateOnly.FromDateTime(DateTime.Now),
                Statut = "Non lu"
            };

            _context.Notifications.Add(notification);
            _context.SaveChanges();
        }

        public void SendNotifications()
        {
            var pendingNotifications = _context.Notifications
                .Where(n => n.Statut == "Non lu")
                .Include(n => n.IdreservationNavigation)
                .ThenInclude(r => r.IdclientNavigation)
                .ToList();

            foreach (var notification in pendingNotifications)
            {
                _emailService.SendReservationConfirmation(notification.IdreservationNavigation);
                notification.Statut = "Envoyé";
            }

            _context.SaveChanges();
        }
    }
}
