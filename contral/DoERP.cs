using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using CefSharp;
using CefSharp.Wpf;

namespace AutoWrite.contral
{
    public class DoERP : ILifeSpanHandler
    {
        /// < 摘要 >
        ///在创建弹出窗口之前调用。
        /// </ 摘要 >
        /// < param  name = “ browserControl ” > < 请参见 cref = “ IWebBrowser ” />控制此请求。</ param >
        /// < param  name = “ browser ” >启动此弹出窗口的浏览器实例。</ param >
        /// < param  name = “ frame ” >启动此弹出窗口的HTML框架。</ param >
        /// < 参数 名称 = “ targetUrl ” >弹出内容的URL。（可能为空/空）</ param >
        /// < 参数 名称 = “ targetFrameName ” >弹出窗口的名称。（可能为空/空）</ param >
        /// < param  name = “ targetDisposition ” >该值指示用户打算在哪里
        ///打开弹出窗口（例如当前选项卡，新选项卡等）</ param >
        /// < param  name = “ userGesture ” >如果通过显式用户手势打开弹出窗口，则该值为true
        ///（例如，单击链接）；如果弹出窗口是自动打开的（例如，通过DomContentLoaded事件），则返回false。</ param >
        /// < param  name = “ windowInfo ” >窗口信息</ param >
        /// < 参数 名 = “ noJavascriptAccess ” >值指示新的浏览器窗口是否应可编写脚本
        ///并与源浏览器相同。</ param >
        /// < param  name = “ newBrowser ” > EXPERIMENTAL-一个新创建的浏览器，将托管弹出窗口</ param >
        /// < 返回 >要取消弹出窗口回到真正的创造否则返回false。</ 回报 >
        /// < 备注 >
        /// CEF文档：
        /// 
        ///在创建新的弹出窗口之前在IO线程上调用。|浏览器|
        ///和| frame | 参数代表弹出请求的来源。的
        /// | target_url | 和| target_frame_name | 如果没有值则为空
        ///与请求一起指定。| popupFeatures | 结构包含
        ///有关请求的弹出窗口的信息。为了允许创建
        ///弹出窗口可以选择修改| windowInfo |，| client |，| settings | 和
        /// | no_javascript_access | 并返回false。取消创建弹出窗口
        ///窗口返回true。|客户端| 和|设置| 值将默认为
        ///源浏览器的值。| no_javascript_access | 值指示是否
        ///新的浏览器窗口应可编写脚本，并且与
        ///源浏览器。
        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            browserControl.Load(targetUrl);
            return true;
        }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
            if (!browser.IsDisposed && browser.IsPopup)
            {
                //DevTools is hosted in it's own popup, we don't perform any action here
                if (!browser.MainFrame.Url.Equals("devtools://devtools/devtools_app.html"))
                {
                    var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

                    chromiumWebBrowser.Dispatcher.Invoke(() =>
                    {
                        var owner = Window.GetWindow(chromiumWebBrowser);

                        if (owner != null && owner.Content == browserControl)
                        {
                            owner.Show();
                        }
                    });
                }
            }
        }

        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
            if (!browser.IsDisposed && browser.IsPopup)
            {
                //DevTools is hosted in it's own popup, we don't perform any action here
                if (!browser.MainFrame.Url.Equals("devtools://devtools/devtools_app.html"))
                {
                    var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

                    chromiumWebBrowser.Dispatcher.Invoke(() =>
                    {
                        var owner = Window.GetWindow(chromiumWebBrowser);

                        if (owner != null && owner.Content == browserControl)
                        {
                            owner.Close();
                        }
                    });
                }
            }
        }
    }
}
