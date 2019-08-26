using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace Automationpractice.WrapperFactory
{
    class WebDriverFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized." +
                        " You should first call the method InitBrowser.");

                return _driver;
            }
            private set
            {
                _driver = value;
            }
        }
        ///<summary>Available names: Firefox, IE, Chrome</summary>
        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (_driver == null)
                    {
                        _driver = new FirefoxDriver();
                        Drivers.Add("Firefox", _driver);
                    }

                    break;

                case "IE":
                    if (_driver == null)
                    {
                        _driver = new InternetExplorerDriver();
                        Drivers.Add("IE", _driver);
                    }

                    break;

                case "Chrome":
                    if (_driver == null)
                    {
                        _driver = new ChromeDriver();
                        Drivers.Add("Chrome", _driver);
                    }

                    break;
            }


        }

        public static void GoToUrl(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
            
        }
    }
}
