using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace Automationpractice.PagesObjects
{
    class MainPage
    {
        private readonly IWebDriver _driver;       
        
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='login']")]
        private IWebElement SignInLink;

        [FindsBy(How = How.XPath, Using = "//input[@id='search_query_top']")]
        private IWebElement searchQueryTopField;

        [FindsBy(How = How.XPath, Using = "//*[@class='ac_results']")]
        private IWebElement resultSearchField;

        [FindsBy(How = How.XPath, Using = "//h1[@itemprop]")]
        private IWebElement titleTshirtResult;

        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[2]")]
        private IWebElement dressesMenuItem;

        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[2]//a[@title='Summer Dresses']")]
        private IWebElement casualDressesSubmenuItem;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-th-list']")]
        private IWebElement viewListButton;

        public void GoToAuthenticationPage()
        {
            SignInLink.Click();
        }      

        public void FindItem(String item)
        {
            searchQueryTopField.SendKeys(item);
            resultSearchField.Click();
            Assert.IsTrue(titleTshirtResult.Text.Equals(item));           
        }
       
        public void GoToCasualDressesSubmenu()
        {            
            Actions actions = new Actions(_driver);
            actions.MoveToElement(dressesMenuItem).Perform();
            casualDressesSubmenuItem.Click();
            viewListButton.Click(); 
        }
              
        public void GoTodDessesMenu()
        {
            dressesMenuItem.Click();
        }

        public void ScrollPageByJS()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            int part = 1;
            String script = String.Format("window.scrollTo(0, document.body.scrollHeight * {p})", part);
            js.ExecuteScript(script);           
        }
    }
}
