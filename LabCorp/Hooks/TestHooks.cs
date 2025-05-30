using OpenQA.Selenium;
using Reqnroll;
using LabCorp.Utilities;

namespace LabCorp.Hooks
{

    [Binding]
    public class TestHooks
    {
        private static IWebDriver? _driver;
        private readonly ScenarioContext _scenarioContext;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //ExtentReportManager.CreateReport();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var factory = new DriverFactory();
            _driver = factory.CreateDriver();
            _scenarioContext["driver"] = _driver;
            CookieBannerHelper.DismissCookiesIfPresent(_driver);
            // ExtentReportManager.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            if (_scenarioContext.TestError != null)
            {
                // ExtentReportManager.LogFail(_scenarioContext.TestError.Message);
            }
            else
            {
                // ExtentReportManager.LogPass("Step Passed");
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Simplified null check to address IDE0031
            _driver?.Quit();
            // ExtentReportManager.FlushReport();
        }
    }
}
