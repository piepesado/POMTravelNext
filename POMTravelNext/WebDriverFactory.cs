using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace POMTravelNext
{
    static class WebDriverFactory
    {
        //Create an instance of a web driver
        internal static IWebDriver Create()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("window-size=720x1280");
            IWebDriver driver = new ChromeDriver(options);
            return driver;
        }
    }
}
