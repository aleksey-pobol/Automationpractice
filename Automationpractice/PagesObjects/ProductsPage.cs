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
    class ProductsPage
    {
        private readonly IWebDriver _driver;

        public ProductsPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='content_sortPagiBar']//button[@type='submit']")]
        public IWebElement submitCompareButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='layered_price_slider']/a[1]")]
        public IWebElement leftsSlider;
                
        [FindsBy(How = How.XPath, Using = "//*[@id='layered_price_slider']/a[2]")]
        public IWebElement rightSlider;

        [FindsBy(How = How.XPath, Using = "//*[@id='layered_price_slider']")]
        public IWebElement sliderRange;

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

        public void CompareItems()
        {
            List<String> selectedItems = getItemsNames("//ul[@class='product_list row list']//a[@class='product-name']");
            Actions actions = new Actions(_driver);
            actions.MoveToElement(submitCompareButton).Click().Perform();
            List<String> receivedItems = getItemsNames("//table[@id='product_comparison']//a[@class='product-name']");
            checkItems(selectedItems, receivedItems);
        }

        public void ChangePriceRange()
        {
            Actions actions = new Actions(_driver);            
            int sliderRangeWidth = sliderRange.Size.Width;            
            actions.DragAndDropToOffset(leftsSlider, ((sliderRangeWidth * 11) / 100), 0).Perform();
            actions = new Actions(_driver);
            actions.DragAndDropToOffset(rightSlider, ((-sliderRangeWidth * 34) / 100), 0).Perform();                
        }

        public void ComparePriceRange()
        {
            //Assert.IsTrue(sliderRange.Text.Equals("20.07 - 40.05"));
        }

        /*static String tshirts = "Faded Short Sleeve T-shirts";
        String blouse = "Blouse";
        String printedDress = "Printed Dress";
        String printedSummerDress = "Printed Summer Dress";
        String printedChiffonDress = "Printed Chiffon Dress";*/
    }
}
