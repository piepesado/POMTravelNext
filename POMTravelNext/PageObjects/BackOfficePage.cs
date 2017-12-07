using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace POMTravelNext.PageObjects
{
    class BackOfficePage
    {
        IWebDriver driver;

        public BackOfficePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.Id, Using = "ucPWP_ctl07_2517_lnkFO")]
        private IWebElement frontOfficeButton;

        public void ClickFrontOffice()
        {
            frontOfficeButton.Click();
        }
    }

    
}
