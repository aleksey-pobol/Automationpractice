﻿using System;
using System.Collections.Generic;
using System.Threading;
using Automationpractice.WrapperFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Automationpractice.PagesObjects
{
    public class ProductsPage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='content_sortPagiBar']//button[@type='submit']")]
        private IWebElement _submitCompareButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='layered_price_slider']/a[1]")]
        private IWebElement _leftsSlider;

        [FindsBy(How = How.XPath, Using = "//*[@id='layered_price_slider']/a[2]")]
        private IWebElement _rightSlider;

        [FindsBy(How = How.XPath, Using = "//*[@id='layered_price_slider']")]
        private IWebElement _sliderRange;

        [FindsBy(How = How.XPath, Using = "//span[@id='layered_price_range']")]
        private IWebElement _priceRange;

        public void ChooseCountForAddToCompare(int countOfPluses)
        {
            int count = 1;
            for (int i = 0; i < countOfPluses; i++)
            {
                IWebElement addToCompareButton = WebDriverFactory.Driver.FindElement(By.XPath(String.Format("//li[{0}]//*[@class='add_to_compare']", count)));
                addToCompareButton.Click();
                Thread.Sleep(1000);
                count++;
            }
        }

        public List<String> getItemsNames(String locator)
        {
            List<String> storageComparableItems = new List<String>();
            var titleElements = WebDriverFactory.Driver.FindElements(By.XPath(locator));

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
            Actions actions = new Actions(WebDriverFactory.Driver);
            actions.MoveToElement(_submitCompareButton).Click().Perform();
            List<String> receivedItems = getItemsNames("//table[@id='product_comparison']//a[@class='product-name']");
            checkItems(selectedItems, receivedItems);
        }

        public void ChangePriceRange()
        {
            Actions actions = new Actions(WebDriverFactory.Driver);
            int sliderRangeWidth = _sliderRange.Size.Width;
            actions.DragAndDropToOffset(_leftsSlider, ((sliderRangeWidth * 11) / 100), 0).Perform();
            actions = new Actions(WebDriverFactory.Driver);
            actions.DragAndDropToOffset(_rightSlider, ((-sliderRangeWidth * 34) / 100), 0).Perform();
        }

        public void ComparePriceRange()
        {
            Assert.IsTrue(_priceRange.Text.Equals("$20.07 - $40.05"));
        }
    }
}
