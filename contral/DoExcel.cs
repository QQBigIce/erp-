using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace AutoWrite.contral
{

    class DoExcel
    {
        public DoExcel()
        {

        }

        public DoExcel(char col, int row)
        {
            this.Col = (int)(char.ToUpper(col)) - 64;
            this.Row = row;


        }

        public DoExcel(string fileName, char col, int row) : this(col, row)
        {
            this.FileName = fileName;
        }

        public int Col { get; set; }
        public int Row { get; set; }
        public string FileName { get; set; }
        internal Dictionary<string, string> Datas { get; set; }

        public void FormLoad()
        {
            FileInfo file = new FileInfo(FileName);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets[1];
                for (int i = this.Row; i < ws.AutoFilterAddress.End.Row; i++)
                {
                    if (ws.Cells[i, Col + 1].Value != null) 
                    {
                        string k = ws.Cells[i, Col + 1].Value.ToString();
                        string v = ws.Cells[i, Col + 5].Value.ToString();
                        //Data data = new Data(ws.Cells[i, Col + 1].Value.ToString(), ws.Cells[i, Col + 5].Value.ToString());
                        this.Datas[k] = v;
                    }     
                }
                
            }
        }
    }
}
