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


namespace AutoWrite
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        private DoExcel doExcel;
        public Home()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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
            foreach (var item in this.doExcel.Datas)
            {
                this.@out.AppendText(item.pid + " + " + item.num + "\n");
            }
            Browser bw = new Browser();
            bw.Show();
            Thread.Sleep(500);
            bw.loadForm();
            
        }
    }
}
