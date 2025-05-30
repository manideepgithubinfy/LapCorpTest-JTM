using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LabCorp.Pages
{
    internal class CareersPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CareersPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void SearchJob(string jobTitle)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("typehead"))).SendKeys(jobTitle);
            _driver.FindElement(By.Id("typehead")).SendKeys(Keys.Enter);
        }

        public void SelectFirstJob()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-ph-at-job-title-text='Senior Automation and Robotics Software Engineer']")));
            //var jobLink = _driver.FindElement(By.CssSelector("a[data-ph-at-job-title-text='Senior Automation and Robotics Software Engineer']"));
            //jobLink.Click();
            //WebDriverWait wait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(30));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("ot-sdk-row")));

            var jobLink = this._driver.FindElement(By.CssSelector("a[data-ph-at-job-title-text='Senior Automation and Robotics Software Engineer']"));
            ((IJavaScriptExecutor)this._driver).ExecuteScript("arguments[0].scrollIntoView(true);", jobLink);
            jobLink.Click();


            // _wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[data-ph-at-job-title-text='Senior Automation and Robotics Software Engineer']"))).Click();
        }
    }
}
