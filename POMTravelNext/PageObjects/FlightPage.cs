using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;

namespace POMTravelNext.PageObjects
{
    class FlightPage
    {
        IWebDriver driver;

        public FlightPage(IWebDriver driver)
        {
            // Constructor and elements initialization
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //From and To fields
        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightDepartLoc")]
        private IWebElement fromField;
        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightArriveLoc")]
        private IWebElement toField;

        //Datepickers
        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightDepartDate")]
        private IWebElement leaveDatePicker;
        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightArriveDate")]
        private IWebElement returnDatePicker;

        //Dropdowns
        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_ddlFlightDepartTime")]
        private IWebElement leaveHourDrop;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_ddlFlightArriveTime")]
        private IWebElement returnHourDrop;

        // Checkbox
        [FindsBy(How = How.Name, Using = "ucPWP$ctl14$12066$cbxNearbyAirports")]
        private IWebElement nearAirChk;

        // Radio buttons
        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_radRoundTrip")]
        private IWebElement roundTripRadio;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_radOneWayTrip")]
        private IWebElement oneWayRadio;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_radMultipleDestns")]
        private IWebElement multiCityTripRadio;      

        //Search button
        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_btnSearch")]
        private IWebElement searchButton;     

        // Actions
        public void SelectTime()
        {
            Actions selectHours = new Actions(driver);            
            selectHours.MoveToElement(leaveHourDrop);
            selectHours.Click();
            selectHours.Perform();
        }

        public void ClickRadioButtons()
        {
            oneWayRadio.Click();
            multiCityTripRadio.Click();
            roundTripRadio.Click();
        }
        
        public void SearchFlight(string from, string to, string leaveDate, string returnDate, string leaveH, string returnH)
        {
            fromField.SendKeys(from);
            fromField.SendKeys(Keys.Tab);
            toField.SendKeys(to);
            toField.SendKeys(Keys.Tab);
            leaveDatePicker.SendKeys(leaveDate);
            returnDatePicker.SendKeys(returnDate);
            new SelectElement(leaveHourDrop).SelectByText(leaveH);
            new SelectElement(returnHourDrop).SelectByText(returnH);
            nearAirChk.Click();
            searchButton.Click();
        }
    }
}
