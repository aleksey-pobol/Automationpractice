using NUnit.Framework;
using Automationpractice.PagesObjects;

namespace Automationpractice.TestCases
{
    class CompareItem : BaseTest
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
