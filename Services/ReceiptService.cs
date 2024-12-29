using iTextSharp.text;
using iTextSharp.text.pdf;
using Management_Hotel.Models;
using System.IO;

namespace Hotel_Management.Services
{
    public class ReceiptService
    {
        public string GenerateReceipt(Paiement payment)
        {
            var fileName = $"Recu_Paiement_{payment.Idpaiement}.pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Receipts", fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                document.Open();

                // Add header
                document.Add(new Paragraph("REÇU DE PAIEMENT"));
                document.Add(new Paragraph("---------------------------"));

                // Add payment details
                document.Add(new Paragraph($"N° de paiement : {payment.Idpaiement}"));
                document.Add(new Paragraph($"Réservation : {payment.Idreservation}"));
                document.Add(new Paragraph($"Client : {payment.IdreservationNavigation.IdclientNavigation.Nom}"));
                document.Add(new Paragraph($"Date : {payment.Datepaiement}"));
                document.Add(new Paragraph($"Montant : {payment.Montant:C}"));
                //document.Add(new Paragraph($"Mode de paiement : {payment.Modepaiement}"));

                document.Close();
            }

            return filePath;
        }
    }
}
