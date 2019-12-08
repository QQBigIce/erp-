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
    /// WebBrowser.xaml 的交互逻辑
    /// </summary>
    public partial class WebBrowser : Page
    {
        public WebBrowser()
        {
            InitializeComponent();
            this.loadForm();

        }
        private void loadForm()
        {
            this.browser.Navigate("http://60.191.121.74:85/SYSN/view/init/login.ashx?id2=20");
            HtmlDocument document = null;
            while (!this.browser.IsLoaded)
            {
                ;
            }
            document = (HtmlDocument)this.browser.Document;

            if (document != null)
            {
                //document.GetElementById("username").InnerHtml("sj");
            }
        }
    }
}
