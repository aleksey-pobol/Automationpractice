using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Automationpractice.PagesObjects;

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

        [SetUp]
        public void SetUpTest()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://automationpractice.com/");
            _driver.Manage().Window.Maximize();

            mainPage = new MainPage(_driver);
            authenticationPage = new AuthenticationPage(_driver);
            orderPage = new OrderPage(_driver);
            checkoutpage = new CheckoutPage(_driver);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
            authenticationPage.SignIn();
        }

        [Test]
        public void BuyTshirt()
        {
            mainPage.GoToAuthenticationPage();
            authenticationPage.SignIn();
            mainPage.SearchTshirts();
            checkoutpage.AddToCart();
            orderPage.BuyTshirt();
        }

       /* [Test]
        public void BuyDressesFromAdvancedSearch()
        {
            mainPage.GoToAuthenticationPage();
            authenticationPage.SignIn();
        }*/

        [TearDown]
        public void TearDownTest() 
        {
            _driver.Quit();
        }

    }

}
