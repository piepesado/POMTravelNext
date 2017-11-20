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
    class HotelPage
    {
        IWebDriver driver;

        public HotelPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Hotel locators
        [FindsBy(How = How.LinkText, Using = "Flight")]
        private IWebElement flightLink;
        
        
        

        public void ClickFlightLink()
        {
            // Helper.WaitForElementVisible(driver, flightLink);
            flightLink.Click();

        }

    }
}
