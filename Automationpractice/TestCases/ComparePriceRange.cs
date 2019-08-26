using NUnit.Framework;
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
