using OfficeOpenXml;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace CorcoranExercise.Models
{
    public class PresidentServiceContext
    {
        public DataSet DtSet;
        OleDbConnection MyConnection;
        OleDbDataAdapter MyCommand;

        static string FilePath = HostingEnvironment.ApplicationPhysicalPath + "\\Utilities\\Presidents.xlsx";

        public PresidentServiceContext()
        {
            DtSet = new DataSet();

            DtSet.Tables.Add(GetDataTableFromExcel(FilePath));
        }

        private static DataTable GetDataTableFromExcel(string filePath, bool hasHeader = true)
        {
            using (var package = new ExcelPackage())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    package.Load(stream);
                }

                var workSheet = package.Workbook.Worksheets.First();
                DataTable dt = new DataTable();

                foreach (var firstRowCell in workSheet.Cells[1, 1, 1, 5])
                {
                    dt.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= 45; rowNum++)
                {
                    var wsRow = workSheet.Cells[rowNum, 1, rowNum, 5];
                    DataRow row = dt.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return dt;
            }
        }
    }
}