using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace csharp
{
    internal class ProductPage : Page
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public void SelectSize(string size)
        {
            //Select size
            driver.FindElement(By.CssSelector("select[name*=options]")).Click();
            driver.FindElement(By.CssSelector("select[name*=options] option:nth-of-type(2)")).Click();
            string SizeValue = driver.FindElement(By.CssSelector("select[name*=options]")).GetAttribute("value");
            //Check if right value was selected
            NUnit.Framework.Assert.AreEqual(SizeValue, size);
        }

        public void AddItemToBasket(int currentstep, int number_of_items_in_the_basket)
        {
            driver.FindElement(By.CssSelector("button[name=add_cart_product]")).Click();
            string CourtNumber = (currentstep + 1).ToString();
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span.quantity"), CourtNumber));
            int ItemsInTheBasketNew = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));
            NUnit.Framework.Assert.AreEqual(number_of_items_in_the_basket, ItemsInTheBasketNew - 1);

        }

         public int CountProductsInTheBasket()
          {
             IWebElement CurrentCourtElement = driver.FindElement(By.CssSelector("span.quantity"));
             //Count number of items in the basket
             int ItemsInTheBasket = Int32.Parse(CurrentCourtElement.GetAttribute("innerText"));
            return ItemsInTheBasket;
          }

        public void ClickOnTheProduct()
        {
            driver.FindElement(By.CssSelector("div#box-most-popular div.content ul a")).Click();
        }

        public bool VerifySizeControl()
        {
            if (driver.FindElements(By.CssSelector("select[name*=options]")).Count > 0) {
                return true;
            }
            else return false;
        }




    }
}