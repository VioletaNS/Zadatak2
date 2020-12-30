using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Zadatak2
{
    class HomePage : BasePage


    {
        //private IWebDriver driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        public IWebElement labelQAShop
        {
            get
            {
                return this.FindElement(By.XPath("//h1[text()='Quality Assurance (QA) Shop']"));
            }
        }
        private IWebElement linkLogout
        {
            get
            {
                return this.FindElement(By.PartialLinkText("Logout"));
            }
        }
        public IWebElement linkLogin
        {
            get
            {
                return this.FindElement(By.LinkText("Login"));
            }
        }
        public IWebElement linkRegister
        {
            get
            {
                return this.FindElement(By.LinkText("Register"));
            }
        }

        public IWebElement linkViewCart
        {
            get
            {
                return this.FindElement(By.LinkText("View shopping cart"));
            }
        }

        public IWebElement alertSuccess
        {
            get
            {
                return this.FindElement(
                    By.XPath("//div[contains(@class, 'success') and contains(., 'Uspeh')]")
                );
            }
        }
        public void GoToPage()
        {
            this.GoToURL("http://shop.qa.rs");
        }
        public bool IsUserLoggedIn()
        {
            if (this.linkLogout != null)
            {
                return this.linkLogout.Displayed;
            }
            else
            {
                return false;
            }
        }
        public bool IsAlertSuccessVisible()
        {
            return this.alertSuccess.Displayed;
        }

        public bool IsCartEmpty()
        {
            linkViewCart.Click();
            this.ExplicitWait(500);
            IWebElement alert = this.FindElement(
                By.XPath("//div[@role='alert' and contains(text(), 'Your cart is empty.')]")
            );
            return alert != null;
        }

        public LoginPage ClickOnLinkLogin()
        {
            linkLogin.Click();
            this.waitElementToBeVisible(By.XPath("//h2[text()='Prijava']"));
            this.ExplicitWait(500);
            return new LoginPage(this.driver);
        }


        public CartPage ClickOnLinkViewCart()
        {
            linkViewCart.Click();
            this.ExplicitWait(500);
            this.waitElementToBeVisible(
                By.XPath("//h1[contains(., 'Quality Assurance (QA) course - Order')]")
            );
            return new CartPage(this.driver);
        }

        public CartPage SelectPackage(string package, string quantity)
        {
            IWebElement dropdown = this.FindElement(
                By.XPath($"//div//h3[contains(text(), '{package}')]//ancestor::div[contains(@class, 'panel')]//select")
            );
            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue(quantity);

            IWebElement buttonOrder = this.FindElement(
                By.XPath($"//div//h3[contains(text(), '{package}')]//ancestor::div[contains(@class, 'panel')]//input[@type='submit']")
            );

            buttonOrder.Click();
            this.ExplicitWait(500);
            return new CartPage(this.driver);
        }
    }
}

