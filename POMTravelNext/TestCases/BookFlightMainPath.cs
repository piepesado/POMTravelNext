using NUnit.Framework;
using POMTravelNext.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace POMTravelNext
{
    [TestFixture]
    public class BookFlightMainPath
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
            //Parameters Log In
            string user = "dnan@travelleaders.com";
            string pass = "P@ss123";
            string cid = "20033";
            //Parameters Search Flight
            string fromCity = "Madrid";// If there are multiple values for a given city multiple location page is displayed
            string toCity = "Paris";
            string leave = "01/13/2018";
            string returnD = "01/28/2018";
            //string leaveH = "11:00 AM";
            //string returnH = "10:00 PM";
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
            //string gender = "Male";
            /*
            Dont know why its not able to find birthday dropdowns when selection is passed by index or strings.
            int month = 3;
            int day = 4;
            int year = 10;
            */

            //Parameters Credit Card
            string cardNumber = "4111111111111111";
            string cvvNumber = "123";
            string nameCard = "Rohan Pandit";
            //string expMonth = "Apr";
            //string expYear = "2018";

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
            flight.ClickRadioButtons();            
            flight.SearchFlight(fromCity, toCity, leave, returnD);          

            Thread.Sleep(2000);
            MultipleLocationPage multi = new MultipleLocationPage(driver);
            multi.ClickContinue();            
            ResultsPage results = new ResultsPage(driver);            
            results.ResultsPageActions();
            ItineraryPage itinerary = new ItineraryPage(driver);
            Assert.True(driver.Title.Contains("Trip folder"));
            itinerary.ClickCheckout();            
            
            //UserPage userLog = new UserPage(driver);
            Assert.True(driver.Title.Contains("Checkout"));
            //userLog.LogAsGuest(fName, lName, email, email, areaP, numberP);
            //userLog.SubmitGuest();
            CheckOutPage checkOut = new CheckOutPage(driver);
            checkOut.CompleteTravelerDetails(title, fName, middle, lName, email, gender, day, month, year);            
            checkOut.EnterCreditCard(cardNumber, cvvNumber, nameCard);            
            checkOut.EnterBillingAddress(addressLine1, city, zip, areaBilling, phoneBilling);
            checkOut.Purchase();            
            checkOut.ConfirmPurchase();
            Thread.Sleep(5000);
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
