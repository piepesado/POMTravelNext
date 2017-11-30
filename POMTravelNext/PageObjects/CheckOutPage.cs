using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace POMTravelNext.PageObjects
{
    class CheckOutPage
    {
        IWebDriver driver;

        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Pax Details Locators
        
        //Dropdown
        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_ddlTitle")]
        private IWebElement paxTitle;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_txtFName")]
        private IWebElement paxFirst;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_txtMName")]
        private IWebElement paxMiddle;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_txtLName")]
        private IWebElement paxLast;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_txtEmailAdd")]
        private IWebElement paxEmail;

        //Dropdowns
        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_drpGender")]
        private IWebElement paxGender;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_drpMonth")]
        private IWebElement paxMonth;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_drpDate")]
        private IWebElement paxDay;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl00_57511_ucPassengerInfo_rptTripInfo_ctl00_rptPassenger_ctl00_paxDetail_drpYear")]
        private IWebElement paxYear;

        //Payment Locators

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_txtCardNumber")]
        private IWebElement cardNumber;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_txtCcvNumber")]
        private IWebElement cvvNumber;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_txtCardHolderName")]
        private IWebElement cardName;

        //Dropdowns
        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_ddlMonth")]
        private IWebElement expMonth;
        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_ddlYear")]
        private IWebElement expYear;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_ctl00_txtAddressLine1")]
        private IWebElement addressLine;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_ctl00_txtAddressLine2")]
        private IWebElement addressLine2;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_ctl00_txtCity")]
        private IWebElement cityCard;

        //Dropdown
        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_ctl00_ddlCountry")]
        private IWebElement countryCard;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_ctl00_txtPostalCode")]
        private IWebElement zipCode;

        //Dropdown
        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_ctl00_ddlState")]
        private IWebElement State;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_txtContactCode")]
        private IWebElement areaCode;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_ctlCCPayment_txtContactNumber")]
        private IWebElement phoneNumber;

        //Checkbox
        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_cbTermsConditions")]
        private IWebElement chkAgreement;

        [FindsBy(How = How.Id, Using = "ucPWP_ctl16_57507_ctl01_57512_dvBtnPurchase")]
        private IWebElement purchaseNowButton;

        //Actions

        public void CompleteTravelerDetails(string title, string name, string middle, string last, string email)
        {
            //Should I use int for numbers and then convert them to string?
            new SelectElement(paxTitle).SelectByText(title);
            paxFirst.SendKeys(name);
            paxMiddle.SendKeys(middle);
            paxLast.SendKeys(last);
            paxEmail.SendKeys(email);
            new SelectElement(paxGender).SelectByText("Male");
            new SelectElement(paxMonth).SelectByIndex(3);
            new SelectElement(paxMonth).SelectByIndex(4);
            //It does not enter month, its not being validated, since birth date is mandatory
            new SelectElement(paxYear).SelectByIndex(10);
        }

        public void EnterCreditCard(string number, string cvv, string name)
        {
            cardNumber.SendKeys(number);
            cvvNumber.SendKeys(cvv);
            cardName.SendKeys(name);
            new SelectElement(paxMonth).SelectByIndex(4);
            new SelectElement(paxYear).SelectByIndex(2);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", addressLine);
        }

        public void EnterBillingAddress(string address1, string city, string zip, string area, string phone)
        {
            addressLine.SendKeys(address1);            
            cityCard.SendKeys(city);
            new SelectElement(countryCard).SelectByText("United States");
            zipCode.SendKeys(zip);
            new SelectElement(State).SelectByText("Texas");
            areaCode.SendKeys(area);
            phoneNumber.SendKeys(phone);                     
        }

        public void Purchase()
        {
            chkAgreement.Click();
            purchaseNowButton.Click();
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
        } 
    

    }
}
