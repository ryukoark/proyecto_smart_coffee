namespace smartcoffe.Domain.Interfaces
{
    public interface IExcelService
    {
        byte[] CreateExcel(string sheetName, List<string> headers, List<List<object>> rows);
    }
}