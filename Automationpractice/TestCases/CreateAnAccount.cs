using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automationpractice.PagesObjects;


namespace Automationpractice.TestCases
{
    class CreateAnAccount : Automationpractice
    {
        [Test]
        public void CreateAnAccountTest()
        {
            Page.Main.GoToAuthenticationPage();
            Page.Authentication.CreateAnAccount();
        }
    }
}
