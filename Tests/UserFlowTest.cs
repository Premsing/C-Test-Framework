using System;
using NUnit.Framework;
using CSharpFramework.Utilities;
using CSharpFramework.PageObjectClass;
using System.Collections.Generic;

namespace SeleniumTestProject
{
    class E2ETest : BaseClass
    {
        //[Parallelizable(ParallelScope.All)]
        [Test, TestCaseSource("AddTestData")]
        public void EndToEndFlow(string username, string password)
        {
            //string username = JsonReader.GetUsername();
            //string password = JsonReader.GetPassword();
            string[] expectedProducts = JsonReader.GetExpectedProducts();

            LoginPage loginPage = new LoginPage(getDriver());
            ProductPage productPage = loginPage.Login(username, password);

            Waits.SetImplicitWait(driver.Value, TimeSpan.FromSeconds(10));
            

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

        public static IEnumerable<TestCaseData> AddTestData()
        {
            yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("rahulshettyacademy", "learning");
            yield return new TestCaseData("rahulshetty", "learning");
        }

    }
}
