using System;
using NUnit.Framework;
using POMTravelNext.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace POMTravelNext
{
    [TestFixture]
    public class TestClass
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void BookFlight()
        {
            string user = "dnan@travelleaders.com";
            string pass = "P@ss123";
            string cid = "20033";
            LoginPage log = new LoginPage(driver);
            log.LogOn(user, pass, cid);
            //Assert.True()
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
