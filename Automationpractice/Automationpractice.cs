using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Automationpractice.PagesObjects;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace Automationpractice
{
    [TestFixture]
    public class Automationpractice
    {
        private IWebDriver _driver;

        private MainPage mainPage;
        private AuthenticationPage authenticationPage;
        private OrderPage orderPage;
        private CheckoutPage checkoutpage;
        private ProductsPage productsPage;


        private String firstname = "Aleksey";
        private String lasttname = "Pobol";
        private String email = "test3@mail.com";
        private String password = "aleksey96";


        //---Extent Reporting----------
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        //------------------------------


        [SetUp]
        public void SetUpTest()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://automationpractice.com/");
            _driver.Manage().Window.Maximize();  
            

            mainPage = new MainPage(_driver);
            authenticationPage = new AuthenticationPage(_driver);
            checkoutpage = new CheckoutPage(_driver);
            orderPage = new OrderPage(_driver);
            productsPage = new ProductsPage(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            //---Extent Reporting----------
            var htmlReporter = new ExtentHtmlReporter(@"D:\ExtentReport.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
                        
            //Feature
            var feature = extent.CreateTest<Feature>("SignIn");
            //Scenario
            var scenario = feature.CreateNode<Scenario>("Login user as " + firstname);
            //Steps
            scenario.CreateNode<Given>("SignIn");
            //------------------------------
        }

        [Test]
        public void CreateAnAccount()
        {
            mainPage.GoToAuthenticationPage();
            authenticationPage.CreateAnAccount();
        }

        [Test]
        public void SignIn()
        {
            mainPage.GoToAuthenticationPage();
            authenticationPage.SignIn(email, password, firstname, lasttname);
        }

        [Test]
        public void BuyItem()
        {
            mainPage.GoToAuthenticationPage();
            authenticationPage.SignIn(email, password, firstname, lasttname);
            mainPage.FindItem("Faded Short Sleeve T-shirts");
            checkoutpage.AddToCart(1);
            orderPage.BuyItem();
        }

        [Test]
        public void CompareItem()
        {
            mainPage.FindItemFromSubmenu(mainPage.dressesMenuItem, mainPage.casualDressesSubmenuItem);
            productsPage.ChooseCountForAddToCompare(3);
            productsPage.CompareItems();            
        }

        [Test]
        public void ComparePriceRange()
        {
            mainPage.GoToMenu(mainPage.dressesMenuItem);
            productsPage.ChangePriceRange();
            productsPage.ComparePriceRange();
        }

        [TearDown]
        public void TearDownTest()
        {
            extent.Flush();
            _driver.Quit();
        }

    }

}
