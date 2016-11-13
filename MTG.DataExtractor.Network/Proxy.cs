using System;
using System.Net;

namespace MTG.DataExtractor.Network
{
    public class Proxy
    {

        public static string URL = string.Empty;
        public static string Port = string.Empty;
        public static string Login = string.Empty;
        public static string Password = string.Empty;

        public static bool Valid()
        {
            return URL.Length > 0;
        }

        public static WebProxy GetProxy()
        {
            if (Valid())
            {
                WebProxy myProxy = new WebProxy();
                string myURL = Port.Length > 0 ? URL + ":" + Port : URL;
                if (!myURL.StartsWith("http://"))
                {
                    myURL = "http://" + myURL;
                }
                myProxy.Address = new Uri(myURL);
                if (Login.Length > 0 && Password.Length > 0)
                {
                    myProxy.Credentials = new NetworkCredential(Login, Password);
                }
                return myProxy;
            }
            else
            {
                return null;
            }
        }

    }
}
