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
    class SearchingPage
    {
        IWebDriver driver;

        public SearchingPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = ("dvPreloader"))]
        private IWebElement progressBar;

        

        public static Boolean WaitForElementVisible(IWebDriver driver, IWebElement element)
        {//This should be implemented on a Helper class
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(d => (bool)(element as IWebElement).Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForBar()
        {
            // WaitForElementVisible(driver, priceFilter);
            
            WaitForElementVisible(driver, progressBar);
        }
    }
}
