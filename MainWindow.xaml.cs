using CefSharp;
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

namespace AutoWrite
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string command = @"(async () =>
                                {
                                    await CefSharp.BindObjectAsync('bound', 'bound');

                                    let startRow = await bound.loadHadRow() + 1;
                                    let datas = await JSON.parse(bound.loadDatas());

                                    for (let key in datas){
                                        await $('#txtKeywords').val(key);

                                        await quickSearch();

                                        if ($('#cp_search').children('table').children('tbody').children('tr').children('td').text() != null){
                                            await $('#cp_search').children('table').children('tbody').children('tr').children('td').children('a').click();
                                        }
                                        else {
                                            await bound.notFind(key);
                                        }
                                        $('#trpx' + startRow).children('table').children('tbody').children('tr').children('td').eq(4).children().children('input').val(datas[key]);
                                    }

                                })();";
            string a = @"(async () =>
                                {
                                    await CefSharp.BindObjectAsync('bound', 'bound');

                                    let startRow = await bound.loadHadRow() + 1;
                                    let datas = await JSON.parse(bound.loadDatas());

                                    for (let key in datas){
                                        
                                            bound.notFind(key + ' = ' + datas[key]);
                                    }

                                })();";
            Browser.ChromiumWebBrowser.ExecuteScriptAsync(a);
            //Browser.ChromiumWebBrowser.ExecuteScriptAsync("var datas = JSON.parse(bound.loadDatas());");
            //Browser.ChromiumWebBrowser.ExecuteScriptAsync("task();");


        }
    }
}
