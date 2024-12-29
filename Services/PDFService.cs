using iTextSharp.text;
using iTextSharp.text.pdf;
using Management_Hotel.Models;
using System.IO;
using Npgsql.Internal;
using System.Reflection.Metadata;
using System.Windows.Documents;

namespace Hotel_Management.Services
{
    public class PDFService
    {
        public string GenerateReservationPDF(Reservation reservation)
        {
            var fileName = $"Reservation_{reservation.Idreservation}.pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "PDFs", fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                document.Open();

                // Add hotel logo/header
                document.Add(new iTextSharp.text.Paragraph("HOTEL MANAGEMENT SYSTEM"));
                document.Add(new iTextSharp.text.Paragraph("BON DE RÉSERVATION"));
                document.Add(new iTextSharp.text.Paragraph("---------------------------"));

                // Add reservation details
                document.Add(new iTextSharp.text.Paragraph($"Réservation N° : {reservation.Idreservation}"));
                document.Add(new iTextSharp.text.Paragraph($"Client : {reservation.IdclientNavigation.Nom} {reservation.IdclientNavigation.Prenom}"));
                document.Add(new iTextSharp.text.Paragraph($"Date d'arrivée : {reservation.Datearrivee}"));
                document.Add(new iTextSharp.text.Paragraph($"Date de départ : {reservation.Datedepart}"));
                document.Add(new iTextSharp.text.Paragraph($"Statut : {reservation.Statut}"));

                document.Close();
            }

            return filePath;
        }
    }
}
