using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

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
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(d => (element as IWebElement).Displayed);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
