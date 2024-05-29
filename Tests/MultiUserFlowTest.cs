using System;
using NUnit.Framework;
using CSharpFramework.Utilities;
using CSharpFramework.PageObjectClass;
using System.Collections.Generic;

namespace SeleniumTestProject
{
    class MultiE2ETest : BaseClass
    {
        public static IEnumerable<TestCaseData> TestData()
        {
            foreach (var testDataSet in MultiJsonReader.GetTestDataSets())
            {
                yield return new TestCaseData(testDataSet)
                    .SetName($"Test with Username: {testDataSet.Login.Username}");
            }
        }

        [Test, TestCaseSource("TestData")]
        public void MultiEndToEndFlow(TestDataSet testDataSet)
        {
            string username = testDataSet.Login.Username;
            string password = testDataSet.Login.Password;
            string[] expectedProducts = testDataSet.ExpectedProducts;

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
    }
}
