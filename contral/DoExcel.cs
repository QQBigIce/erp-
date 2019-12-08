using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace AutoWrite.contral
{
    struct Data
    {

        public string pid;
        public string num;

        public Data(string pid, string num)
        {
            this.pid = pid;
            this.num = num;
        }
    }
    class DoExcel
    {
        private string fileName;
        private int col;
        private int row;
        private List<Data> datas;

        public DoExcel()
        {
        }

        public DoExcel(char col, int row)
        {
            this.col = (int)(char.ToUpper(col)) - 64;
            this.row = row;


        }

        public DoExcel(string fileName, char col, int row) : this(col, row)
        {
            this.fileName = fileName;
        }

        public int Col { get => col; set => col = value; }
        public int Row { get => row; set => row = value; }
        public string FileName { get => fileName; set => fileName = value; }
        internal List<Data> Datas { get => datas; set => datas = value; }

        public void FormLoad()
        {
            FileInfo file = new FileInfo(fileName);
            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                this.Datas = new List<Data>();
                ExcelWorksheet ws = excelPackage.Workbook.Worksheets[1];
                for (int i = this.row; ws.Cells[i, col].Value != null; i++)
                {
                    if (ws.Cells[i, col + 1].Value != null) 
                    {
                        Data data = new Data(ws.Cells[i, col + 1].Value.ToString(), ws.Cells[i, col + 5].Value.ToString());
                        this.Datas.Add(data);
                    }
                        
                        
                }
                
            }
        }
    }
}
