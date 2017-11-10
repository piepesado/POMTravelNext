using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMTravelNext.PageObjects
{
    class BackOfficePage
    {
        //Do I have to copy driver and element inicialization?
        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2517_lnkFO")]
        private IWebElement frontOfficeButton;

        public void ClickFrontOffice()
        {
            this.frontOfficeButton.Click();
        }
    }

    
}
