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

        private String firstname = "Aleksey";
        private String lasttname = "Pobol";
        private String email = "test3@mail.com";
        private String password = "aleksey96";

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
            authenticationPage.SignIn(email, password, firstname, lasttname);
        }

        [Test]
        public void BuyItem()
        {
            mainPage.GoToAuthenticationPage();
            authenticationPage.SignIn(email,password,firstname,lasttname);
            mainPage.SearchItem("Faded Short Sleeve T-shirts");
            checkoutpage.AddToCart(1);
            orderPage.BuyItem();

        }
              
        [TearDown]
        public void TearDownTest() 
        {
            _driver.Quit();
        }

    }

}
