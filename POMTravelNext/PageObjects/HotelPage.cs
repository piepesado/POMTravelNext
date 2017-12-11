using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace POMTravelNext.PageObjects
{
    public class HotelPage : BasePage
    {        

        //Hotel locators
        [FindsBy(How = How.LinkText, Using = "Flight")]
        private IWebElement flightLink;
        
        public HotelPage(IWebDriver driver) : base(driver)
        {

        }              

        public void ClickFlightLink()
        {
            // Helper.WaitForElementVisible(driver, flightLink);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(flightLink));
            flightLink.Click();

        }

    }
}
