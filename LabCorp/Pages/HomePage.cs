using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabCorp.Pages
{
    internal class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl("https://www.labcorp.com");
        }

        public void ClickCareers()
        {
            var careersLink = _wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Careers")));
            careersLink.Click();
        }
    }
}
