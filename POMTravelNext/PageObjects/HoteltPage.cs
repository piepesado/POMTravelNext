﻿using System;
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
        [FindsBy(How = How.Id, Using = "liflightTab")]
        private IWebElement FlightLink;

        public void ClickFlightLink()
        {
            FlightLink.Click();

        }

    }
}