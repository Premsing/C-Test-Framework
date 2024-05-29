using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpFramework.PageObjectClass
{
    class CheckoutPage
    {
        private readonly IWebDriver _driver;

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement CountryField;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'India')]")]
        private IWebElement CountryOption;

        [FindsBy(How = How.XPath, Using = "//label[@for='checkbox2']")]
        private IWebElement TermsCheckbox;

        [FindsBy(How = How.XPath, Using = "//input[@value='Purchase']")]
        private IWebElement PurchaseButton;

        public void EnterCountry(string country)
        {
            CountryField.SendKeys(country);
            CountryOption.Click();
        }

        public void AgreeToTerms()
        {
            TermsCheckbox.Click();
        }

        public ThankYouPage Purchase()
        {
            PurchaseButton.Click();
            return new ThankYouPage(_driver);
        }
    }
}
