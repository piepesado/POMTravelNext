using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace POMTravelNext
{
    class Helper
    {
        IWebDriver driver;// Lots of code re use for every page object class..

        public Helper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SupportHelper(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // COMMON FUNCTIONALITIES
        public static Boolean WaitForElementVisible(IWebDriver driver, IWebElement element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(d => (element as IWebElement).Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        ////////////////////////////////////////

        //public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        //{
        //    if (timeoutInSeconds > 0)
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        return wait.Until(drv => drv.FindElement(by));
        //    }
        //    return driver.FindElement(by);
        //}

        //public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        //{
        //    if (timeoutInSeconds > 0)
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
        //    }
        //    return driver.FindElements(by);
        //}
    }
}
