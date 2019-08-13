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

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-plus']")]
        public IWebElement increaseQuantityButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='cart_total']//span[@class='price']")]
        public IWebElement totalCostSummary;

        [FindsBy(How = How.XPath, Using = "//*[@id='address_invoice']//*[@class='address_update']//a")]
        public IWebElement updateBillungAddressButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='alias']")]
        public IWebElement addressTitleField;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAddress']")]
        public IWebElement submitAddressButton;

        [FindsBy(How = How.XPath, Using = "//select[@id='id_address_delivery']//option")]
        public IWebElement deliveryAddress;

        public void IncreaseQuantity(int countItem)
        {
            for (int i = 1; i < countItem; i++)
            {
                increaseQuantityButton.Click();
            }
        }

        public void Summary(int countItem)
        {
            IncreaseQuantity(countItem);
            checkoutSummaryButton.Click();            
        }

        public void Address(String address)
        {
            updateBillungAddressButton.Click();
            addressTitleField.SendKeys(address);
            submitAddressButton.Click();
            checkoutAddressButton.Click();
            Assert.IsTrue(deliveryAddress.Text.Equals(address));
        }

        public void Shipping()
        {
            agreeShippingCheckBox.Click();
            checkoutShippingButton.Click();
        }

        public void Payment()
        {
            payByBankWireButton.Click();
            confirmOrderButton.Click();
        }

        public void BuyItem()
        {
            Summary(1);
            Address("CosmosStar");
            Shipping();
            Payment();
            Assert.IsTrue(titleOrder.Text.Equals("Your order on My Store is complete."));
        }

        


    }
}
