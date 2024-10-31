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

        [TestInitialize]
        public void Setup()
        {
            ChromeOptions handlingSSL = new ChromeOptions();
            handlingSSL.AcceptInsecureCertificates = true;
            driver = new ChromeDriver(handlingSSL);
            driver.Manage().Window.Maximize();
        }


        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }


        // Province Selection Test Cases (12 test methods)
        [TestMethod]
        public void Test_ProvinceSelection_Alberta_NavigatesToViewRegistration()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://localhost/register/index.html");
            FillForm("John", "Doe", "123 Main Street", "Edmonton", "Alberta", "A1A 1A1", "111-111-1111", "john.doe@example.com", "1", true, false);

            // Act
            driver.FindElement(By.Id("btnSubmit")).Click();
            // Assert
            Assert.AreEqual("https://localhost/register/viewRegistration.html", driver.Url);
        }

        // Helper Methods
        private void FillForm(string firstName, string lastName, string address, string city, string province, string postalCode, string phoneNumber, string email, string participants, bool day1, bool day2)
        {
            driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            driver.FindElement(By.Id("address")).SendKeys(address);
            driver.FindElement(By.Id("city")).SendKeys(city);

            var provinceDropdown = new SelectElement(driver.FindElement(By.Id("province")));
            provinceDropdown.SelectByText(province);

            driver.FindElement(By.Id("postalCode")).SendKeys(postalCode);
            driver.FindElement(By.Id("phone")).SendKeys(phoneNumber);
            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("numberOfParticipants")).SendKeys(participants);



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
    }
}
