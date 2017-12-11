using System.Threading;
using TechTalk.SpecFlow;
using POMTravelNext.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace POMTravelNext.SpecFlow.Login
{
    [Binding]
    public class LoginSteps
    {

        private IWebDriver _driver;
        private LoginPage _loginPage;
        private BackOfficePage _backOfficePage;

        [Given(@"that I navigate to TravelNext application")]
        public void GivenThatINavigateToTravelNextApplication()
        {
            _driver = WebDriverFactory.Create();
            _loginPage = LoginPage.NavigateTo(_driver);
        }
        
        [Given(@"I enter dnan@travelleaders\.com as the username")]
        public void GivenIEnterDnanTravelleaders_ComAsTheUsername()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter the password")]
        public void GivenIEnterThePassword()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I enter (.*) as the CID")]
        public void GivenIEnterAsTheCID(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I wait (.*) seconds to input captcha")]
        public void GivenIWaitSecondsToInputCaptcha(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press Login button")]
        public void WhenIPressLoginButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should land on the Backoffice page")]
        public void ThenIShouldLandOnTheBackofficePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
