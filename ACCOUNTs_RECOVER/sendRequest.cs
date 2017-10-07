using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace ACCOUNTs_RECOVER
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class JsonS
    {
        public bool Success { get; set; }
        public string message { get; set; }
    }

    public class sendRequest
    {
        public string endPoint { get; set; }
        public string Url { get; set; }
        public string data { get; set; }
        public httpVerb httpMetHod { get; set; }
        public string responseFromServer { get; set; }
        public void sendReq(string action, string LoginEmail, string __cfduid, string cf_clearance)
        {
            if (action == "PASS")
            {
                Url = "https://account.leagueoflegends.com/recover/password";
                data = "accountname=" + LoginEmail;
            }

            try
            {

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] sentData = utf8.GetBytes(data.ToString());
                req.Headers.Clear();
                req.Method = "POST";
                req.Host = "account.leagueoflegends.com";
                req.KeepAlive = true;
                req.ContentLength = sentData.Length;
                req.Accept = "application/json, text/javascript, */*; q=0.01";
                req.Headers.Add("X-NewRelic-ID", "UA4OVVRUGwEDVllXDgA=");
                req.Headers.Add("Origin", "https://account.leagueoflegends.com");
                req.Headers.Add("X-Requested-With", "XMLHttpRequest");
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
                req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                req.Referer = "https://account.leagueoflegends.com/pm.html?xdm_e=https%3A%2F%2Faccount.leagueoflegends.com%2Fna%2Fen%2Fforgot-password&xdm_c=default3177&xdm_p=4";
                req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                req.Headers.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
                req.Headers.Add("Cookie", "__cfduid="+ __cfduid+"; cf_clearance="+ cf_clearance+"; PVPNET_LANG=en_US; PVPNET_REGION=na;");
                req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;



                // Get the request stream.  
                Stream dataStream = req.GetRequestStream();
                // Write the data to the request stream.  
                dataStream.Write(sentData, 0, sentData.Length);
                // Close the Stream object.  
                // dataStream.Close();
                // Get the response.  
                WebResponse response = req.GetResponse();
                // Display the status.  
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.  
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.  
                StreamReader reader = new StreamReader(dataStream, utf8);
                // Read the content.  
                responseFromServer = reader.ReadToEnd();
                JsonS jsons = JsonConvert.DeserializeObject<JsonS>(responseFromServer);
                Console.WriteLine(jsons.Success);
                MainWindow main = new MainWindow();
                main.showResult(jsons.Success);
                //   var serializer = new JavaScriptSerializer();
                //  var result = serializer.DeserializeObject(dataStream);

                // Display the content.  
                Console.WriteLine(responseFromServer);
                // Clean up the streams.  
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


    }
}