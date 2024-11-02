/******************************************************************************
 * This file contains an MSTest class that contains automated tests for our register site
 *
 * Assignment #2
 * CSCN72010 Software Quality I - fall 24 - Nathan Ceci - Part B
 *
 ******************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SeleniumTestingA2
{
    [TestClass]
    public class RegistrationTests
    {

        private IWebDriver driver;

        //Runs before each individual test
        [TestInitialize]
        public void Setup()
        {
            //Set ssl exception to open website properly with web driver
            ChromeOptions handlingSSL = new ChromeOptions();
            handlingSSL.AcceptInsecureCertificates = true;
            driver = new ChromeDriver(handlingSSL);
            driver.Manage().Window.Maximize();
        }

        //Runs after each individual test
        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        /* *********************************************** *
         * Province Selection Test Cases (12 test methods)
         * *********************************************** */
        [TestMethod]
        public void Test_ProvinceSelection_Ontario_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Alice", "Wonderland", "123 Queen St", "Toronto", "Ontario", "M5H 2N2", "123-456-7890", "alice@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }
        
        //This test fails because the site doesnt properly validate phone numbers in the format (123)456-7890
        [TestMethod]
        public void Test_ProvinceSelection_Newfoundland_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Bob", "Marley", "456 King St", "St. John's", "Newfoundland", "A1A 1A1", "(234)567-8901", "bob@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_ProvinceSelection_PrinceEdwardIsland_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Charlie", "Brown", "789 Broadway", "Charlottetown", "Prince Edward Island", "C1A 1A1", "345-678-9012", "charlie@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_ProvinceSelection_NovaScotia_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Diana", "Prince", "123 Justice Ave", "Halifax", "Nova Scotia", "B3H 4R2", "456-789-0123", "diana@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_ProvinceSelection_NewBrunswick_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Edward", "Elric", "456 Alchemist St", "Fredericton", "New Brunswick", "E3B 1B5", "567-890-1234", "edward@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_ProvinceSelection_Quebec_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("François", "Dupont", "789 Rue St", "Montreal", "Quebec", "H1A 1A1", "678-901-2345", "francois@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_ProvinceSelection_Saskatchewan_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("George", "Lucas", "123 Star Rd", "Regina", "Saskatchewan", "S4P 3Y2", "789-012-3456", "george@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        //Test fails due to mispelled HTML element names "Aberta" instead of "Alberta"
        [TestMethod]
        public void Test_ProvinceSelection_Alberta_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Harry", "Potter", "4 Privet Drive", "Edmonton", "Alberta", "T5J 0N3", "890-123-4567", "harry@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        //Test fails due to mispelled HTML element named "Columbia British" instead of "British Columbia"
        [TestMethod]
        public void Test_ProvinceSelection_BritishColumbia_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Irene", "Adler", "221B Baker St", "Vancouver", "British Columbia", "V5K 0A1", "901-234-5678", "irene@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_ProvinceSelection_YukonTerritory_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Jack", "Sparrow", "Pirate Ship", "Whitehorse", "Yukon Territory", "Y1A 1A1", "012-345-6789", "jack@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        //Test fails becuase of capital W is Northwest Territories
        [TestMethod]
        public void Test_ProvinceSelection_NorthwestTerritories_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Kate", "Winslet", "Titanic Ship", "Yellowknife", "Northwest Territories", "X1A 2N5", "123-456-7890", "kate@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_ProvinceSelection_Nunavut_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Leo", "Messi", "10 Camp Nou", "Iqaluit", "Nunavut", "X0A 0H0", "234-567-8901", "leo@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }


        /* *********************************************** *
         * Number of Participants Test Cases (6 test methods)
         * *********************************************** */
        [TestMethod]
        public void Test_NumberOfParticipants_1_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Anna", "Smith", "1 First St", "City", "Ontario", "A1A 1A1", "123-456-7890", "anna@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_NumberOfParticipants_2_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Ben", "Smith", "2 Second St", "City", "Ontario", "B2B 2B2", "234-567-8901", "ben@example.com", "2", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_NumberOfParticipants_3_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Cathy", "Brown", "3 Third St", "City", "Ontario", "C3C 3C3", "345-678-9012", "cathy@example.com", "3", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_NumberOfParticipants_4_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("David", "Johnson", "4 Fourth St", "City", "Ontario", "D4D 4D4", "456-789-0123", "david@example.com", "4", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_NumberOfParticipants_5_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Eva", "Williams", "5 Fifth St", "City", "Ontario", "E5E 5E5", "567-890-1234", "eva@example.com", "5", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        [TestMethod]
        public void Test_NumberOfParticipants_6_NavigatesToViewRegistration()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Frank", "Taylor", "6 Sixth St", "City", "Ontario", "F6F 6F6", "678-901-2345", "frank@example.com", "6", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            //Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        /* *********************************************** *
         * Test cases to assert registrants attending Day 1 being charged $450 (3 test cases)
         * *********************************************** */
        //Test fails as a day 1 ticket is set to cost $350 instead of $450,
        //.67 is also getting concatinated onto the end of the price string making it $350.67
        [TestMethod]
        public void Test_Day1Price_OneParticipant_PriceIs450()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("John", "Doe", "123 Main St", "City", "Ontario", "A1A 1A1", "111-111-1111", "john.doe@example.com", "1", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            //Assert
            Assert.AreEqual(450m, price);
        }

        //Test fails as day 1 tickets is set to cost $350 instead of $450,
        //350x2 is the 700 we get instead of the 900
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_Day1Price_TwoParticipants_PriceIs900()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Jane", "Smith", "456 Main St", "City", "Ontario", "B2B 2B2", "222-222-2222", "jane.smith@example.com", "2", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            //Assert
            Assert.AreEqual(900m, price);
        }

        //Test fails as day 1 tickets is set to cost $350 instead of $450,
        //350x3 is the 1050 we get instead of the 1350
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_Day1Price_ThreeParticipants_PriceIs1350()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Alice", "Johnson", "789 Main St", "City", "Ontario", "C3C 3C3", "333-333-3333", "alice.johnson@example.com", "3", true, false);
            //Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            // Assert
            Assert.AreEqual(1350m, price);
        }



        /* *********************************************** *
         * Test cases to assert registrants attending Day 2 being charged $350 (3 test cases)
         * *********************************************** */
        //Test fails as day 2 tickets is set to cost $450 instead of $350,
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_Day2Price_OneParticipant_PriceIs350()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Bob", "Brown", "123 Oak St", "City", "Ontario", "D4D 4D4", "444-444-4444", "bob.brown@example.com", "1", false, true);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            // Assert
            Assert.AreEqual(350m, price);
        }

        //Test fails as day 2 tickets is set to cost $450 instead of $350,
        //450x2 is the 900 we get instead of the 700
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_Day2Price_TwoParticipants_PriceIs700()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Carol", "Davis", "456 Oak St", "City", "Ontario", "E5E 5E5", "555-555-5555", "carol.davis@example.com", "2", false, true);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            // Assert
            Assert.AreEqual(700m, price);
        }

        //Test fails as day 2 tickets is set to cost $450 instead of $350,
        //450x3 is the 1350 we get instead of the 1050
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_Day2Price_ThreeParticipants_PriceIs1050()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("David", "Evans", "789 Oak St", "City", "Ontario", "F6F 6F6", "666-666-6666", "david.evans@example.com", "3", false, true);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            // Assert
            Assert.AreEqual(1050m, price);
        }


        /* *********************************************** *
         * Test cases to assert registrants attending both days are charged $750 instead of $800 (3 test cases)
         * *********************************************** */
        //Whenever both days are true, price gets and extra 0 added to it
        //Therfore the expected 750 turns into 7500
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_BothDaysPrice_OneParticipant_PriceIs750()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Emma", "Wilson", "123 Pine St", "City", "Ontario", "G7G 7G7", "777-777-7777", "emma.wilson@example.com", "1", true, true);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            // Assert
            Assert.AreEqual(750m, price);
        }

        //Whenever both days are true, price gets and extra 0 added to it
        //Therfore the expected 1500 turns into 15000
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_BothDaysPrice_TwoParticipants_PriceIs1500()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Frank", "Thomas", "456 Pine St", "City", "Ontario", "H8H 8H8", "888-888-8888", "frank.thomas@example.com", "2", true, true);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            // Assert
            Assert.AreEqual(1500m, price);
        }

        //Whenever both days are true, price gets and extra 0 added to it
        //Therfore the expected 2250 turns into 22500
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_BothDaysPrice_ThreeParticipants_PriceIs2250()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Grace", "Harris", "789 Pine St", "City", "Ontario", "I9I 9I9", "999-999-9999", "grace.harris@example.com", "3", true, true);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");
            decimal price = GetDisplayedPrice();
            // Assert
            Assert.AreEqual(2250m, price);
        }


        /* *********************************************** *
         * Test cases to assert that when registering more than five participants, your given a 10% discount (3 test cases)
         * *********************************************** */
        //This test fails because the day1 & day2 prices are swapped
        //Therfore getting 1890 would be correct if they where not
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_Discount_SixParticipants_Day1_PriceIs2430()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Henry", "Clark", "123 Maple St", "City", "Ontario", "J1J 1J1", "101-010-1010", "henry.clark@example.com", "6", true, false);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");

            // Calculate expected price
            decimal originalPrice = 6 * 450m;
            decimal discount = originalPrice * 0.10m;
            decimal expectedPrice = originalPrice - discount;
            // Get the displayed price
            decimal price = GetDisplayedPrice();

            // Assert
            Assert.AreEqual(expectedPrice, price);
        }

        //This test fails because the day1 & day2 prices are swapped
        //Therfore getting 2430 would be correct if they where not
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_Discount_SixParticipants_Day2_PriceIs1890()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Isabel", "Martin", "456 Maple St", "City", "Ontario", "K2K 2K2", "202-020-2020", "isabel.martin@example.com", "6", false, true);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");

            // Calculate expected price
            decimal originalPrice = 6 * 350m;
            decimal discount = originalPrice * 0.10m;
            decimal expectedPrice = originalPrice - discount;
            // Get the displayed price
            decimal price = GetDisplayedPrice();

            // Assert
            Assert.AreEqual(expectedPrice, price);
        }

        //This test fails because when day1 & day2 are both true, an extra 0 is added
        //Therfore getting 40500 would be correct without that extra 0
        //Once again .67 is concatinated to end
        [TestMethod]
        public void Test_Discount_SixParticipants_BothDays_PriceIs4050()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("Jack", "Roberts", "789 Maple St", "City", "Ontario", "L3L 3L3", "303-030-3030", "jack.roberts@example.com", "6", true, true);
            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            WaitForPageLoad("viewRegistration.html");

            // Calculate expected price
            decimal originalPrice = 6 * 750m;
            decimal discount = originalPrice * 0.10m;
            decimal expectedPrice = originalPrice - discount;
            // Get the displayed price
            decimal price = GetDisplayedPrice();

            // Assert
            Assert.AreEqual(expectedPrice, price);
        }



        /* *********************************************** *
         * Test cases to assert that nav links at the top of page are working (One test case each)
         * *********************************************** */
        [TestMethod]
        public void Test_Link_TheEvent_NavigatesToIndex()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            // Act
            driver.FindElement(By.LinkText("THE Event!")).Click();
            WaitForPageLoad("index.html");
            // Assert
            Assert.AreEqual("https://localhost/register/index.html", driver.Url);
        }

        //Test case fails as the home button on the index.html page 
        //links to "https://httpstat.us/500" instead of our site home page
        [TestMethod]
        public void Test_Link_Home_NavigatesToIndex()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            // Act
            driver.FindElement(By.LinkText("Home")).Click();
            WaitForPageLoad("index.html");
            // Assert
            Assert.AreEqual("https://localhost/register/index.html", driver.Url);
        }

        [TestMethod]
        public void Test_Link_ConestogaCollege_NavigatesCorrectly()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            // Act
            driver.FindElement(By.PartialLinkText("Conestoga College")).Click();
            WaitForPageLoad("conestogac.on.ca");
            // Assert
            Assert.IsTrue(driver.Url.Contains("conestogac.on.ca"));
        }


        /* *********************************************** *
         *                Helper Methods
         * *********************************************** */

        //Method to fill out form on current page
        private void FillForm(string firstName, string lastName, string address, string city, string province, string postalCode, string phoneNumber, string email, string participants, bool day1, bool day2)
        {
            //Clear all fields in section
            driver.FindElement(By.Id("firstName")).Clear();
            driver.FindElement(By.Id("lastName")).Clear();
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("city")).Clear();

            //Fill all fields in section
            driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            driver.FindElement(By.Id("address")).SendKeys(address);
            driver.FindElement(By.Id("city")).SendKeys(city);

            //Select province from dropdown
            var provinceDropdown = new SelectElement(driver.FindElement(By.Id("province")));
            provinceDropdown.SelectByText(province);

            //Clear fields in second section
            driver.FindElement(By.Id("postalCode")).Clear();
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("numberOfParticipants")).Clear();

            //Fill fields in second section 
            driver.FindElement(By.Id("postalCode")).SendKeys(postalCode);
            driver.FindElement(By.Id("phone")).SendKeys(phoneNumber);
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("numberOfParticipants")).SendKeys(participants);

            //Select days attending from dropdown
            var daysDropdown = new SelectElement(driver.FindElement(By.Id("daysRegistered")));
            if(day1 && day2)
            {
                daysDropdown.SelectByValue("both");
            }
            else if (day1)
            {
                daysDropdown.SelectByValue("day1");
            }
            else if (day2)
            {
                daysDropdown.SelectByValue("day2");
            }
        }

        //Method to wait 10 seconds for a specific page to load
        private void WaitForPageLoad(string pageUrlPart)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url.Contains(pageUrlPart));
        }

        //Method to get and then parse the price 
        private decimal GetDisplayedPrice()
        {
            string priceText = driver.FindElement(By.Id("price")).GetAttribute("value");
            //Parse string to decimal value
            decimal price = decimal.Parse(priceText.Replace("$", "").Trim());
            return price;
        }
    }
}
