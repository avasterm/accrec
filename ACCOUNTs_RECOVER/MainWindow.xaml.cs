using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
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
        
        public  MainWindow()
        {

            InitializeComponent();

            //Logins.Load();
           //mProxy.proxySettings();
            pVar.countProxy = 0;
            pVar.countGOOD = 0;
            pVar.countERROR = 0;
            pVar.countCURRENT = 0;
            //chooseProxy();
        }
       
        private void btnStartCLICK(object sender, RoutedEventArgs e)
        {
            chooseProxy();
            Recover.Run(Recover.DO);
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
            chooseTypeOfList();

        }

        private void reqPasswords_Checked(object sender, RoutedEventArgs e)
        {
            pVar.mainAction = "LOGINS";
            chooseTypeOfList();
        }



        public void chooseProxy()
        {

            if (checkSOCKS5.IsChecked == true)
            {
                mProxy.proxyTYPE = "socks5";
            }
            else if (checkSOCKS4.IsChecked == true)
            {
                mProxy.proxyTYPE = "socks4";
            }
            else if (checkHTTPs.IsChecked == true)
            {
                mProxy.proxyTYPE = "https";
            }
            else if (checkNONE.IsChecked == true)
            {
                mProxy.proxyTYPE = "none";
                pVar.countProxy = 0;
            }
            
            mProxy.proxySettings();
            countProxiesALL.Content = pVar.countProxy.ToString();
        }

        public void chooseTypeOfList()
        {
            Logins.Load();
            countAll.Content = pVar.countALL;
        }

        }


}
