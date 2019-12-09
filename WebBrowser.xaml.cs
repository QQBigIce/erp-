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
using System.Windows.Forms;


namespace AutoWrite
{
    /// <summary>
    /// WebBrowserPage.xaml 的交互逻辑
    /// </summary>
    public partial class WebBrowserPage : Page
    {
        public WebBrowserPage()
        {
            InitializeComponent();
            
        }

        public System.Windows.Controls.WebBrowser Browser { get => wbrowser; set => wbrowser = value; }

        public void loadForm(string url)
        {
            this.wbrowser.Navigate(url);
            HtmlDocument document = null;
            
            document = (HtmlDocument)this.wbrowser.Document;
            // 当文档对象不为空
            if (document != null)
            {
                //document.GetElementById("username").InnerHtml("sj");
            }
        }
    }
}
