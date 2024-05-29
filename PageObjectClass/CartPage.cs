using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpFramework.PageObjectClass
{
    class CartPage
    {
        private readonly IWebDriver _driver;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Checkout')]")]
        private IWebElement CheckoutButton;

        public CheckoutPage ProceedToCheckout()
        {
            CheckoutButton.Click();
            return new CheckoutPage(_driver);
        }
    }
}
