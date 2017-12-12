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
        
        [Given(@"I enter (.*) as the username")]
        public void GivenIEnterTheUsername(string userName)
        {
            _loginPage.Username = userName;
        }
        
        [Given(@"I enter the password")]
        public void GivenIEnterThePassword()
        {
            _loginPage.Password = "P@ss123";
        }
        
        [Given(@"I enter (.*) as the CID")]
        public void GivenIEnterAsTheCID(string cid)
        {
            _loginPage.Cid = cid;
        }

        [Given(@"I click captcha field")]
        public void GivenIClickCaptcha()
        {
            return;//What assignment should I use?, Click action on captcha field is implemented at captcha setter
        }

        [Given(@"I wait (.*) seconds to input captcha")]
        public void GivenIWaitSecondsToInputCaptcha(int seconds)
        {
            Thread.Sleep(seconds * 1000);//When is seconds declared?
        }
        
        [When(@"I press Login button")]
        public void WhenIPressLoginButton()
        {
            _backOfficePage = _loginPage.Login();//I call backoffice class since this action results in going to that class?            
        }
        
        [Then(@"I should land on the Backoffice page")]
        public void ThenIShouldLandOnTheBackofficePage()
        {
            _backOfficePage.EnsurePageIsLoaded();
            Assert.AreEqual("home", _driver.Title);
        }

        [AfterScenario]
        public void CleanUp()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}
