using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriver
{
    // Страница LovePlanet
    public class LovePlanetPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LovePlanetPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        // Элементы страницы
        private IWebElement PurposeElement => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[3]/div[5]/div[1]/div/form/div[1]/ul/li[3]/div/div/div[1]")));
        private IWebElement FifthPurposeItem => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"anketa\"]/div[1]/ul/li[3]/div/div/div[2]/div[1]/ul/li[5]")));
        private IWebElement AgeSliderElement => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[3]/div[5]/div[1]/div/form/div[1]/div/div[1]/div[2]/div/div[2]")));
        private IWebElement SearchButton => _driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[5]/div[1]/div/form/div[2]/div/div/div[1]/button"));
        private IWebElement NotFoundMessage => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(), 'Мы больше никого не нашли')]")));
        private IWebElement AcquaintanceButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[1]/div[1]/div/ul/li[1]/a")));
        private IWebElement AccountInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[3]/div[2]/div/div/div[2]/div[2]/form/div[1]/ul/li[2]/input")));
        private IWebElement PasswordInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[3]/div[2]/div/div/div[2]/div[2]/form/div[1]/ul/li[3]/div[1]/input")));
        private IWebElement LoginButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[2]/div[3]/div[2]/div/div/div[2]/div[2]/form/div[1]/ul/li[4]/button")));
        public IWebElement ProfileElement => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("body > div.height_full > div.head > div > div.flex.ai-center.head_user_row > div.head_user > div > div.flex.ai-center > a")));

        // Методы страницы
        public void SelectFriendshipPurpose()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", PurposeElement);
            FifthPurposeItem.Click();
        }

        public void SetAgeSliderTo(int offset)
        {
            Actions actions = new Actions(_driver);
            actions.ClickAndHold(AgeSliderElement).MoveByOffset(offset, 0).Release().Perform();
        }

        public void Search()
        {
            SearchButton.Click();
        }

        public bool IsNotFoundMessageDisplayed()
        {
            return NotFoundMessage.Displayed;
        }

        public void ClickAcquaintanceButton()
        {
            AcquaintanceButton.Click();
        }

        public void FillLoginForm(string username, string password)
        {
            AccountInput.SendKeys(username);
            PasswordInput.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }
    }
}