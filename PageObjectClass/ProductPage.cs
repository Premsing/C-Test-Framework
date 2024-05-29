using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpFramework.PageObjectClass
{
    class ProductPage
    {
        private readonly IWebDriver _driver;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> AllProducts;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Checkout')]")]
        private IWebElement CheckoutLink;

        public void AddProductToCart(string productName)
        {
            foreach (IWebElement product in AllProducts)
            {
                if (product.FindElement(By.CssSelector(".card-title a")).Text.Equals(productName))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }
        }

        public CartPage ClickCheckout()
        {
            CheckoutLink.Click();
            return new CartPage(_driver);
        }
    }
}
