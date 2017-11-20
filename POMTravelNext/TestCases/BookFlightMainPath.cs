using System;
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

        public IWebElement tripCartQty { get; private set; }

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
            string fromCity = "New York";// If there are multiple values for a given city multiple location page is displayed
            string toCity = "Paris";
            string leave = "03/03/2018";
            string returnD = "03/04/2018";
            string leaveH = "3:00 AM";
            string returnH = "12:00 AM";

            LoginPage goTo = new LoginPage(driver);
            goTo.GoToPage();

            Assert.True(goTo.IsPageOpened());
            
            goTo.LogOn(user, pass, cid);
            
            BackOfficePage backOff = new BackOfficePage(driver);
            backOff.ClickFrontOffice();

            HotelPage hotel = new HotelPage(driver);
            Thread.Sleep(2000);
            hotel.ClickFlightLink();            

            Assert.True(driver.Title.Contains("Mystique"));
            FlightPage flight = new FlightPage(driver);            
            flight.ClickRadioButtons();
            // Assert.IsTrue(driver.Title.Equals("BugFixer :: Home"));
            flight.SearchFlight(fromCity, toCity, leave, returnD, leaveH, returnH);            

            Thread.Sleep(2000);

            MultipleLocationPage multi = new MultipleLocationPage(driver);
            multi.ClickContinue();

            SearchingPage search = new SearchingPage(driver);
            // search.WaitForBar();

            ResultsPage results = new ResultsPage(driver);
            // results.SortByList();  
            
            results.HidePriceFilter();
            Thread.Sleep(2000);
            // results.ClickSortButtons();
            results.MySearches();
            // What effective parameter should I use on this function invocation?            
           // Assert.IsTrue(results.CheckTripCartQty(tripCartQty));
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
