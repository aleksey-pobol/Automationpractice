using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automationpractice.PagesObjects
{
    public class CheckoutPage
    {
        [FindsBy(How = How.XPath, Using = "//button[@name='Submit']")]
        private IWebElement _addToCartButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        private IWebElement _proceedToCheckoutButton;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-plus']")]
        private IWebElement _increaseQuantityButton;

        [FindsBy(How = How.XPath, Using = "//span[@class='navigation_page']")]
        private IWebElement _navigationPagetTitle;

        public void IncreaseQuantity(int countItem)
        {
            for (int i = 1; i < countItem; i++)
            {
                _increaseQuantityButton.Click();
            }
        }

        public void AddToCart(int countItem)
        {
            IncreaseQuantity(countItem);
            _addToCartButton.Click();
            _proceedToCheckoutButton.Click();
            Assert.IsTrue(_navigationPagetTitle.Text.Equals("Your shopping cart"));
        }
    }
}
