using System;
using NUnit.Framework;
using CSharpFramework.Utilities;
using CSharpFramework.PageObjectClass;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace SeleniumTestProject
{
    [Parallelizable(ParallelScope.Children)]
    class MultiE2ETest : BaseClass
    {
        

        //[Parallelizable(ParallelScope.All)]
        [Test, TestCaseSource("TestData")]
        public void MultiEndToEndFlow(TestDataSet testDataSet)
        {
            string username = testDataSet.Login.Username;
            string password = testDataSet.Login.Password;
            string[] expectedProducts = testDataSet.ExpectedProducts;

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

        [Test]
        public void SauceDemoLogin()
        {
            driver.Value.Url = "https://www.saucedemo.com/v1/";
            driver.Value.FindElement(By.Id("user-name")).SendKeys("standard_user");
            driver.Value.FindElement(By.Id("password")).SendKeys("secret_sauce");
            driver.Value.FindElement(By.Id("login-button")).Click();
        }

        public static IEnumerable<TestCaseData> TestData()
        {
            foreach (var testDataSet in MultiJsonReader.GetTestDataSets())
            {
                yield return new TestCaseData(testDataSet)
                    .SetName($"Test with Username: {testDataSet.Login.Username}");
            }
        }
    }
}
