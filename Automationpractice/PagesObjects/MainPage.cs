using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void GoToAuthenticationPage()
        {
            SignInLink.Click();
        }

        public void SearchTshirts()
        {
            searchQueryTopField.SendKeys("t-shirts");
            resultSearchField.Click();
            Assert.IsTrue(titleTshirtResult.Text.Equals("Faded Short Sleeve T-shirts"));            
        }

        



    }
}
