using System;
using System.Configuration;
using NUnit.Framework;
using Automationpractice.WrapperFactory;

namespace Automationpractice
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        public void SetUpTest()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            WebDriverFactory.Driver.Manage().Window.Maximize();
            WebDriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void TearDownTest()
        {
            WebDriverFactory.CloseAllDrivers();
        }
    }
}
