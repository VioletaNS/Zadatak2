using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;


namespace Zadatak2
{
    class Tests
    {


        private IWebDriver driver;
        [Test]
        [Category("Shop")]
        public void TestLogin()
        {
            HomePage home = new HomePage(this.driver);
            home.GoToPage();
            LoginPage login = home.ClickOnLinkLogin();
            login.EnterUsername("ted.padington");
            login.EnterPassword("padington");
            home = login.ClickOnButtonLogin();
            Assert.AreEqual(true, home.IsUserLoggedIn());
        }
        [Test]
        [Category("Shop")]
        public void TestLoginAndOrder()
        {
            HomePage home = new HomePage(this.driver);
            home.GoToPage();

            LoginPage login = home.ClickOnLinkLogin();
            login.EnterUsername("ted.padington");
            login.EnterPassword("padington");

            home = login.ClickOnButtonLogin();
            Assert.AreEqual(true, home.IsUserLoggedIn());

            if (home.IsCartEmpty() == false)
            {
                
                CartPage emptyCart = new CartPage(this.driver);
                CheckoutPage checkout = emptyCart.ClickOnButtonCheckout();
                home = checkout.ClickOnButtonBack();
            }

            string package = "small";
            string quantity = "3";

            CartPage cart = home.SelectPackage(package, quantity);
            Assert.AreEqual(true, cart.IsDisplayed());

            Assert.AreEqual(true, cart.VerifyItemNameAndQuantity(package, quantity));
            
            
        }


        [SetUp]
        public void SetUp()
        {
            this.driver = new FirefoxDriver();
            this.driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
            this.driver.Dispose();
        }

        public void Sleep(int miliseconds = 500)
        {
            System.Threading.Thread.Sleep(miliseconds);
        }
    }
    

}

