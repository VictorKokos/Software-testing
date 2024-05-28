// File: CatalogTests.cs
using Catalog.Tests.Driver;
using Catalog.Tests.Pages;
using Catalog.Tests.Utilities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;

namespace Catalog.Tests.Tests
{
    [TestFixture]
    public class CatalogTests
    {
        private BrowserManager _browserManager;
        private LovePlanetPage _lovePlanetPage;
        private ProfilePage _profilePage;
        private string _username;
        private string _password;
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _browserManager = new BrowserManager();
            _driver = _browserManager.Driver;
            _lovePlanetPage = new LovePlanetPage(_driver);
            _profilePage = new ProfilePage(_driver);
            _driver.Navigate().GoToUrl("https://loveplanet.ru/");

            // Чтение логина и пароля из файла
            string[] loginData = TestData.GetLoginData();
            _username = loginData[0];
            _password = loginData[1];
        }

        [Test]
        public void WhenNoProfileFound_MessageItemAppears()
        {
            Logger.LogInfo("Запуск теста: WhenUsingAgeFilter_AgeFilterTagShouldAppear_WithCorrectAge");

            _lovePlanetPage.SelectFriendshipPurpose();
            _lovePlanetPage.SetAgeSliderTo(200);
            _lovePlanetPage.Search();
            Assert.That(_lovePlanetPage.IsNotFoundMessageDisplayed(), Is.True, "Сообщение об отсутствии результатов не отображается");
        }

        [Test]
        public void LoginTest()
        {
            Logger.LogInfo("Запуск теста: LoginTest");

            _lovePlanetPage.ClickAcquaintanceButton();
            _lovePlanetPage.FillLoginForm(_username, _password);
            _lovePlanetPage.ClickLoginButton();

            // Проверка успешного входа
            if (_lovePlanetPage.ProfileElement != null && _lovePlanetPage.ProfileElement.Displayed)
            {
                Logger.LogInfo("Вход успешен");
            }
            else
            {
                Logger.LogError("Ошибка входа: Элемент профиля не найден");
                Assert.Fail("Ошибка входа: Элемент профиля не найден");
            }
        }
        [Test]
        public void AddCommentToPhotoTest()
        {
            Logger.LogInfo("Запуск теста: LoginTest");

            _lovePlanetPage.ClickAcquaintanceButton();
            _lovePlanetPage.FillLoginForm(_username, _password);
            _lovePlanetPage.ClickLoginButton();

            // Проверка успешного входа
            if (_lovePlanetPage.ProfileElement != null && _lovePlanetPage.ProfileElement.Displayed)
            {
                Logger.LogInfo("Вход успешен");
            }
            else
            {
                Logger.LogError("Ошибка входа: Элемент профиля не найден");
                Assert.Fail("Ошибка входа: Элемент профиля не найден");
            }

            _lovePlanetPage.ClickProfileElement();

            _profilePage.ClickFirstImageElement();

            Thread.Sleep(4000);

            _profilePage.WriteImageCommentInput("крутой");

            Thread.Sleep(6000);

            _profilePage.ClickImageCommentButton();

            Thread.Sleep(6000);

            if (_profilePage.CommentElement != null && _profilePage.CommentElement.Displayed)
            {
                Logger.LogInfo("комментарий оставлен");
            }
            else
            {
                Logger.LogError("Ошибка входа: комментарий не найден");
                Assert.Fail("Ошибка входа: комментарий не найден");
            }

            Thread.Sleep(6000);
        }

        [TearDown]
        public void TearDown()
        {
            _browserManager.Quit();
        }
    }
}