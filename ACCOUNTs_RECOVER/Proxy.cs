﻿using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCOUNTs_RECOVER
{
    class Proxy
    {
        public static string proxyTYPE;
        public static StreamReader sr_proxy;
        public static List<string> listProxy = new List<string>();
        public static long countProxy;
        public static string currentProxy;

        public static void chooseProxyType()
        {
            if (proxyTYPE == "none")
            {
                Console.WriteLine("NO proxy");
            }
            if (proxyTYPE == "socks5")
            {
                Console.WriteLine("SOCKS5 PROXY");
            }
            if (proxyTYPE == "https")
            {
                Console.WriteLine("HTTP proxy");
            }
        }
        public static void proxySettings()
        {
            
            if (proxyTYPE != "none")
            {
                countProxy = listProxy.LongCount();

                    // GET PROXY BY LINK
                    WebClient WebClientForProxy = new WebClient();
                    string uriString = "http://104.197.166.190/" + proxyTYPE + ".txt";
                    Stream webProxyListStream = WebClientForProxy.OpenRead(uriString);
                    sr_proxy = new StreamReader(webProxyListStream);

                    //GET PROXY FROM FILE
                    //sr_proxy = new StreamReader(@"source/proxyHttp.txt");


                    using (sr_proxy)
                    {

                        string line;
                        string proxy;
                        string proxyPat = @"^(\d{1,3}).(\d{1,3}).(\d{1,3}).(\d{1,3}):(\d{2,5})$";
                        Match m;
                        while ((line = sr_proxy.ReadLine()) != null)
                        {

                            m = Regex.Match(line, proxyPat);

                            if (m.Success)
                            {
                                proxy = Regex.Replace(line, proxyPat, "$1.$2.$3.$4:$5");
                                listProxy.Add(proxy);
                                Console.WriteLine(proxy);
                                countProxy++;

                            }

                        }
                        
                    
                    webProxyListStream.Close();

                }
               

            }
        }

        public static string nextProxy()
        {
            if (proxyTYPE != "none")
            {
                countProxy = listProxy.LongCount();
                if (countProxy == 0) { proxySettings(); }
                currentProxy = listProxy.First().ToString();
                listProxy.RemoveAt(0);
                Console.WriteLine(listProxy.Count());
                Console.WriteLine(currentProxy + "_THIS");
                return currentProxy;
            }
            else
            {
                return "";
            }
        }

    }
}