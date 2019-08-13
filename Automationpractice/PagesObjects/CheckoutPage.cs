using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automationpractice.PagesObjects
{
    class CheckoutPage
    {
        private readonly IWebDriver _driver;

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[@name='Submit']")]
        public IWebElement addToCartButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        public IWebElement proceedToCheckoutButton;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-plus']")]
        public IWebElement increaseQuantityButton;

        [FindsBy(How = How.XPath, Using = "//h1[@id='cart_title']")]
        public IWebElement cartTitle;


        public void IncreaseQuantity(int countItem)
        {
            for (int i = 1; i < countItem; i++)
            {
                increaseQuantityButton.Click();
            }

        }

        public void AddToCart(int countItem)
        {
            IncreaseQuantity(countItem);
            addToCartButton.Click();
            proceedToCheckoutButton.Click();
            Assert.IsTrue(cartTitle.Text.Equals("SHOPPING-CART SUMMARY"));
        }

    }
}
