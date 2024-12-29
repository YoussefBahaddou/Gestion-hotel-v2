using Management_Hotel.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace Hotel_Management.Services
{
    public class ReportService
    {
        public string GenerateMonthlyReport(DateTime month)
        {
            var fileName = $"Rapport_Mensuel_{month:yyyyMM}.pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                document.Open();
                document.Add(new Paragraph($"Rapport Mensuel - {month:MMMM yyyy}"));
                document.Add(new Paragraph("--------------------------------"));

                // Add report sections
                AddReservationStatistics(document, month);
                AddFinancialStatistics(document, month);
                AddOccupancyStatistics(document, month);

                document.Close();
            }

            return filePath;
        }

        private void AddReservationStatistics(Document document, DateTime month)
        {
            // Implementation of reservation statistics
        }

        private void AddFinancialStatistics(Document document, DateTime month)
        {
            // Implementation of financial statistics
        }

        private void AddOccupancyStatistics(Document document, DateTime month)
        {
            // Implementation of occupancy statistics
        }
    }
}
