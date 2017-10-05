using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACCOUNTs_RECOVER
{
   public class setRequest
    {
        public void SendSet()
        {
            try
            {

                var cookieContainer = new CookieContainer();

                var handler = new HttpClientHandler();


                handler.CookieContainer = cookieContainer;
                cookieContainer.Add(new Cookie("__cfduid", "dcd16ad5ba34cf8f02a2ce19ac196ad351507229846"));
                HttpClient client = new HttpClient(handler);







                client.BaseAddress = new Uri("https://account.leagueoflegends.com/recover/username");

                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
                request.Content = new StringContent("email=avasterm%40gmail.com",
                                                    Encoding.UTF8,
                                                    "application/json");//CONTENT-TYPE header

                client.SendAsync(request)
                      .ContinueWith(responseTask =>
                      {
                          Console.WriteLine("Response: {0}", responseTask.Result);
                      });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
