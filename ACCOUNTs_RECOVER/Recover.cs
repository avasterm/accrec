using System;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNTs_RECOVER
{
    public class Recover
    {
        

        public static void DO()
        {
            WebBrowser BROWSER = new WebBrowser();
            BROWSER.BrowserOpen();
            pVar.counterACCS = 0;
            
            while (pVar.counterACCS <= pVar.countALL-1)
            {
                Thread.Sleep(10000);
                pVar.currentLogin = Logins.nextLogin(pVar.counterACCS);
                xNetRequest.sendReq(pVar.mainAction, pVar.currentLogin, pVar.__cfduid, pVar.cf_clearance);
                Thread.Sleep(10000);
                if (pVar.counterERRORS <= 1)
                {
                    while (pVar.counterERRORS == 0)
                    {
                        Thread.Sleep(10000);
                        xNetRequest.sendReq(pVar.mainAction, pVar.currentLogin, pVar.__cfduid, pVar.cf_clearance);
                        Thread.Sleep(10000);
                    }
                }
            }
            
            
            
            
            
            
            //Console.WriteLine(__cfduid);
            //Console.WriteLine(cf_clearance);
            //Console.WriteLine(login);
        }
    }
}
