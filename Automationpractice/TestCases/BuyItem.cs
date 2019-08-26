using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automationpractice.PagesObjects;
using System.Configuration;

namespace Automationpractice.TestCases
{
    class BuyItem : Automationpractice
    {
        [Test]
        public void BuyItemTest()
        {
            Page.Main.GoToAuthenticationPage();
            Page.Authentication.SignIn(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"],
                ConfigurationManager.AppSettings["firstname"], ConfigurationManager.AppSettings["lasttname"]);
            Page.Main.FindItem("Faded Short Sleeve T-shirts");
            Page.Checkout.AddToCart(1);
            Page.Order.BuyItem();
        }
    }
}
