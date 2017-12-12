using OpenQA.Selenium;
using POMTravelNext.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace POMTravelNext
{
    [Binding]
    public class LoginStepsWrongCredentials
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private BackOfficePage _backOfficePage;

        [Given(@"I enter wrong password")]
        public void GivenIEnterWrongPassword()
        {
            _loginPage = LoginPage
        }
        
        [Given(@"I click capctha field")]
        public void GivenIClickCapcthaField()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should not able to land on the Backoffice page")]
        public void ThenIShouldNotAbleToLandOnTheBackofficePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"a warning message is displayed on screen")]
        public void ThenAWarningMessageIsDisplayedOnScreen()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
