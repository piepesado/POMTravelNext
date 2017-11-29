using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMTravelNext.PageObjects
{
    class ItineraryPage
    {
        IWebDriver driver;

        public ItineraryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "checkout")]
        private IWebElement itineraryCheckout;

        public void ClickCheckout()
        {
            Helper.WaitForElementVisible(driver, itineraryCheckout);
            itineraryCheckout.Click();
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", itineraryCheckout);
        }
    }

    


}
