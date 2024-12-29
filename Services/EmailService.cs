using System.Net.Mail;
using System.Net;
using Management_Hotel.Models;

namespace Hotel_Management.Services
{
    public class EmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUsername = "your-email@gmail.com";
        private readonly string _smtpPassword = "your-app-password";

        public void SendReservationConfirmation(Reservation reservation)
        {
            var client = new SmtpClient(_smtpServer)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                EnableSsl = true
            };

            var message = new MailMessage
            {
                From = new MailAddress(_smtpUsername),
                Subject = $"Confirmation de réservation #{reservation.Idreservation}",
                Body = GenerateEmailBody(reservation),
                IsBodyHtml = true
            };

            message.To.Add(reservation.IdclientNavigation.Email);
            client.Send(message);
        }

        private string GenerateEmailBody(Reservation reservation)
        {
            return $@"
                <h2>Confirmation de votre réservation</h2>
                <p>Cher(e) {reservation.IdclientNavigation.Prenom} {reservation.IdclientNavigation.Nom},</p>
                <p>Votre réservation a été confirmée avec les détails suivants :</p>
                <ul>
                    <li>Numéro de réservation : {reservation.Idreservation}</li>
                    <li>Date d'arrivée : {reservation.Datearrivee}</li>
                    <li>Date de départ : {reservation.Datedepart}</li>
                </ul>
                <p>Merci de votre confiance!</p>";
        }
    }
}
