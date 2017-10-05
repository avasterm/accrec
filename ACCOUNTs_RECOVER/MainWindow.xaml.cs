using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        }
       
        private void btnStartCLICK(object sender, RoutedEventArgs e)
        {

           
            checkProxyTYPE();
            
            
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

    }


}
