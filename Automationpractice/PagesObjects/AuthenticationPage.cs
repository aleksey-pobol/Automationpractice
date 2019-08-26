using System;
using System.Configuration;
using Automationpractice.WrapperFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automationpractice.PagesObjects
{
    public class AuthenticationPage
    {
        private const string _defaultPassword = "aleksey96";
        private const string _defaultNumber = "+375251234455";

        [FindsBy(How = How.XPath, Using = "//input[@name='email_create']")]
        private IWebElement _emailCreateField;

        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitCreate']")]
        private IWebElement _submitCreateButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_firstname']")]
        private IWebElement customerFirstnameField;

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_lastname']")]
        private IWebElement customerLastameField;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement emailRegField;

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        private IWebElement passwdField;

        [FindsBy(How = How.XPath, Using = "//input[@id='address1']")]
        private IWebElement regAdressField;

        [FindsBy(How = How.XPath, Using = "//input[@id='city']")]
        private IWebElement regcityField;

        [FindsBy(How = How.XPath, Using = "//*[@id='uniform-id_state']")]
        private IWebElement stateSelector;

        [FindsBy(How = How.XPath, Using = "//*[@id='id_state']/option[17]")]
        private IWebElement chooseState;

        [FindsBy(How = How.XPath, Using = "//input[@id='postcode']")]
        private IWebElement postcodeField;

        [FindsBy(How = How.XPath, Using = "//input[@id='phone_mobile']")]
        private IWebElement phoneMobileField;

        [FindsBy(How = How.XPath, Using = "//input[@id='alias']")]
        private IWebElement aliasField;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAccount']")]
        private IWebElement submitAccountButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='header_user_info']/a/span")]
        private IWebElement headerUserInfo;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement emailSignInField;

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        private IWebElement passwordSignInField;

        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitLogin']")]
        private IWebElement submitLoginButton;

        /*public string GetRandomEmail()
        {
            Random random = new Random(Environment.TickCount);
            int value = random.Next();
            string emailAddress = $"test{value}@mail.com";

            return emailAddress;
        }*/

        public string GetRandomEmail()
        {
            return $"test{DateTime.UtcNow:yyyyMMddmmss}@mail.com";
        }

        public void CreateAnAccount()
        {
            _emailCreateField.SendKeys(GetRandomEmail());
            _submitCreateButton.Click();
            customerFirstnameField.SendKeys(ConfigurationManager.AppSettings["firstname"]);
            customerLastameField.SendKeys(ConfigurationManager.AppSettings["lasttname"]);
            emailRegField.Click();
            passwdField.SendKeys(_defaultPassword);
            regAdressField.SendKeys("Minsk");
            regcityField.SendKeys("Minsk");
            stateSelector.Click();
            chooseState.Click();
            postcodeField.SendKeys("12345");
            phoneMobileField.SendKeys(_defaultNumber);
            aliasField.Clear();
            aliasField.SendKeys("Cosmos");
            submitAccountButton.Click();
            WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='header_user_info']/a/span")));
            Assert.IsTrue(headerUserInfo.Text.Equals(ConfigurationManager.AppSettings["firstname"] + ' ' + ConfigurationManager.AppSettings["lasttname"]));
        }

        public void SignIn(String email, String password, String firstname, String lasttname)
        {
            emailSignInField.SendKeys(email);
            passwordSignInField.SendKeys(password);
            submitLoginButton.Click();
            Assert.IsTrue(headerUserInfo.Text.Equals(firstname + ' ' + lasttname));
        }


    }
}
