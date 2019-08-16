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
        public IWebElement casualDressesMenuItem;

        [FindsBy(How = How.XPath, Using = "//i[@class='icon-th-list']")]
        public IWebElement viewListButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='content_sortPagiBar']//button[@type='submit']")]
        public IWebElement submitCompareButton;
        

        public void GoToAuthenticationPage()
        {
            SignInLink.Click();
        }      

        public void SearchItem(String item)
        {
            searchQueryTopField.SendKeys(item);
            resultSearchField.Click();
            Assert.IsTrue(titleTshirtResult.Text.Equals(item));           
        }
        public void ChooseCountForAddToCompare(int countOfPluses)
        {
            int count = 1;
            for (int i = 0; i < countOfPluses; i++)
            {
                IWebElement addToCompareButton = _driver.FindElement(By.XPath(String.Format("//li[{0}]//*[@class='add_to_compare']", count)));
                addToCompareButton.Click();
                Thread.Sleep(1000);
                count++;
            }        
        }
        
        public List<String> getItemsNames(String locator)
        {    
            var storageComparableItems = new List<String>();            
            var titleElements = _driver.FindElements(By.XPath(locator));

                foreach (IWebElement webElement in titleElements)
                {
                    storageComparableItems.Add(webElement.Text);
                }
                
            return storageComparableItems;
        }


        public void checkItems(List<String> selectedItems, List<String> receivedItems)
        {
            foreach (String item in selectedItems)
            {
                receivedItems.Contains(item);
            }
        }

        public void FindItemFromMenu()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(dressesMenuItem).Perform();            
            casualDressesMenuItem.Click();
            viewListButton.Click(); 
        }

        public void CompareItems()
        {
            List<String> selectedItems = getItemsNames("//ul[@class='product_list row list']//a[@class='product-name']");
            Actions actions = new Actions(_driver);
            actions.MoveToElement(submitCompareButton).Click().Perform();            
            List<String> receivedItems = getItemsNames("//table[@id='product_comparison']//a[@class='product-name']");
            checkItems(selectedItems, receivedItems);
        }
    }
}
