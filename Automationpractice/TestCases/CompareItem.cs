using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automationpractice.PagesObjects;

namespace Automationpractice.TestCases
{
    class CompareItem : Automationpractice
    {
        [Test]
        public void CompareItemTest()
        {
            Page.Main.GoToCasualDressesSubmenu();
            Page.Products.ChooseCountForAddToCompare(3);
            Page.Products.CompareItems();
        }
    }
}
