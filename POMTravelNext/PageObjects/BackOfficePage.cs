using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace POMTravelNext.PageObjects
{
    public class BackOfficePage : BasePage
    {        
        
        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2517_lnkFO")]
        private IWebElement frontOfficeButton;

        //Constructor
        public BackOfficePage(IWebDriver driver) : base(driver)
        {

        }

        public void EnsurePageIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("home"));
        }


        public HotelPage GoToFrontOffice()
        {
            frontOfficeButton.Click();
            return new HotelPage(_driver);
        }
    }

    
}
