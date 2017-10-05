﻿using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;


namespace ACCOUNTs_RECOVER
{

    public class WebBrowser
    {
        public IWebDriver WEB_Browser;
        public PhantomJSDriverService WEB_settings = PhantomJSDriverService.CreateDefaultService();
        public PhantomJSOptions WEB_options = new PhantomJSOptions();
        public ICookieJar WEB_cookies;
        public string __cfduid;
        public string cf_clearance;

        public void BrowserSettings()
        {
            
            //DEFAULT BROWSER SETTINGS
            string UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
            WEB_settings.AddArgument(string.Format("--ignore-ssl-errors=true"));
            WEB_settings.AddArgument(string.Format("--load-images=false"));
            WEB_settings.AddArgument(string.Format("--ssl-protocol=any"));
            WEB_settings.AddArgument(string.Format("--web-security=false"));
            if (Proxy.proxyTYPE != "none")
            {
                WEB_settings.AddArgument(string.Format("--proxy={0}", Proxy.nextProxy()));
                WEB_settings.AddArgument(string.Format("--proxy-type={0}", Proxy.proxyTYPE));
            }
            Console.WriteLine(Proxy.proxyTYPE + "_type");
            WEB_settings.HideCommandPromptWindow = true;
            //CUSTOM BROWSER OPTIONS/
            WEB_options.AddAdditionalCapability("phantomjs.page.settings.userAgent", UserAgent);

 

                WEB_Browser = new OpenQA.Selenium.PhantomJS.PhantomJSDriver(WEB_settings, WEB_options);

    
        }

        public void shoot(string name)
        {
            Screenshot ss = ((ITakesScreenshot)WEB_Browser).GetScreenshot();
            ss.SaveAsFile(name+"_SCREENSHOT.png", ScreenshotImageFormat.Png);
        }
        public void GetCookies()
        {
            string pat1 = @"^(__cfduid)\=([a-f0-9]{1,100})\;\s(.*?)$";
            string pat2 = @"^(cf_clearance)\=([a-f0-9]{1,100})\-([a-f0-9]{1,10})\-([a-f0-9]{1,6})\;\s(.*?)$";

            __cfduid = Regex.Replace(WEB_Browser.Manage().Cookies.GetCookieNamed("__cfduid").ToString(), pat1, "$2");
            cf_clearance = Regex.Replace(WEB_Browser.Manage().Cookies.GetCookieNamed("cf_clearance").ToString(), pat2, "$2-$3-$4");
           
          Console.WriteLine(__cfduid);
         Console.WriteLine(cf_clearance);
        }
        public void BrowserOpen()
        {

            if (WEB_Browser != null)
            {
                WEB_Browser.Quit();
            }

            BrowserSettings();
            WEB_Browser.Navigate().GoToUrl("https://account.leagueoflegends.com/na/en/forgot-password");
            try
            {
                WebDriverWait whenLoad = new WebDriverWait(WEB_Browser, TimeSpan.FromSeconds(25));
                whenLoad.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName(" riotbar-present")));
                shoot("GOOD");
                GetCookies();
                WEB_Browser.Quit();
            }

            catch
            {
                shoot("BAD");
                BrowserOpen();
            }
           
            //new WebDriverWait(WEB_Browser, TimeSpan.FromSeconds(90)).Until(ExpectedConditions.ElementExists((By.Id("riotbar-navmenu"))));
            //WEB_Browser.Navigate().GoToUrl("https://account.leagueoflegends.com/na/en/forgot-password");
                
                                
            
            
        }
    }
}
