using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace POMTravelNext.PageObjects
{
    public class LoginPage : BasePage
    {
        private const string PAGE_URL = "http://managedemo.travelnxt.com/Login";

        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2524_ctl00_2597_txtUserName")]
        private IWebElement userName;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2524_ctl00_2597_txtPassword")]
        private IWebElement passWord;

        [FindsBy(How = How.Id, Using = "recaptcha_response_field")]
        private IWebElement captchaField;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2524_ctl00_2597_txtContextId")]
        private IWebElement cidNumber;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2524_ctl00_2597_lnkBtnSignIn")]
        private IWebElement signIn;

        //Getters and Setters
        public string Username
        {
            get
            {
                return userName.Text;
            }
            set
            {
                userName.SendKeys(value);
            }
        }

        public string Password
        {
            get
            {
                return passWord.Text;
            }
            set
            {
                passWord.SendKeys(value);
            }
        }

        public string Cid
        {
            get
            {
                return cidNumber.Text;
            }
            set
            {
                cidNumber.SendKeys(value);
            }
        }

        //Constructor
        //What does this do?
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        //if driver is not initialized it will throw an exception?
        public static LoginPage NavigateTo(IWebDriver driver)
        {
            if(driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }

            driver.Navigate().GoToUrl(PAGE_URL);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("Login"));//what does d => means?
            return new LoginPage(driver);
        }

        public BackOfficePage Login()
        {
            signIn.Click();
            return new BackOfficePage(_driver);
        }
      
    }
}
