using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Zadatak2
{
    class BasePage
    {
      
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(20));

        }
        protected void GoToURL(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }
        protected IWebElement waitElementToBeVisible(By selector)
        {
            return wait.Until(EC.ElementIsVisible(selector));
        }
        protected IWebElement waitElementToBeClickable(By selector)
        {
            return wait.Until(EC.ElementToBeClickable(selector));
        }
        protected void ExplicitWait(int miliseconds = 10)
        {
            System.Threading.Thread.Sleep(miliseconds);
        }

        public IWebElement FindElement(By selector)
        {
            IWebElement returnElement = null;
            try
            {
                returnElement = this.driver.FindElement(selector);
            }
            catch (NoSuchElementException) { }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnElement;
        }
    }
}
