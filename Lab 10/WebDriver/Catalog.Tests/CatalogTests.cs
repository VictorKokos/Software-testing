using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace WebDriver
{
    [TestFixture]
    public class CatalogTests
    {
        private IWebDriver _driver;
        private LovePlanetPage _lovePlanetPage;

        private string _username;
        private string _password;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _lovePlanetPage = new LovePlanetPage(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://loveplanet.ru/");

            // Чтение логина и пароля из файла
            string filePath = @"D:\Work\3k2s\testirovanie\1.txt";
            string[] loginData = File.ReadAllLines(filePath);
            _username = loginData[0];
            _password = loginData[1];
        }

        [Test]
        public void WhenUsingAgeFilter_AgeFilterTagShouldAppear_WithCorrectAge()
        {
            _lovePlanetPage.SelectFriendshipPurpose();
            _lovePlanetPage.SetAgeSliderTo(200);
            _lovePlanetPage.Search();
            Assert.That(_lovePlanetPage.IsNotFoundMessageDisplayed(), Is.True);
        }

        [Test]
        public void LoginTest()
        {
            _lovePlanetPage.ClickAcquaintanceButton();
            _lovePlanetPage.FillLoginForm(_username, _password);
            Thread.Sleep(4000);
            _lovePlanetPage.ClickLoginButton();
            Thread.Sleep(7000);
            Assert.That(_lovePlanetPage.ProfileElement.Displayed, Is.True, "Профиль не отображается после входа");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}