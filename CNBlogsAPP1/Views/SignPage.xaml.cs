using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace UWPAPP.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SignPage : Page
    {
        public static SignPage current = null;
        public SignPage()
        {
            
            this.InitializeComponent();
            current = this;
        }

        public static string code = "";
        private void SignWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (sender.Source.ToString().Contains("callback"))
            {
                string[] strs = sender.Source.OriginalString.Split('&');
                string[] strs2 = strs[0].Split('=');
                code = strs2[1];
                MainPage.current.ContentFrame.Navigate(typeof(UserPage), strs2[1]);

            }
        }
    }
}
