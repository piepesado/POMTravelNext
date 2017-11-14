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

        [FindsBy(How = How.Id, Using = ("btn_AddToCart_0"))]
        private IWebElement addToCart;

        [FindsBy(How = How.Id, Using = ("lblPrice"))]
        private IWebElement priceFilter;

        [FindsBy(How = How.Id, Using = ("listTab"))]
        private IWebElement listView;

        public void SortByList()
        {
            listView.Click();
        }


        public void SelectFlight()
        {
            // WaitForElementVisible(driver, priceFilter);
            
            addToCart.Click();
        }
    }
}
