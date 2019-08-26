using NUnit.Framework;
using Automationpractice.PagesObjects;


namespace Automationpractice.TestCases
{
    class CreateAnAccount : Automationpractice
    {
        [Test]
        public void CreateAnAccountTest()
        {
            Page.Main.GoToAuthenticationPage();
            Page.GetAuthentication().CreateAnAccount();
        }
    }
}
