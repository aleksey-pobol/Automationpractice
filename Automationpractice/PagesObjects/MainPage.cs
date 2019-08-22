using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        public IWebElement SignInLink;

        [FindsBy(How = How.XPath, Using = "//input[@id='search_query_top']")]
        public IWebElement searchQueryTopField;

        [FindsBy(How = How.XPath, Using = "//*[@class='ac_results']")]
        public IWebElement resultSearchField;

        [FindsBy(How = How.XPath, Using = "//h1[@itemprop]")]
        public IWebElement titleTshirtResult;

        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[2]")]
        public IWebElement dressesMenuItem;

        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[2]//a[@title='Summer Dresses']")]
        public IWebElement casualDressesSubmenuItem;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-th-list']")]
        public IWebElement viewListButton;

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
       
        public void FindItemFromSubmenu(IWebElement menuLocator, IWebElement submenuLocator)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(menuLocator).Perform();
            submenuLocator.Click();
            viewListButton.Click(); 
        }
              
        public void GoToMenu(IWebElement menuLocator)
        {
            menuLocator.Click();
        }
        
    }
}
