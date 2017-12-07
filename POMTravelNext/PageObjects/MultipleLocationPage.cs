using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace POMTravelNext.PageObjects
{
    class MultipleLocationPage
    {
        IWebDriver driver;

        public MultipleLocationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl16_11889_ctl00_12076_btnContinue"))]
        private IWebElement continueButton;

        public void ClickContinue()
        {
            continueButton.Click();
            //Thread.Sleep(7000);
        }
    }
}
