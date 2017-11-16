using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace POMTravelNext.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2524_ctl00_2597_txtUserName")]
        private IWebElement UserName { get; set; }// Why should this getters and setters be used?

        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2524_ctl00_2597_txtPassword")]
        private IWebElement passWord;

        [FindsBy(How = How.Id, Using = "recaptcha_response_field")]
        private IWebElement captchaField;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2524_ctl00_2597_txtContextId")]
        private IWebElement cidNumber;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2524_ctl00_2597_lnkBtnSignIn")]
        private IWebElement signIn;

        // Add forgot password link

        public void GoToPage()
        {
            driver.Navigate().GoToUrl("http://managedemo.travelnxt.com/Login");
        }

        public bool IsPageOpened()// Shouldnt be an Assert be implemented here?
        {// This should be added to a Helper class to be common for all page objects
            return driver.Title.Equals("Login");
        }

        public void LogOn(string user, string pass, string cid)
        {
            UserName.SendKeys(user);
            passWord.SendKeys(pass);
            cidNumber.SendKeys(cid);
            captchaField.Click();
            Thread.Sleep(10000);
            signIn.Click();            
        }
    }
}
