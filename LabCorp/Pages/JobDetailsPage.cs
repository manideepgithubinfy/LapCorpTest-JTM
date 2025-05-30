using OpenQA.Selenium;

namespace LabCorp.Pages
{
    internal class JobDetailsPage
    {
        private readonly IWebDriver _driver;

        public JobDetailsPage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        }

        public string? GetJobTitle() => _driver.FindElement(By.CssSelector("h1.job-title"))?.Text;
        public string? GetLocation() => _driver.FindElement(By.XPath("//span[contains(@class, 'jobId')]/ancestor::div[contains(@class,'job-other-info')]//span[contains(@class, 'job-location')]"))?.Text;        public string? GetJobId() => _driver.FindElement(By.XPath("//span[contains(@class, 'jobId')]"))?.Text;
        public string? GetJobDescription() => _driver.FindElement(By.XPath("//div[@class='job-description']"))?.Text;
        public string? GetJobSkill1() => _driver.FindElement(By.XPath("//span[contains(text(),'Experience leading a technical team is a strong plus.')]"))?.Text;
        public string? GetJobSkill2() => _driver.FindElement(By.XPath("//p[contains(text(),'Experience with OpenJDK 11 or later a plus.')]"))?.Text;
        public string? GetJobSkill3() => _driver.FindElement(By.XPath("//p[contains(text(),'Experience with production metrics/big data a plus.')]"))?.Text;
        ////span[contains(text(),'Experience leading a technical team is a strong plus.')]
      
        public string? GetIntroText() => _driver.FindElement(By.XPath("(//div[@class='job-intro']//p)[3]"))?.Text;
        public string? GetBulletPoint(string index) => _driver.FindElement(By.XPath($"(//ul/li)[{index}]"))?.Text;
        public void ClickApplyNow() => _driver.FindElement(By.XPath("//a[@data-ph-at-id='apply-link'][1]"))?.Click();
    }
}
