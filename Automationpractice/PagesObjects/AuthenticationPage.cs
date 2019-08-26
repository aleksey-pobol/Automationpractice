using System;
using System.Threading;
using System.Threading.Tasks;
using Automationpractice.WrapperFactory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Automationpractice.PagesObjects
{
    public class AuthenticationPage
    {        
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

        [FindsBy(How = How.XPath, Using = "//input[@name='email_create']")]
        private IWebElement emailCreateField;

        [FindsBy(How = How.XPath, Using = "//button[@id='SubmitCreate']")]
        private IWebElement submitCreateButton;

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
            WebDriverWait wait = new WebDriverWait( WebDriverFactory.Driver, TimeSpan.FromSeconds(10) );
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
