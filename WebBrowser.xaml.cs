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
using mshtml;


namespace AutoWrite
{
    /// <summary>
    /// WebBrowser.xaml 的交互逻辑
    /// </summary>
    public partial class WebBrowser : Page
    {
        public WebBrowser()
        {
            this.LoadForm();

        }
        private void LoadForm()
        {
            this.wbbrowser.Navigate("https://how2j.cn/tmall/forecategory?cid=72&sort=all");
            wbbrowser.LoadCompleted += Browser_LoadCompleted;
        }

        private void Browser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            //throw new NotImplementedException();
            IHTMLDocument2 doc = (IHTMLDocument2)wbbrowser.Document;
            doc.all.item("logo").click();
        }
    }
}
