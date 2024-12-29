using ClosedXML.Excel;
using Management_Hotel.Models;
using System.Collections.Generic;
using System.IO;

namespace Hotel_Management.Services
{
    public class ExportService
    {
        public string ExportToExcel<T>(IEnumerable<T> data, string sheetName)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(sheetName);

            // Get properties of type T
            var properties = typeof(T).GetProperties();

            // Add headers
            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = properties[i].Name;
            }

            // Add data
            int row = 2;
            foreach (var item in data)
            {
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cell(row, i + 1).Value =
                        properties[i].GetValue(item)?.ToString() ?? "";
                }
                row++;
            }

            string fileName = $"Export_{sheetName}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName);

            workbook.SaveAs(filePath);
            return filePath;
        }
    }
}
