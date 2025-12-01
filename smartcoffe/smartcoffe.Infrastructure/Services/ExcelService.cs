using ClosedXML.Excel;
using smartcoffe.Domain.Interfaces;

namespace smartcoffe.Infrastructure.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] CreateExcel(string sheetName, List<string> headers, List<List<object>> rows)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.AddWorksheet(sheetName);

            // Insert headers
            for (int i = 0; i < headers.Count; i++)
                ws.Cell(1, i + 1).Value = headers[i];

            // Insert rows
            for (int r = 0; r < rows.Count; r++)
            {
                for (int c = 0; c < rows[r].Count; c++)
                {
                    var value = rows[r][c] ?? "";
                    ws.Cell(r + 2, c + 1).Value = value.ToString();
                }
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}