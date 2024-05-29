using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace CSharpFramework.Utilities
{
    class Waits
    {
        public static void SetImplicitWait(IWebDriver driver, TimeSpan time)
        {
            driver.Manage().Timeouts().ImplicitWait = time;
        }

        public static WebDriverWait GetWebDriverWait(IWebDriver driver, TimeSpan time)
        {
            return new WebDriverWait(driver, time);
        }

        public static void WaitForElementToBeVisible(IWebDriver driver, By locator, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, By locator, TimeSpan time)
        {
            WebDriverWait wait = new WebDriverWait(driver, time);
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
