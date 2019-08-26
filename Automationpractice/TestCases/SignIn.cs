using System.Configuration;
using NUnit.Framework;
using Automationpractice.PagesObjects;


namespace Automationpractice.TestCases
{
    class SignIn : Automationpractice
    {
        [Test]
        public void SignInTest()
        {
            Page.Main.GoToAuthenticationPage();
            Page.GetAuthentication().SignIn(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"],
                ConfigurationManager.AppSettings["firstname"], ConfigurationManager.AppSettings["lasttname"]);
        }
    }
}
