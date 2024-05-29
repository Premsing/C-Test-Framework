using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpFramework.PageObjectClass
{
    class ThankYouPage
    {
        private readonly IWebDriver _driver;

        public ThankYouPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Placeholder for Thank You page specific elements and methods
        // Add elements and methods to verify the purchase or perform other actions
    }
}
