using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Qoollo.Turbo.Threading.ThreadPools;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNTs_RECOVER
{
    public class Recover
    {
     
        public static void RunThreads(Action work)
        {
           
            var _settings_pool = new DynamicThreadPoolOptions().UseOwnTaskScheduler;
            var _threadPool = new DynamicThreadPool(2, 2, "threads");
            for (var i = 0; i < 2; i++)
                
                _threadPool.Run(work);
        }

        public static void Run(Action work)
        {
            RunThreads(work);
        }


        public static void DO()
        {
            WebBrowser BROWSER = new WebBrowser();
            BROWSER.BrowserOpen();
            pVar.counterACCS = 0;
            
             while (pVar.counterACCS <= pVar.countALL-1)
            {
                //Thread.Sleep(10000);
                pVar.currentLogin = Logins.nextLogin(pVar.counterACCS);
                xNetRequest.sendReq(pVar.mainAction, pVar.currentLogin, pVar.__cfduid, pVar.cf_clearance);
               // Thread.Sleep(10000);
                if (pVar.counterERRORS <= 1)
                {
                    while (pVar.counterERRORS == 0)
                    {
                        //Thread.Sleep(10000);
                        xNetRequest.sendReq(pVar.mainAction, pVar.currentLogin, pVar.__cfduid, pVar.cf_clearance);
                        //Thread.Sleep(10000);
                    }
                }
            }
            
            
            
            
            
            
            //Console.WriteLine(__cfduid);
            //Console.WriteLine(cf_clearance);
            //Console.WriteLine(login);
        }
    }
}
