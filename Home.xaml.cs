using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoWrite.contral;
using System.Threading;
using CefSharp.Wpf;
using System.Runtime.InteropServices;

namespace AutoWrite
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        public static TextBox Output { get; set; }


        private DoExcel doExcel;
        public Home()
        {
            
            InitializeComponent();
            Output = this.outBox;
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "XLSX (.xlsx)|*.xlsx|All files (*.*)|*.*"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var file = openFileDialog.FileName;
                this.fileText.Text = file;
            }

        }



        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.doExcel = new DoExcel(this.fileText.Text, this.col.Text.ToCharArray()[0], Convert.ToInt32(this.row.Text));
            this.doExcel.FormLoad();
            foreach (KeyValuePair<string, string> item in DoExcel.Datas)
            {
                this.outBox.AppendText(item.Key + " = " + item.Value + "\n");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //// 获得计算器的句柄
            //IntPtr hwnd = FindWindow(null, "计算器");
            //// 如果句柄不为空
            //if (hwnd != IntPtr.Zero)
            //{

            //    IntPtr hwnd1 = FindWindowEx(hwnd, 0x0009037E, "CalcFrame", ""); //获取 的句柄
            //    if (hwnd1 != IntPtr.Zero)
            //    {
            //        IntPtr hwnd12 = FindWindowEx(hwnd1, 0, "#32770", ""); //获取 的句柄
                    
            //        if (hwnd12 != IntPtr.Zero)
            //        {
            //            IntPtr hwnd123 = FindWindowEx(hwnd12, 0x100a88, "Static", null); //获取 的句柄
            //            if (hwnd123 != IntPtr.Zero)
            //            {
            //                StringBuilder strB = new StringBuilder(100);
            //                SendMessage(hwnd123, WM_GETTEXT, new IntPtr(255), strB);
            //                string a = strB.ToString().Trim();
            //                MessageBox.Show(a);
            //            }
            //        }
            //    }
            //}
        }
    }
}
