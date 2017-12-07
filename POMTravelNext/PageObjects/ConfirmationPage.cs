using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace POMTravelNext.PageObjects
{
    class ConfirmationPage
    {
        IWebDriver driver;

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Elements
        [FindsBy(How = How.Id, Using = "dvTripId")]
        private IWebElement tripIdLabel;

        [FindsBy(How = How.CssSelector, Using = "div.templar_PageContainer div.ContentPanel div.MiddlePanel div.dl_inner_column_content div.dl_sright_btm table.layout_holder table.table_style td:nth-child(5) div:nth-child(1) span.lineHeightL.font_12 span:nth-child(1) > a:nth-child(1)")]
        private IWebElement eTicketLink;

        [FindsBy(How = How.CssSelector, Using = "div.templar_PageContainer div.ContentPanel div.MiddlePanel div.dl_inner_column_content div.dl_sright_btm table.layout_holder table.table_style tr:nth-child(3) td:nth-child(5) div:nth-child(1) span.lineHeightL.font_12 > a:nth-child(2)")]
        private IWebElement customerIncvoiceLink;

        [FindsBy(How = How.CssSelector, Using = "div.templar_PageContainer div.ContentPanel div.MiddlePanel div.dl_inner_column_content div.dl_sright_btm table.layout_holder table.table_style td:nth-child(5) div:nth-child(1) span.lineHeightL.font_12 span:nth-child(3) > a:nth-child(1)")]
        private IWebElement agentInvoiceLink;

        [FindsBy(How = How.Id, Using = "baseFareBreakup0")]
        private IWebElement breakUpLinkBase;

        [FindsBy(How = How.Id, Using = "lnkfarebreakup0")]
        private IWebElement breakUpLinkTaxes;

        //Actions
        public Boolean CheckLinksPresent()
        {
            Boolean present = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(eTicketLink));
            if (eTicketLink.Displayed && customerIncvoiceLink.Displayed && agentInvoiceLink.Displayed)
                present = true;
            return present;
        }

        public void ScrollBottomPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(tripIdLabel));            
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
        }

        public Boolean BreakupLinksPresent()
        {
            Boolean present = false;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(breakUpLinkBase));
            if (breakUpLinkBase.Enabled && breakUpLinkTaxes.Enabled)
                present = true;
            return present;
        }
    }
}
