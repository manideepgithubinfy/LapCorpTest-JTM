using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCorp.Utilities
{
    public static class CookieBannerHelper
    {
        public static void DismissCookiesIfPresent(IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                var acceptCookiesBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementToBeClickable(By.CssSelector("button[aria-label='Accept All Cookies']")));
                acceptCookiesBtn.Click();
            }
            catch (WebDriverTimeoutException)
            {
                // Cookie popup not shown - safe to ignore
            }
            catch (NoSuchElementException)
            {
                // Button not found - safe to ignore
            }
        }
    }

}
