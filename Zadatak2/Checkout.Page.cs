using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement buttonBack
        {
            get
            {
                return this.FindElement(By.LinkText("Go back to the site."));
            }
        }

        public HomePage ClickOnButtonBack()
        {
            this.buttonBack.Click();
            this.ExplicitWait(500);
            return new HomePage(this.driver);
        }
    }
}
