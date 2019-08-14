using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Automationpractice.PagesObjects
{
    class AuthenticationPage
    {
        private readonly IWebDriver _driver;
        private String firstname = "Aleksey";
        private String lasttname = "Pobol";
        private String email = "test3@mail.com";
        private String password = "aleksey96";


        public String randomEmail()
        {
            Random rnd = new Random(Environment.TickCount);
            int value = rnd.Next();
            String EmailAddress = $"test{value}@mail.com";
            return EmailAddress;
        }

        public AuthenticationPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='email_create']")]
        public IWebElement emailCreateField;

        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitCreate']")]
        public IWebElement submitCreateButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_firstname']")]
        public IWebElement customerFirstnameField;

        [FindsBy(How = How.XPath, Using = "//input[@id='customer_lastname']")]
        public IWebElement customerLastameField;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        public IWebElement emailRegField;

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        public IWebElement passwdField;

        [FindsBy(How = How.XPath, Using = "//input[@id='address1']")]
        public IWebElement regAdressField;

        [FindsBy(How = How.XPath, Using = "//input[@id='city']")]
        public IWebElement regcityField;

        [FindsBy(How = How.XPath, Using = "//*[@id='uniform-id_state']")]
        public IWebElement stateSelector;

        [FindsBy(How = How.XPath, Using = "//*[@id='id_state']/option[17]")]
        public IWebElement chooseState;

        [FindsBy(How = How.XPath, Using = "//input[@id='postcode']")]
        public IWebElement postcodeField;

        [FindsBy(How = How.XPath, Using = "//input[@id='phone_mobile']")]
        public IWebElement phoneMobileField;

        [FindsBy(How = How.XPath, Using = "//input[@id='alias']")]
        public IWebElement aliasField;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitAccount']")]
        public IWebElement submitAccountButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='header_user_info']/a/span")]
        public IWebElement headerUserInfo;

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        public IWebElement emailSignInField;

        [FindsBy(How = How.XPath, Using = "//input[@id='passwd']")]
        public IWebElement passwordSignInField;

        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitLogin']")]
        public IWebElement submitLoginButton;

        public void CreateAnAccount()
        {
            emailCreateField.SendKeys(randomEmail());
            submitCreateButton.Click();
            customerFirstnameField.SendKeys(firstname);
            customerLastameField.SendKeys(lasttname);
            emailRegField.Click();
            passwdField.SendKeys("aleksey96");
            regAdressField.SendKeys("Minsk");
            regcityField.SendKeys("Minsk");
            stateSelector.Click();
            chooseState.Click();
            postcodeField.SendKeys("12345");
            phoneMobileField.SendKeys("+375251234455");
            aliasField.Clear();
            aliasField.SendKeys("Cosmos");
            submitAccountButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='header_user_info']/a/span")));
            Assert.IsTrue(headerUserInfo.Text.Equals(firstname + ' ' + lasttname));
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
