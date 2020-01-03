using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace AutoWrite.contral
{
    public class BoundObject
    {
        public BoundObject()
        {
            ;
        }

        /// <summary>
        /// 打开exe文件
        /// </summary>
        public string LoadDatas()
        {
            Dictionary<string, string> dict = DoExcel.Datas;
            string datas = JsonConvert.SerializeObject(dict);
            return datas;
        }
        public int LoadHadRow()
        {
            return 2;
        }

        public void NotFind(string id)
        {
            App.Current.Dispatcher.Invoke((Action)delegate ()
            {
                Home.Output.AppendText(id + "未在ERP里面找到\n");
            });
        }

    }
}
