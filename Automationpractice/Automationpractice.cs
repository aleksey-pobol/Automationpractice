using System;
using System.Threading;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automationpractice.PagesObjects;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Automationpractice.WrapperFactory;


namespace Automationpractice
{
    [TestFixture]
    public class Automationpractice
    {         
        //---Extent Reporting----------
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        //------------------------------

        [SetUp]
        public void SetUpTest()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            WebDriverFactory.Driver.Manage().Window.Maximize();
            WebDriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //---Extent Reporting----------
            var htmlReporter = new ExtentHtmlReporter(@"D:\ExtentReport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
                        
            //Feature
            var feature = extent.CreateTest<Feature>("SignIn");
            //Scenario
            var scenario = feature.CreateNode<Scenario>("Login user as " + ConfigurationManager.AppSettings["firstname"]);
            //Steps
            scenario.CreateNode<Given>("SignIn");
            //------------------------------
        }
        
        [TearDown]
        public void TearDownTest()
        {
            extent.Flush();
            WebDriverFactory.CloseAllDrivers();
        }

    }

}
