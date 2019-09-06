using System.Configuration;
using NUnit.Framework;
using Automationpractice.PagesObjects;


namespace Automationpractice.TestCases
{
    class SignIn : BaseTest
    {
        [Test]
        public void SignInTest()
        {
            Page.Main.GoToAuthenticationPage();
            /*Page.Authentication.SignIn(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["password"],
                ConfigurationManager.AppSettings["firstname"], ConfigurationManager.AppSettings["lasttname"]);*/
            Page.Authentication.LoginToApplication("SignIn");
        }
    }
}
