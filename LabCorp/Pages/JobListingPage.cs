using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LabCorp.Pages
{
    internal class JobListingPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public JobListingPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void SelectJobByTitle(string jobTitle)
        {
            //var jobLink = _wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(jobTitle)));
            //jobLink.Click();
        }
    }
}
