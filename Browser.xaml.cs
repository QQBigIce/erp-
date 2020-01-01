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
using CefSharp;
using mshtml;

namespace AutoWrite
{
    /// <summary>
    /// Browser.xaml 的交互逻辑
    /// </summary>
    public partial class Browser : Page
    {
        public Browser()
        {
            InitializeComponent();
            bw1.LifeSpanHandler = new DoExcel() as ILifeSpanHandler;
        }
        public void LoadForm()
        {
            //bw1.LoadCompleted += Browser_LoadCompleted;
            string a = "$(function () {f('https://cdn.bootcss.com/tesseract.js/2.0.0-alpha.2/tesseract.min.js');$('#username').val('123');$('#password').val('888888');var img = $('#codes').attr('src');Tesseract.recognize(img, {classify_bln_numeric_mode: 1}).then(function(result) {alert(result);});});function f(s){ var script = document.createElement('script');script.type = 'text/javascript';script.src = s;document.getElementsByTagName('head')[0].appendChild(script);}";
            //bw1.ExecuteScriptAsyncWhenPageLoaded("$('#username').val('123');");
            //bw1.ExecuteScriptAsyncWhenPageLoaded("$('#password').val('888888');");
            
            //bw1.LoadingStateChanged += Bw1_LoadingStateChanged;
            //bw1.FrameLoadEnd += Bw1_FrameLoadEnd;

        }

        //    private void Bw1_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        //    {
        //        if (e.Frame.IsMain)
        //        {
        //            e.Frame.ExecuteJavaScriptAsync("alert('MainFrame finished loading');");
        //        }
        //    }

        //    private void Bw1_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        //    {
        //        if (e.IsLoading == false)
        //        {
        //            bw1.ExecuteScriptAsync("alert('All Resources Have Loaded');");
        //        }
        //    }

        //    private void Browser_LoadCompleted(object sender, NavigationEventArgs e)
        //    {
        //        //throw new NotImplementedException();
        //        IHTMLDocument2 doc = (IHTMLDocument2)bw1;
        //        doc.all.item("logo").click();
        //    }
        //}

        //internal class RenderProcessMessageHandler : IRenderProcessMessageHandler
        //{
        //    public void OnContextCreated(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        //    {
        //        const string script = "alert('1');";

        //        frame.ExecuteJavaScriptAsync(script);
        //    }

        //    public void OnContextReleased(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void OnFocusedNodeChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IDomNode node)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void OnUncaughtException(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, JavascriptException exception)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
