using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeOpenXml;
namespace Entities.BaseModels
{
    public class ExcelFileReader
    {


        public static List<DataFromExcelFile> ExcelData { get; set; } = new List<DataFromExcelFile>();

        public static FileInfo File { get; set; } = new FileInfo(@"C:\Users\DIXIE\Desktop\Accountslog.xlsx");
        public static ExcelPackage Package { get; set; } = new ExcelPackage(File);
        public static ExcelWorksheet Worksheet { get; set; }

        public  List<DataFromExcelFile> GetDataFromExel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Worksheet = Package.Workbook.Worksheets.FirstOrDefault();
            if (Worksheet == null) return new List<DataFromExcelFile>();
            for (int i = 2; i < 13; i++)
            {
                DataFromExcelFile data = new DataFromExcelFile();
                data.Name = Worksheet.Cells[i, 1].Value.ToString();
                data.UserId = Worksheet.Cells[i, 2].Value.ToString();
                data.Amount = Worksheet.Cells[i, 3].Value.ToString();
                data.PhoneNumber = Worksheet.Cells[i, 4].Value.ToString();
                ExcelData.Add(data);
            }
            return ExcelData;

        }
    }
}
