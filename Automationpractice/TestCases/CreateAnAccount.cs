using NUnit.Framework;
using Automationpractice.PagesObjects;


namespace Automationpractice.TestCases
{
    class CreateAnAccount : BaseTest
    {
        [Test]
        public void CreateAnAccountTest()
        {
            Page.Main.GoToAuthenticationPage();
            Page.Authentication.CreateAnAccount();
        }
    }
}
