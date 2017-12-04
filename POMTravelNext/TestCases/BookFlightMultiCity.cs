using NUnit.Framework;
using POMTravelNext.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace POMTravelNext
{
    [TestFixture]
    public class BookFlightMultiCity
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void BookFlightMultiCityTrip()
        {
            //Parameters Log In
            string user = "dnan@travelleaders.com";
            string pass = "P@ss123";
            string cid = "20033";
            //Parameters Search Flight
            string fromCity = "Barcelona, Spain and Canary Islands - Barcelona  El Prat Arpt (BCN)";
            string toCity = "Madrid, Spain and Canary Islands - Barajas Arpt (MAD)";
            string leave = "01/13/2018";
            string returnD = "01/28/2018";
            string fromCity2 = "Paris, France - Charles De Gaulle Intl Arpt (CDG)";
            string toCity2 = "Rome, Italy - Fiumicino Arpt (FCO)";
            string leave2 = "02/02/2018";
            //Parameters Guest User Log In
            string fName = "Malcom";
            string lName = "Young";
            string email = "malcom@acdc.com";
            string areaP = "312";
            string numberP = "6905367";
            string gender = "Male";
            string day = "7";
            string month = "9";
            string year = "1997";
            //Parameters Traveler Details
            string title = "Dr.";
            string middle = "Jay";

            //Parameters Credit Card
            string cardNumber = "4111111111111111";
            string cvvNumber = "123";
            string nameCard = "Rohan Pandit";

            //Parameters Billing Address
            string addressLine1 = "Legacy Drive Suite 53600";
            string city = "Piano";
            //string country = "United States";
            string zip = "75034";
            //string state = "Texas";
            string areaBilling = "9090";
            string phoneBilling = "89890898875";

            LoginPage goTo = new LoginPage(driver);
            goTo.GoToPage();
            Assert.True(goTo.IsPageOpened());
            goTo.LogOn(user, pass, cid);
            BackOfficePage backOff = new BackOfficePage(driver);
            backOff.ClickFrontOffice();
            HotelPage hotel = new HotelPage(driver);
            Thread.Sleep(2000);
            hotel.ClickFlightLink();

            Assert.True(driver.Title.Contains("Mystique"));
            FlightPage flight = new FlightPage(driver);
            flight.SelectMultiCity();
            flight.SearchFlightMultiCity(fromCity, toCity, leave, fromCity2, toCity2, leave2);

            Thread.Sleep(2000);
            //MultipleLocationPage multi = new MultipleLocationPage(driver);
            //multi.ClickContinue();
            ResultsPage results = new ResultsPage(driver);
            results.ResultsPageActions();
            ItineraryPage itinerary = new ItineraryPage(driver);
            Assert.True(driver.Title.Contains("Trip folder"));
            itinerary.ClickCheckout();

            Assert.True(driver.Title.Contains("Checkout"));
            CheckOutPage checkOut = new CheckOutPage(driver);
            checkOut.CompleteTravelerDetails(title, fName, middle, lName, email, gender, day, month, year);
            checkOut.EnterCreditCard(cardNumber, cvvNumber, nameCard);
            checkOut.EnterBillingAddress(addressLine1, city, zip, areaBilling, phoneBilling);
            checkOut.Purchase();
            checkOut.ConfirmPurchase();
            Thread.Sleep(10000);
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}


