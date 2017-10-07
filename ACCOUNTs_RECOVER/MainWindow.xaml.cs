using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebBrowser BROWSER = new WebBrowser();
        public MainWindow()
        {
           InitializeComponent();
            pVar.countGOOD = 0;
            pVar.countBAD = 0;
            pVar.countERROR = 0;
        }
       
        private void btnStartCLICK(object sender, RoutedEventArgs e)
        {
            

            checkProxyTYPE();
            Logins.Load();
            BROWSER.BrowserOpen();
        }

        public void checkProxyTYPE()
        {
            //Proxy PROXY = new Proxy();
            if (checkSOCKS5.IsChecked == false && checkHTTP.IsChecked == false)
            {
                Proxy.proxyTYPE = "none";
            }
            else
            {
                if (checkSOCKS5.IsChecked == true)
                {
                    Proxy.proxyTYPE = "socks5";
                }
                if (checkHTTP.IsChecked == true)
                {
                    Proxy.proxyTYPE = "https";
                }
            }
        
        }

        public void showResult(bool Success)
        {
            string status = "";

            if (Success == true)
            {
                pVar.countGOOD++;
                countGood.Content = pVar.countGOOD.ToString();
                status = "GOOD";
            }
            else if (Success == false)
            {
                pVar.countBAD++;
                countBad.Content = pVar.countBAD.ToString();
                status = "BAD";
            }
            else
            {
                pVar.countERROR++;
                countErrors.Content = pVar.countERROR.ToString();
                status = "ERROR";
            }

            writeLineToFile(status, pVar.currentLogin);
        }

        private void writeLineToFile(string status, string line)
        {

            string file_src = status+".txt";

            using (System.IO.StreamWriter file =
               new System.IO.StreamWriter(file_src, true))
            {
                file.WriteLine(line);
            }

        }
    }


}
