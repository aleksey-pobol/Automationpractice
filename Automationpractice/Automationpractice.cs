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
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;
        //------------------------------

        [SetUp]
        public void SetUpTest()
        {
            WebDriverFactory.InitBrowser("Chrome");
            WebDriverFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            WebDriverFactory.Driver.Manage().Window.Maximize();
            WebDriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //---Extent Reporting----------Это была попытка прикрутить Extent Report
            var htmlReporter = new ExtentHtmlReporter( @"D:\ExtentReport.html" );
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

            //Feature
            var feature = _extent.CreateTest<Feature>("SignIn");
            //Scenario
            var scenario = feature.CreateNode<Scenario>("Login user as " + ConfigurationManager.AppSettings["firstname"]);
            //Steps
            scenario.CreateNode<Given>("SignIn");
            //-----------------------------
        }

        [TearDown]
        public void TearDownTest()
        {
            _extent.Flush();
            WebDriverFactory.CloseAllDrivers();            
        }
    }

}
