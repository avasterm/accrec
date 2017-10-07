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

            pVar.currentLogin = Logins.nextLogin();
            Console.WriteLine(pVar.currentLogin + "CURRREEENT");
            xNetRequest.sendReq(pVar.mainAction, pVar.currentLogin, __cfduid, cf_clearance);
            
            
            
            //Console.WriteLine(__cfduid);
            //Console.WriteLine(cf_clearance);
            //Console.WriteLine(login);
        }
    }
}
