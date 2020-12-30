using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;


namespace Zadatak2
{


    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public IWebElement inputUserName
        {
            get
            {
                return this.FindElement(By.Name("username"));
            }
        }
        public IWebElement inputPassword
        {
            get
            {
                return this.FindElement(By.Name("password"));
            }
        }
        public IWebElement buttonLogin
        {
            get
            {
                return this.FindElement(By.Name("login"));
            }
        }
        public void EnterUsername(string username)
        {
            this.ExplicitWait();
            this.waitElementToBeClickable(By.Name("username"));
            this.inputUserName.SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            this.ExplicitWait();
            this.waitElementToBeClickable(By.Name("password"));
            this.inputPassword.SendKeys(password);
        }
        public HomePage ClickOnButtonLogin()
        {
            this.buttonLogin.Click();
            try
            {
                this.waitElementToBeVisible(By.XPath("//h2[contains(text(), 'Welcome back]"));
            }
            catch (WebDriverTimeoutException)
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new HomePage(this.driver);
        }
    }
}

