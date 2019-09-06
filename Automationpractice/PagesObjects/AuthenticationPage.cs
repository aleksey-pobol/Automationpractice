using System;
using System.Configuration;
using Automationpractice.TestDataAccess;
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
        private IWebElement _customerFirstnameField;

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_lastname']")]
        private IWebElement _customerLastameField;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement _emailRegField;

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        private IWebElement _passwdField;

        [FindsBy(How = How.XPath, Using = "//input[@id='address1']")]
        private IWebElement _regAdressField;

        [FindsBy(How = How.XPath, Using = "//input[@id='city']")]
        private IWebElement _regcityField;

        [FindsBy(How = How.XPath, Using = "//*[@id='uniform-id_state']")]
        private IWebElement _stateSelector;

        [FindsBy(How = How.XPath, Using = "//*[@id='id_state']/option[17]")]
        private IWebElement _chooseState;

        [FindsBy(How = How.XPath, Using = "//input[@id='postcode']")]
        private IWebElement _postcodeField;

        [FindsBy(How = How.XPath, Using = "//input[@id='phone_mobile']")]
        private IWebElement _phoneMobileField;

        [FindsBy(How = How.XPath, Using = "//input[@id='alias']")]
        private IWebElement _aliasField;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAccount']")]
        private IWebElement _submitAccountButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='header_user_info']/a/span")]
        private IWebElement _headerUserInfo;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement _emailSignInField;

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        private IWebElement _passwordSignInField;

        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitLogin']")]
        private IWebElement _submitLoginButton;

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
            _customerFirstnameField.SendKeys(ConfigurationManager.AppSettings["firstname"]);
            _customerLastameField.SendKeys(ConfigurationManager.AppSettings["lasttname"]);
            _emailRegField.Click();
            _passwdField.SendKeys(_defaultPassword);
            _regAdressField.SendKeys("Minsk");
            _regcityField.SendKeys("Minsk");
            _stateSelector.Click();
            _chooseState.Click();
            _postcodeField.SendKeys("12345");
            _phoneMobileField.SendKeys(_defaultNumber);
            _aliasField.Clear();
            _aliasField.SendKeys("Cosmos");
            _submitAccountButton.Click();
            WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='header_user_info']/a/span")));
            Assert.IsTrue(_headerUserInfo.Text.Equals(ConfigurationManager.AppSettings["firstname"] + ' ' + ConfigurationManager.AppSettings["lasttname"]));
        }

        public void SignIn(String email, String password, String firstname, String lasttname)
        {
            _emailSignInField.SendKeys(email);
            _passwordSignInField.SendKeys(password);
            _submitLoginButton.Click();
            Assert.IsTrue(_headerUserInfo.Text.Equals(firstname + ' ' + lasttname));
        }
        //DDT
        public void LoginToApplication(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            _emailSignInField.SendKeys(userData._emailSignInField);
            _passwordSignInField.SendKeys(userData._passwordSignInField);
            _submitLoginButton.Click();
        }


    }
}
