using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetwork
{
    class ExcelExport
    {
        private List<CustomConnection> list;
        private string[] columns;
        private Dictionary<int, string> columnsEng;

        public ExcelExport(List<CustomConnection> list)
        {
            this.list = list;
            columns = new string[] {"Номер запроса", "Длительность", "Ошибка (если есть)"};
            columnsEng = new Dictionary<int, string>()
            {
                //{ 1, "timePlanningStart" },
                //{ 2, "timeFactStart" },
                { 1, "durationConnection" },
                { 2, "errorText" }
            };
        }

        public int Export()
        {
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            int result = 0;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < columns.Length; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = columns[j];
                        }
                        else
                        {
                            var item = list.ElementAt(i).GetResult();
                            var dictionaryFromObj = ParseObj.ToDictionary(item);

                            if (j == 0)
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = i;
                            else
                            {
                                var valueCell = dictionaryFromObj[columnsEng[j]];
                                //string strValue = valueCell.ToString();

                                /*if (valueCell.GetType() == typeof(TimeSpan))
                                {
                                    strValue = TimeSpan.Parse(valueCell.ToString()).ToString("hh':'mm':'ss'.'fff");
                                    Console.WriteLine("timespan: {0}", strValue.ToString());
                                }*/

                                worksheet.Cells[cellRowIndex, cellColumnIndex] = valueCell;
                            }
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                workbook.SaveAs("exportList.xlsx");
                Console.WriteLine("export success");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
                result = 1;
            }

            return result;
        }
    }
}
