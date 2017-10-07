using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNTs_RECOVER
{
    public class Logins
    {
        public static void Load()
        {
            pVar.sr_logins = new StreamReader(@"logins.txt");

            using (pVar.sr_logins)
            {

                string line;
                string login;
                while ((line = pVar.sr_logins.ReadLine()) != null)
                {

                        login = line;
                        pVar.listLogins.Add(login);
                       // Console.WriteLine(login);
                        pVar.countLogins++;
                }
            }
        }

        public static string nextLogin()
        {
            pVar.countLogins = pVar.listLogins.LongCount();
            if (pVar.countLogins != 0)
            {
                pVar.currentLogin = pVar.listLogins.First().ToString();
                pVar.listLogins.RemoveAt(0);
            //   Console.WriteLine(pVar.listLogins.Count() + " LOGINS");
            //    Console.WriteLine(pVar.currentLogin + " CURRENT LOGIN");
                return pVar.currentLogin;
            }
            else
            {
                return "";
            }
        }
    }
}
