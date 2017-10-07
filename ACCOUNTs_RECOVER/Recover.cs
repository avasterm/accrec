using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNTs_RECOVER
{
    public class Recover
    {
        WebBrowser BROWSER = new WebBrowser();

        public static void DO(string __cfduid, string cf_clearance)
        {
            string login = Logins.nextLogin();
            Console.WriteLine(__cfduid);
            Console.WriteLine(cf_clearance);
            Console.WriteLine(login);
            sendRequest REQ = new sendRequest();
            REQ.sendReq("PASS", login, __cfduid, cf_clearance);
        }
        public void PASS ()
        {
            BROWSER.BrowserOpen();
        }
    }
}
