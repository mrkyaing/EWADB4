using OfficeOpenXml;
using OfficeOpenXml.Table;

namespace CloudHRMS.Utilties
{
    public static class ReportHelper
    {
        public static byte[] ExportToExcel<T>(IList<T> table,string exportFilename)
        {
            using ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet=package.Workbook.Worksheets.Add(exportFilename);
            worksheet.Cells["A1"].LoadFromCollection(table,true,TableStyles.Light1);
            return package.GetAsByteArray();
        }
    }
}
