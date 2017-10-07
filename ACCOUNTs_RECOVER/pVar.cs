using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNTs_RECOVER
{
   public static class pVar
    {
        public static int countGOOD;
        public static int countBAD;
        public static int countERROR;
        public static string __cfduid;
        public static string cf_clearance;
        public static StreamReader sr_logins;
        public static List<string> listLogins = new List<string>();
        public static long countLogins;
        public static string currentLogin;
    }
}
