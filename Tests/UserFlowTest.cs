using System;
using NUnit.Framework;
using CSharpFramework.Utilities;
using CSharpFramework.PageObjectClass;
using System.Collections.Generic;

namespace SeleniumTestProject
{
    class E2ETest : BaseClass
    {

        [Test]
        public void EndToEndFlow()
        {
            string username = JsonReader.GetUsername();
            string password = JsonReader.GetPassword();
            string[] expectedProducts = JsonReader.GetExpectedProducts();

            LoginPage loginPage = new LoginPage(getDriver());
            ProductPage productPage = loginPage.Login(username, password);

            Waits.SetImplicitWait(driver, TimeSpan.FromSeconds(10));
            

            foreach (string product in expectedProducts)
            {
                productPage.AddProductToCart(product);
            }

            CartPage cartPage = productPage.ClickCheckout();
            CheckoutPage checkoutPage = cartPage.ProceedToCheckout();

            checkoutPage.EnterCountry("India");
            checkoutPage.AgreeToTerms();
            checkoutPage.Purchase();
        }

        public static IEnumerable<TestCaseData> TestDataList()
        {
            yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("rahulshettyacademy", "learning1");

        }
    }
}
