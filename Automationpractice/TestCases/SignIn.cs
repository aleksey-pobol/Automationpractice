using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automationpractice.PagesObjects;
using System.Configuration;

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
