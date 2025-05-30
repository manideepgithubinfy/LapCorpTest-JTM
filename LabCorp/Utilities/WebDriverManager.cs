using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace LabCorp.Utilities
{

    public interface IDriverFactory
    {
        IWebDriver CreateDriver();
    }

    public class DriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), version: "MatchingBrowser");
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }

}
