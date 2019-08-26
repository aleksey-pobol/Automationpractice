using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automationpractice.PagesObjects;

namespace Automationpractice.TestCases
{
    class ComparePriceRange : Automationpractice
    {
        [Test]
        public void ComparePriceRangeTest()
        {
            Page.Main.GoTodDessesMenu();
            Page.Products.ChangePriceRange();
            Page.Products.ComparePriceRange();
        }
    }
}
