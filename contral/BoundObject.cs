using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OfficeOpenXml;

namespace AutoWrite.contral
{
    public class BoundObject
    {
        private Page mainWindow { get; set; }
        public BoundObject(Page _mainWindow)
        {
            mainWindow = _mainWindow;
        }

        /// <summary>
        /// 打开exe文件
        /// </summary>
        public string OpenFile()
        {
            return "hello";
        }
    }
}
