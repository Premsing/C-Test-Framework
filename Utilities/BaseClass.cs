using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;

namespace CSharpFramework.Utilities
{
    class BaseClass
    {
        public WebDriver driver;
        [SetUp]
        public void Setup()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            initBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public void initBrowser(string browserType)
        {
            switch (browserType.ToLower())
            {
                case "chrome":
                    new WebDriverManager.DriverConfigs.Impl.ChromeConfig();
                    driver = new ChromeDriver();
                    break;

                case "firefox":
                    new WebDriverManager.DriverConfigs.Impl.FirefoxConfig();
                    driver = new FirefoxDriver();
                    break;

                case "edge":
                    new WebDriverManager.DriverConfigs.Impl.EdgeConfig();
                    driver = new EdgeDriver();
                    break;

                default:
                    throw new ArgumentException("Invalid browser type: " + browserType);
            }
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

            [TearDown]
            public void cleanUp()
            {
                driver.Quit();
            }
    }
}