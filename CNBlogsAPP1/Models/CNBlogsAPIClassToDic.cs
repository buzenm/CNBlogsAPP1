using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPAPP.Models
{
    public class CNBlogsAPIClassToDic
    {
        public static Dictionary<string,string> GetToken(Client_Credentials client_Credentials)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("client_id", client_Credentials.client_id);
            result.Add("client_secret", client_Credentials.client_secret);
            result.Add("grant_type", client_Credentials.grant_type);
            return result;
        }

        public static Dictionary<string,string> GetCode(Authorize authorize)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("client_id", authorize.client_id);
            result.Add("scope", authorize.scope);
            result.Add("response_type", authorize.response_type);
            result.Add("redirect_uri", authorize.redirect_uri);
            result.Add("state", authorize.state);
            result.Add("nonce", authorize.nonce);
            return result;
        }

        public static Dictionary<string,string> GetAccess(Authorization_Code authorization_code)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("client_id", authorization_code.client_id);
            result.Add("redirect_uri", authorization_code.redirect_uri);
            result.Add("code", authorization_code.code);
            result.Add("grant_type", authorization_code.grant_type);
            result.Add("client_secret", authorization_code.client_secret);
            return result;
        }
    }

}
