using NUnit.Framework;
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
