using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.Threading;

namespace CSharpFramework.Utilities
{
    class BaseClass
    {
        //public WebDriver driver;
        public ThreadLocal<WebDriver> driver = new ThreadLocal<WebDriver>();
        [SetUp]
        public void Setup()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            initBrowser(browserName);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public void initBrowser(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    new WebDriverManager.DriverConfigs.Impl.ChromeConfig();
                    driver.Value = new ChromeDriver();
                    break;

                case "firefox":
                    new WebDriverManager.DriverConfigs.Impl.FirefoxConfig();
                    driver.Value = new FirefoxDriver();
                    break;

                case "edge":
                    new WebDriverManager.DriverConfigs.Impl.EdgeConfig();
                    driver.Value = new EdgeDriver();
                    break;

                default:
                    throw new ArgumentException("Invalid browser type: " + browserType);
            }
        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

            [TearDown]
            public void cleanUp()
            {
                driver.Value.Quit();
            }
    }
}