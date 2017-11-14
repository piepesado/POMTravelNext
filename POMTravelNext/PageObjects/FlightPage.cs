using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
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

        //Leave and Return dropdowns    
        //[FindsBy(How = How.ClassName, Using = "ucPWP_ctl14_12066_ddlFlightDepartTime")]
        //public IList<IWebElement> leaveTime { get; set; }


        //public void LeaveTime(int index)
        //{
        //    var leaveT = driver.FindElement(By.Id("ucPWP_ctl14_12066_ddlFlightDepartTime"));
        //    var SelectElement = new SelectElement(leaveT);             
        //}



        //Search button
        [FindsBy(How = How.Id, Using = "ucPWP_ctl14_12066_btnSearch")]
        private IWebElement searchButton;

        //public void SelectLeaveTimeValue(String leaveTimeValue)
        //{
        //    leaveTime        
        //}

        public void SearchFlight(string from, string to, string leaveDate, string returnDate)
        {
            fromField.SendKeys(from);
            fromField.SendKeys(Keys.Tab);
            toField.SendKeys(to);
            toField.SendKeys(Keys.Tab);
            leaveDatePicker.SendKeys(leaveDate);
            returnDatePicker.SendKeys(returnDate);
            
            searchButton.Click();
        }
    }
}
