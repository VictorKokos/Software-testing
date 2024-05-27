// File: BrowserManager.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver
{
    public class BrowserManager
    {
        private IWebDriver _driver;

        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                }
                return _driver;
            }
        }

        public void Quit()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}