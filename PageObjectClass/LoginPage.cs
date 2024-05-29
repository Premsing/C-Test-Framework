using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpFramework.PageObjectClass
{
    class LoginPage
    {
        // Local variable to activate driver
        private readonly IWebDriver _driver;

        // Constructor to initialize the driver and PageFactory elements
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Web elements defined using the FindsBy attribute
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement UsernameField;

        [FindsBy(How = How.CssSelector, Using = "input[id='password']")]
        private IWebElement PasswordField;

        [FindsBy(How = How.ClassName, Using = "checkmark")]
        private IWebElement RememberMeCheckbox;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement TermsCheckbox;

        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement SignInButton;

        // Method to perform the login action
        public ProductPage Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            RememberMeCheckbox.Click();
            TermsCheckbox.Click();
            SignInButton.Click();
            return new ProductPage(_driver); //we are smartly creating object of a Products page.
        }
    }
}
