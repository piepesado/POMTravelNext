using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using System;

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

        //Elements for multiple city

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightDepartLoc1")]
        private IWebElement fromField1;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightArriveLoc1")]
        private IWebElement toField1;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightDepartLoc2")]
        private IWebElement fromField2;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightArriveLoc2")]
        private IWebElement toField2;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightDepartDate1")]
        private IWebElement returnDatePicker1;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_txtFlightDepartDate2")]
        private IWebElement returnDatePicker2;

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

        public void SelectOneWayTrip()
        {
            oneWayRadio.Click();
        }

        public void SelectMultiCity()
        {
            multiCityTripRadio.Click();
        }
        
        public void SearchFlight(string from, string to, string leaveDate, string returnDate)
        {
            fromField.SendKeys(from);
            fromField.SendKeys(Keys.Tab);
            toField.SendKeys(to);
            toField.SendKeys(Keys.Tab);
            leaveDatePicker.SendKeys(leaveDate);
            returnDatePicker.SendKeys(returnDate);
            //new SelectElement(leaveHourDrop).SelectByText(leaveH);
            //new SelectElement(returnHourDrop).SelectByText(returnH);
            if(!nearAirChk.Selected)
                nearAirChk.Click();
            searchButton.Click();
        }
        
        public void SearchFlightMultiCity(string from1, string to1, string leaveDate1, string from2, string to2, string leaveDate2)
        {
            fromField1.SendKeys(from1);
            fromField1.SendKeys(Keys.Tab);
            toField1.SendKeys(to1);
            toField1.SendKeys(Keys.Tab);
            returnDatePicker1.SendKeys(leaveDate1);
            returnDatePicker1.SendKeys(Keys.Tab);

            fromField2.SendKeys(from2);
            fromField2.SendKeys(Keys.Tab);
            toField2.SendKeys(to2);
            toField2.SendKeys(Keys.Tab);
            returnDatePicker2.SendKeys(leaveDate2);

            //new SelectElement(leaveHourDrop).SelectByText(leaveH);
            //new SelectElement(returnHourDrop).SelectByText(returnH);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(nearAirChk));
            if (!nearAirChk.Selected)
                nearAirChk.Click();
            searchButton.Click();
        }
        public void SearchFlightOneWay(string from, string to, string leaveDate)
        {
            fromField.SendKeys(from);
            toField.SendKeys(to);
            leaveDatePicker.SendKeys(leaveDate);
            searchButton.Click();
        }
    }
}
