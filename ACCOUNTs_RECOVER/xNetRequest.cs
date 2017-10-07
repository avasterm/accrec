using System;
using System.IO;
using xNet;
using Newtonsoft.Json;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using System.Text;

namespace ACCOUNTs_RECOVER
{
    public class JsonS
    {
        public bool Success { get; set; }
        public string message { get; set; }
    }
    public class xNetRequest
    {
        MainWindow main = new MainWindow();
        public string result { get; set; }
        string response { get; set; }
        public ProxyClient proxyClient { get; set; }
        public Uri uri { get; set; }
        public string paramReq { get; set; }
        
        public void sendReq(string action, string LoginEmail, string __cfduid, string cf_clearance)
        {
            if (action == "LOGIN")
            {
                paramReq = "accountname";
                uri = new Uri("https://account.leagueoflegends.com/recover/password");
            }
            else if(action == "EMAIL")
            {
                paramReq = "email";
                uri = new Uri("https://account.leagueoflegends.com/recover/username");
            }



            if (mProxy.proxyTYPE != "none")
            {
                string[] proxy = mProxy.currentProxy.Split(':');

                if (pVar.proxTyp == ProxyType.Http)
                    proxyClient = new HttpProxyClient(proxy[0], Convert.ToInt32(proxy[1]));
                else if (pVar.proxTyp == ProxyType.Socks4)
                    proxyClient = new Socks4ProxyClient(proxy[0], Convert.ToInt32(proxy[1]));
                else if (pVar.proxTyp == ProxyType.Socks5)
                    proxyClient = new Socks5ProxyClient(proxy[0], Convert.ToInt32(proxy[1]));
            }

            try
            {
                //Thread.Sleep(5000);
                using (var request = new HttpRequest())
                {
                    if (mProxy.proxyTYPE != "none") request.Proxy = proxyClient;

                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
                    request.KeepAlive = true;
                    request
                        .AddParam(paramReq, LoginEmail)


                        .AddHeader(HttpHeader.Referer, "https://account.leagueoflegends.com/pm.html?xdm_e=https%3A%2F%2Faccount.leagueoflegends.com%2Fna%2Fen%2Fforgot-password&xdm_c=default3177&xdm_p=4")
                        .AddHeader(HttpHeader.Accept, "application/json, text/javascript, */*; q=0.01")
                        .AddHeader("X-NewRelic-ID", "UA4OVVRUGwEDVllXDgA=")
                        .AddHeader("Origin", "https://account.leagueoflegends.com")
                        .AddHeader("X-Requested-With", "XMLHttpRequest")
                        .AddHeader(HttpHeader.ContentType, "application/x-www-form-urlencoded")
                        .AddHeader(HttpHeader.ContentEncoding, "gzip, deflate, br")
                        .AddHeader(HttpHeader.AcceptLanguage, "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");

                    request.Cookies = new CookieDictionary()
                      {
                            {"__cfduid", __cfduid},
                            {"cf_clearance",cf_clearance},
                            {"PVPNET_LANG","en_US"},
                            {"PVPNET_REGION","na"}
                        };

                    request.Cookies.IsLocked = true;
                    Console.WriteLine(request.Cookies);
                    result = request.Post("https://account.leagueoflegends.com/recover/username").ToString();

                    //Console.WriteLine(result);

                    //Console.WriteLine(response);
                    JsonS jsons = JsonConvert.DeserializeObject<JsonS>(result);

                    main.showResult(jsons.Success);

                    Console.WriteLine("RESULT: " + jsons.Success);
                    Console.WriteLine(jsons.message);

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); result = "lose"; }
        }
    }
}
