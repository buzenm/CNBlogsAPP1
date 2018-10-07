using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPAPP.Models;
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
    public sealed partial class UserPage : Page
    {
        public UserPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter is string)
            {
                Authorization_Code authorization_Code = new Authorization_Code()
                {
                    grant_type="authorization_code",
                    code=(string)(e.Parameter),
                    client_id= "f52a0cdc-479a-4613-b2fa-8afeeeb04075",
                    redirect_uri= "https://oauth.cnblos.com/auth/callback",
                    client_secret= "FxJS18UE3NgjsjqiKATnVamoX3_TFgsme6rtn0zIIAv32-wUJUI2Gdmm2KpNjAbluRG9OREVDJRnObe1"
                };
                string result = MyInternet.Post("https://oauth.cnblogs.com/connect/token", CNBlogsAPIClassToDic.GetAccess(authorization_Code));

            }
        }
    }
}
