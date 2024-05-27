// File: LovePlanetPage.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Catalog.Tests.Pages
{
    public class ProfilePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public ProfilePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        // Элементы страницы
        private IWebElement FirstImageElement => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#col_center > div.bbox.rds10 > div.flex.jc-between.mp-container > div.mp-info_right > div.mb28 > div.flex.jc-between.mp-thumbs-list > a:nth-child(2) > img")));
        private IWebElement ImageCommentInput => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#albumcmmajax > div.gnl_photo_form.mb33.mt7.p_rel > form > textarea")));
        private IWebElement ImageCommentButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#albumcmmajax > div.gnl_photo_form.mb33.mt7.p_rel > form > button")));
         public IWebElement CommentElement => _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#albumcmmajax > ul > li")));

        // Методы страницы
        public void ClickFirstImageElement()
        {

            FirstImageElement.Click();
        }
        public void WriteImageCommentInput(string message)
        {

            ImageCommentInput.SendKeys(message);
        }
        public void ClickImageCommentButton()
        {

            ImageCommentButton.Click();
        }
    }
}