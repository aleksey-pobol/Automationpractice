using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automationpractice.PagesObjects
{
    public class OrderPage
    {
        [FindsBy(How = How.XPath, Using = "//p[@class='cart_navigation clearfix']//a[@title='Proceed to checkout']")]
        private IWebElement checkoutSummaryButton;

        [FindsBy(How = How.XPath, Using = "//button[@name='processAddress']")]
        private IWebElement checkoutAddressButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='checker']")]
        private IWebElement agreeShippingCheckBox;

        [FindsBy(How = How.XPath, Using = "//button[@name='processCarrier']")]
        private IWebElement checkoutShippingButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='bankwire']")]
        private IWebElement payByBankWireButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='cart_navigation']//button[@type='submit']")]
        private IWebElement confirmOrderButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='cheque-indent']//strong[@class='dark']")]
        private IWebElement titleOrder;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-plus']")]
        private IWebElement increaseQuantityButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='cart_total']//span[@class='price']")]
        private IWebElement totalCostSummary;

        [FindsBy(How = How.XPath, Using = "//*[@id='address_invoice']//*[@class='address_update']//a")]
        private IWebElement updateBillungAddressButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='alias']")]
        private IWebElement addressTitleField;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAddress']")]
        private IWebElement submitAddressButton;

        //select[@id='id_address_delivery']//option
        [FindsBy(How = How.XPath, Using = "//*[@class='selector']")]
        private IWebElement deliveryAddress;

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
            addressTitleField.Clear();
            addressTitleField.SendKeys(address);
            submitAddressButton.Click();
            //Assert.IsTrue(deliveryAddress.Text.Equals(address));
            checkoutAddressButton.Click();
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
            Summary(2);
            Address("CosmosStar");
            Shipping();
            Payment();
            Assert.IsTrue(titleOrder.Text.Equals("Your order on My Store is complete."));
        }
    }
}
