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
            LoginPage log = new LoginPage(driver);
            log.LogOn(userName, passWord, cidNumber);
        }
    }
}
