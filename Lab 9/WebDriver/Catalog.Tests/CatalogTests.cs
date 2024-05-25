using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriver
{
    public class CatalogTests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void WhenUsingAgeFilter_AgeFilterTagShouldAppear_WithCorrectAge()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://loveplanet.ru/");

            // Ожидание, пока элемент станет видимым и активным
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            // Находим элемент выпадающего списка
            IWebElement purposeElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[3]/div[5]/div[1]/div/form/div[1]/ul/li[3]/div/div/div[1]")));

            // Кликаем по элементу с помощью JavaScript
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", purposeElement);

            // Ожидание, пока список элементов станет видимым
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"anketa\"]/div[1]/ul/li[3]/div/div/div[2]/div[1]/ul/li[5]")));

            // Теперь вы можете найти пятый элемент в списке
            IWebElement fifthItem = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"anketa\"]/div[1]/ul/li[3]/div/div/div[2]/div[1]/ul/li[5]")));

            // Клик по пятому элементу
            fifthItem.Click();

            // Находим элемент ползунка
            IWebElement sliderElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[3]/div[5]/div[1]/div/form/div[1]/div/div[1]/div[2]/div/div[2]")));

            // Создаем объект Actions
            Actions actions = new Actions(_driver);

            // Перетаскиваем ползунок вправо на 200 пикселей
            actions.ClickAndHold(sliderElement).MoveByOffset(200, 0).Release().Perform();

            // Находим кнопку поиска (XPath может быть другим, уточните его)
            IWebElement searchButton = _driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[5]/div[1]/div/form/div[2]/div/div/div[1]/button"));

            // Кликаем по кнопке поиска
            searchButton.Click();

            // Ожидание, пока появится плашка с надписью "Мы больше никого не нашли"
            IWebElement notFoundMessage = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(), 'Мы больше никого не нашли')]")));

            // Проверяем, что плашка с надписью "Мы больше никого не нашли" появилась
            Assert.That(notFoundMessage.Displayed, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}