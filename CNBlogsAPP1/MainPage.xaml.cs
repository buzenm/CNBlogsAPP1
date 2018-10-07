using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPAPP.Models;
using UWPAPP.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace UWPAPP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage current = null;
        public MainPage()
        {
            this.InitializeComponent();
            current = this;
        }

        private void UserAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            //HttpClient httpClient = new HttpClient();
            Uri uri1 = new Uri("https://oauth.cnblogs.com/connect/token");
            //HttpWebRequest httpWebRequest = null;
            //httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;
            //httpWebRequest.Method = "POST";
            Client_Credentials client_Credentials = new Client_Credentials() {client_id= "f52a0cdc-479a-4613-b2fa-8afeeeb04075",
            client_secret= "FxJS18UE3NgjsjqiKATnVamoX3_TFgsme6rtn0zIIAv32-wUJUI2Gdmm2KpNjAbluRG9OREVDJRnObe1",grant_type= "client_credentials"};
            string token = MyInternet.Post(uri1.ToString(), CNBlogsAPIClassToDic.GetToken((client_Credentials)));

            Uri uri2 = new Uri("https://oauth.cnblogs.com/connect/authorize");
            string[] str = token.Split(':');
            Authorize authorize = new Authorize() { client_id = "f52a0cdc-479a-4613-b2fa-8afeeeb04075",
                scope = "openid profile CnBlogsApi",
                response_type = "code id_token",
                redirect_uri = "https://oauth.cnblogs.com/auth/callback",
                state = "cnblogs.com",
                nonce = "cnblogs.com"
            };

            string loginUri = MyInternet.Get(uri2.ToString(), CNBlogsAPIClassToDic.GetCode(authorize));
            ContentFrame.Navigate(typeof(SignPage));
            SignPage.current.SignWebView.Navigate(new Uri(loginUri));
            

        }
    }
}
