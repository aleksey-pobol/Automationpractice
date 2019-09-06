using System;
using Automationpractice.WrapperFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Automationpractice.PagesObjects
{
    public class MainPage
    {
        [FindsBy(How = How.XPath, Using = "//a[@class='login']")]
        private IWebElement _SignInLink;

        [FindsBy(How = How.XPath, Using = "//input[@id='search_query_top']")]
        private IWebElement _searchQueryTopField;

        [FindsBy(How = How.XPath, Using = "//*[@class='ac_results']")]
        private IWebElement _resultSearchField;

        [FindsBy(How = How.XPath, Using = "//h1[@itemprop]")]
        private IWebElement _titleTshirtResult;

        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[2]")]
        private IWebElement _dressesMenuItem;

        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[2]//a[@title='Summer Dresses']")]
        private IWebElement _casualDressesSubmenuItem;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-th-list']")]
        private IWebElement _viewListButton;

        public void GoToAuthenticationPage()
        {
            _SignInLink.Click();
        }

        public void FindItem(String item)
        {
            _searchQueryTopField.SendKeys(item);
            _resultSearchField.Click();
            Assert.IsTrue(_titleTshirtResult.Text.Equals(item));
        }

        public void GoToCasualDressesSubmenu()
        {
            Actions actions = new Actions(WebDriverFactory.Driver);
            actions.MoveToElement(_dressesMenuItem).Perform();
            _casualDressesSubmenuItem.Click();
            _viewListButton.Click();
        }

        public void GoTodDessesMenu()
        {
            _dressesMenuItem.Click();
        }

        public void ScrollPageByJS()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriverFactory.Driver;
            int part = 1;
            String script = String.Format("window.scrollTo(0, document.body.scrollHeight * {p})", part);
            js.ExecuteScript(script);
        }
    }
}
