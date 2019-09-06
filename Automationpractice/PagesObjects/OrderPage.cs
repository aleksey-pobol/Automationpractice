using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automationpractice.PagesObjects
{
    public class OrderPage
    {
        [FindsBy(How = How.XPath, Using = "//p[@class='cart_navigation clearfix']//a[@title='Proceed to checkout']")]
        private IWebElement _checkoutSummaryButton;

        [FindsBy(How = How.XPath, Using = "//button[@name='processAddress']")]
        private IWebElement _checkoutAddressButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='checker']")]
        private IWebElement _agreeShippingCheckBox;

        [FindsBy(How = How.XPath, Using = "//button[@name='processCarrier']")]
        private IWebElement _checkoutShippingButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='bankwire']")]
        private IWebElement _payByBankWireButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='cart_navigation']//button[@type='submit']")]
        private IWebElement _confirmOrderButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='cheque-indent']//strong[@class='dark']")]
        private IWebElement _titleOrder;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-plus']")]
        private IWebElement _increaseQuantityButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='cart_total']//span[@class='price']")]
        private IWebElement _totalCostSummary;

        [FindsBy(How = How.XPath, Using = "//*[@id='address_invoice']//*[@class='address_update']//a")]
        private IWebElement _updateBillungAddressButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='alias']")]
        private IWebElement _addressTitleField;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAddress']")]
        private IWebElement _submitAddressButton;

        //select[@id='id_address_delivery']//option
        [FindsBy(How = How.XPath, Using = "//*[@class='selector']")]
        private IWebElement _deliveryAddress;

        public void IncreaseQuantity(int countItem)
        {
            for (int i = 1; i < countItem; i++)
            {
                _increaseQuantityButton.Click();
            }
        }

        public void Summary(int countItem)
        {
            IncreaseQuantity(countItem);
            _checkoutSummaryButton.Click();
        }

        public void Address(String address)
        {
            _updateBillungAddressButton.Click();
            _addressTitleField.Clear();
            _addressTitleField.SendKeys(address);
            _submitAddressButton.Click();
            //Assert.IsTrue(deliveryAddress.Text.Equals(address));
            _checkoutAddressButton.Click();
        }

        public void Shipping()
        {
            _agreeShippingCheckBox.Click();
            _checkoutShippingButton.Click();
        }

        public void Payment()
        {
            _payByBankWireButton.Click();
            _confirmOrderButton.Click();
        }

        public void BuyItem()
        {
            Summary(2);
            Address("CosmosStar");
            Shipping();
            Payment();
            Assert.IsTrue(_titleOrder.Text.Equals("Your order on My Store is complete."));
        }
    }
}
