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
    class OrderPage
    {
        private readonly IWebDriver _driver;

        public OrderPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//p[@class='cart_navigation clearfix']//a[@title='Proceed to checkout']")]
        public IWebElement checkoutSummaryButton;

        [FindsBy(How = How.XPath, Using = "//button[@name='processAddress']")]
        public IWebElement checkoutAddressButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='checker']")]
        public IWebElement agreeShippingCheckBox;

        [FindsBy(How = How.XPath, Using = "//button[@name='processCarrier']")]
        public IWebElement checkoutShippingButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='bankwire']")]
        public IWebElement payByBankWireButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='cart_navigation']//button[@type='submit']")]
        public IWebElement confirmOrderButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='cheque-indent']//strong[@class='dark']")]
        public IWebElement titleOrder;
        


        public void BuyTshirt()
        {
            checkoutSummaryButton.Click();
            checkoutAddressButton.Click();
            agreeShippingCheckBox.Click();
            checkoutShippingButton.Click();
            payByBankWireButton.Click();
            confirmOrderButton.Click();
            Assert.IsTrue(titleOrder.Text.Equals("Your order on My Store is complete."));
        }
    }
}
