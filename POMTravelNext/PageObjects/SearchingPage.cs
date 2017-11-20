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

        

        public void WaitForBar()
        {    
            
            Helper.WaitForElementVisible(driver, progressBar);
        }
    }
}
