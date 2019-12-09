using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using mshtml;

namespace AutoWrite
{
    /// <summary>
    /// WebBroswerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WebBroswerWindow : Window
    {
        public WebBroswerWindow()
        {
            InitializeComponent();
            
        }
        public void loadForm(string url)
        {
            browser.Navigate("http://60.191.121.74:85/SYSN/view/init/login.ashx?id2=20");
            browser.LoadCompleted += new LoadCompletedEventHandler(a);
            

        }
        private void a(object sender, NavigationEventArgs e)
        {

            //HtmlDocument doc = (HtmlDocument) browser.Document;
            //string value = doc.GetElementById("kw").InnerHtml;
            //Console.WriteLine(value);
            IHTMLDocument2 doc = browser.Document as IHTMLDocument2;
            //mshtml.IHTMLElementCollection inputs;
            //inputs = (mshtml.IHTMLElementCollection)doc.all.tags("input");
            //mshtml.IHTMLElement element = (mshtml.IHTMLElement)inputs.item("kw");
            //mshtml.IHTMLInputElement inputElement = (mshtml.IHTMLInputElement)element;
            //inputElement.value = "填充信息";
            //doc.all.item("kw").value = "123";
            doc.all.item("xcode").value = "103";
            while ((doc.all.item("xcode").value == null) || doc.all.item("xcode").value.Length < 4) ;
            doc.all.item("login").click();
        }
    }
}
