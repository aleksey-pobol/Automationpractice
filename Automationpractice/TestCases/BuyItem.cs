using System.Configuration;
using NUnit.Framework;
using Automationpractice.PagesObjects;


namespace Automationpractice.TestCases
{
    class BuyItem : Automationpractice
    {
        [Test]
        public void BuyItemTest()
        {
            Page.Main.GoToAuthenticationPage();
            Page.GetAuthentication().SignIn(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"],
                ConfigurationManager.AppSettings["firstname"], ConfigurationManager.AppSettings["lasttname"]);
            Page.Main.FindItem("Faded Short Sleeve T-shirts");
            Page.Checkout.AddToCart(1);
            Page.Order.BuyItem();
        }
    }
}
