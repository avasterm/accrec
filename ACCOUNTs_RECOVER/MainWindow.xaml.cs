using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using xNet;
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
            Logins.Load();
           // mProxy.proxySettings();
            pVar.countProxy = 0;
            pVar.countGOOD = 0;
            pVar.countERROR = 0;
            pVar.countCURRENT = 0;
        }
       
        private async void btnStartCLICK(object sender, RoutedEventArgs e)
        {
            BROWSER.BrowserOpen();
        }



        public void showResult(bool Success)
        {
            string status = "";

            if (Success == true)
            {
                pVar.countGOOD++;
                this.countGood.Content = pVar.countGOOD;
                status = "GOOD";
            }
            else if (Success == false)
            {
                pVar.countERROR++;
                this.countErrors.Content = pVar.countERROR;
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

        private void reqLogins_Checked(object sender, RoutedEventArgs e)
        {
            pVar.mainAction = "EMAILS";
            Logins.Load();
            countAll.Content = pVar.countALL;
       
        }

        private void reqPasswords_Checked(object sender, RoutedEventArgs e)
        {
            pVar.mainAction = "LOGINS";
            Logins.Load();
            countAll.Content = pVar.countALL;
           
        }

        private void checkNONE_Checked(object sender, RoutedEventArgs e)
        {
            mProxy.proxyTYPE = "none";
            Console.WriteLine("none");
            pVar.countProxy = 0;
            countProxiesALL.Content = pVar.countProxy.ToString();
        }


        private void checkSOCKS5_Checked(object sender, RoutedEventArgs e)
        {
            mProxy.proxyTYPE = "socks5";
            Console.WriteLine("socks5");
            mProxy.proxySettings();
            countProxiesALL.Content = pVar.countProxy.ToString();
        }

        private void checkSOCKS4_Checked(object sender, RoutedEventArgs e)
        {
            mProxy.proxyTYPE = "socks4";
            Console.WriteLine("socks4");
            mProxy.proxySettings();
            countProxiesALL.Content = pVar.countProxy.ToString();
        }

        private void checkHTTPs_Checked(object sender, RoutedEventArgs e)
        {
            mProxy.proxyTYPE = "https";
            Console.WriteLine("https");
            mProxy.proxySettings();
            countProxiesALL.Content = pVar.countProxy.ToString();
        }
    }


}
