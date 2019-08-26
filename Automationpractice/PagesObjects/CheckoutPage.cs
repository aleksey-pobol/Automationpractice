using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Automationpractice.PagesObjects
{
    public class CheckoutPage
    {
        [FindsBy(How = How.XPath, Using = "//button[@name='Submit']")]
        private IWebElement addToCartButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Proceed to checkout']")]
        private IWebElement proceedToCheckoutButton;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-plus']")]
        private IWebElement increaseQuantityButton;

        [FindsBy(How = How.XPath, Using = "//span[@class='navigation_page']")]
        private IWebElement navigationPagetTitle;

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
            Assert.IsTrue(navigationPagetTitle.Text.Equals("Your shopping cart"));
        }
    }
}
