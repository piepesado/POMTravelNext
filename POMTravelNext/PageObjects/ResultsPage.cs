using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace POMTravelNext.PageObjects
{
    class ResultsPage 
    {
        IWebDriver driver;

        public ResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ("#btn_AddToCart_0"))]
        private IWebElement addToCart;

        [FindsBy(How = How.Id, Using = ("btnCartContinue"))]
        private IWebElement continueShopping;

        [FindsBy(How = How.Id, Using = ("btnCheckOutCart"))]
        private IWebElement checkOutButton;

        // Sliders links
        [FindsBy(How = How.Id, Using = ("divSectionPrice"))]
        private IWebElement priceFilter;

        [FindsBy(How = How.Id, Using = ("divSectionStops"))]
        private IWebElement stopsFilter;

        [FindsBy(How = How.Id, Using = ("divSectionAirLines"))]
        private IWebElement airlinesFilter;

        [FindsBy(How = How.Id, Using = ("divSectionFlightTimes"))]
        private IWebElement flightTimesFilter;

        [FindsBy(How = How.Id, Using = ("divSectionTripDuration"))]
        private IWebElement divSectionFilter;

        [FindsBy(How = How.Id, Using = ("listTab"))]
        private IWebElement listView;
        
        // Sorts
        [FindsBy(How = How.Id, Using = ("priceSortLink"))]
        private IWebElement sortByFare;

        [FindsBy(How = How.Id, Using = ("deptSortLink"))]
        private IWebElement sortByDeparture;

        [FindsBy(How = How.Id, Using = ("arrSortLink"))]
        private IWebElement sortByArrival;

        [FindsBy(How = How.Id, Using = ("stopSortLink"))]
        private IWebElement sortByStops;

        [FindsBy(How = How.Id, Using = ("durationSortLink"))]
        private IWebElement sortByDuration;
        
        [FindsBy(How = How.Id, Using = ("sortbar"))]
        private IWebElement sortByLabel;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl10_11883_lnkSearches"))]
        private IWebElement mySearchedButton;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl11_11884_dvMS"))]
        private IWebElement closeSearchedButtonForm;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl10_11883_MySearchCount"))]
        public IWebElement tripCartQty;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl10_11883_MySearchCount"))]
        public IWebElement cartCounter;

        [FindsBy(How = How.Id, Using = ("ucPWP_ctl10_11883_lnkTrips"))]
        public IWebElement tripCart;

        public void SortByList()
        {
            Helper.WaitForElementVisible(driver, listView);
            listView.Click();
        }

        public void HidePriceFilter()
        {
            Helper.WaitForElementVisible(driver, priceFilter);            
            priceFilter.Click();
        }

        public void AddFlightToCart()
        {
            // Scroll until the element is visible
            Helper.WaitForElementVisible(driver, addToCart);          
            
            //Actions addFlight = new Actions(driver);            
            addToCart.Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", addToCart);
            //.Build()
            //.Perform();
        }

        public void ClickSortButtons()
        {            
            sortByDeparture.Click();
            sortByArrival.Click();
            sortByStops.Click();
            sortByDuration.Click();
        }

        public void MySearches()
        {
            mySearchedButton.Click();            
            closeSearchedButtonForm.Click();
            Thread.Sleep(2000);
        }

        public void CheckCart()
        {
            // Assert.IsTrue(tripCart.Text("Trip Cart");
        }    
        
        public Boolean CheckTripCartQty()
        {
            Boolean areEqual = false;              
            if (tripCartQty.Text == "1")
                areEqual = true;
            return areEqual; 
        }

        public Boolean PageSource()
        {
            Boolean contains = false;
            if (driver.PageSource.Contains("btn_AddToCart_0"))
                contains = true;
            return contains;            
        }

        public void ClickCheckOut()
        {
            Helper.WaitForElementVisible(driver, continueShopping);
            checkOutButton.Click();
        }

        public void ResultsPageActions()
        {
            SortByList();
            HidePriceFilter();
            ClickSortButtons();
            MySearches();
            AddFlightToCart();
            ClickCheckOut();
        }
        
    }
}
