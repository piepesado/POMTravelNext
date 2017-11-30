using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace POMTravelNext.PageObjects
{
    class UserPage
    {
        IWebDriver driver;

        public UserPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl17_11914_ctl00_12052_GUPtxtFirstName"))]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl17_11914_ctl00_12052_GUPtxtLastName"))]
        private IWebElement lastName;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl17_11914_ctl00_12052_GUPtxtEmail"))]
        private IWebElement email;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl17_11914_ctl00_12052_GUPtxtVerifyEmail"))]
        private IWebElement verifyEmail;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl17_11914_ctl00_12052_GUPtxtContactCode"))]
        private IWebElement areaPhone;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl17_11914_ctl00_12052_GUPtxtContactNumber"))]
        private IWebElement numberPhone;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl17_11914_ctl00_12052_GUPbtnSubmit"))]
        private IWebElement submitGuest;

        public void LogAsGuest(string first, string last, string emailA, string verify, string area, string number)
        {
            //new WebDriverWait((driver, TimeSpan.FromSeconds(ITimeouts)).Until(ExpectedConditions.ElementExists(firstName)));
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.ElementToBeClickable(firstName));
            
            //IWait.Until(ExpectedConditions.ElementToBeClickable(firstName));
            firstName.SendKeys(first);
            lastName.SendKeys(last);
            email.SendKeys(emailA);
            verifyEmail.SendKeys(verify);
            areaPhone.SendKeys(area);
            numberPhone.SendKeys(number);
        }

        public void SubmitGuest()
        {
            submitGuest.Click();
        }

    }
}
