﻿using System;
using NUnit.Framework;
using POMTravelNext.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace POMTravelNext
{
    [TestFixture]
    public class BookFlightMainPath
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void BookFlight()
        {
            //Parameters
            string user = "dnan@travelleaders.com";
            string pass = "P@ss123";
            string cid = "20033";
            string fromCity = "Montevideo";
            string toCity = "Dublin";
            string leave = "03/03/2018";
            string returnD = "03/04/2018";

            LoginPage goTo = new LoginPage(driver);
            goTo.GoToPage();
            Assert.True(driver.Title.Equals("Login"));
            
            LoginPage log = new LoginPage(driver);
            log.LogOn(user, pass, cid);
            
            BackOfficePage backOff = new BackOfficePage(driver);
            backOff.ClickFrontOffice();

            HotelPage hotel = new HotelPage(driver);
            hotel.ClickFlightLink();
            // driver.Manage().Timeouts().PageLoad()

            Assert.True(driver.Title.Contains("Mystique"));
            FlightPage flight = new FlightPage(driver);
            flight.SearchFlight(fromCity, toCity, leave, returnD);
            Thread.Sleep(5000);

        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}