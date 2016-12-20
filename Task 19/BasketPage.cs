using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace csharp
{
    internal class BasketPage : Page
    {
        public BasketPage(IWebDriver driver) : base(driver) { }


        public void OpenBasket()
        {
            driver.FindElement(By.CssSelector("div#cart a.link")).Click();
            wait.Until(ExpectedConditions.TitleIs("Checkout | My Store"));
        }

        public void RemoveItemsFromBasket (int number_of_items)
        {
            for (int i = 0; i < number_of_items; i++)
            {
                if (i == number_of_items - 1)
                //Removing the last item from the order
                {
                    //Get last item in the order
                    IWebElement LastItemInTheOrder = driver.FindElement(By.CssSelector("div#order_confirmation-wrapper tr:nth-of-type(2) td.item"));
                    //Remove Item from the order
                    driver.FindElement(By.CssSelector("button[name=remove_cart_item]")).Click();
                    //Verify the order table has changed
                    wait.Until(ExpectedConditions.StalenessOf(LastItemInTheOrder));

                }
                else {
                    //Get last item in the order
                    IWebElement LastItemInTheOrder = driver.FindElement(By.CssSelector("div#order_confirmation-wrapper tr:nth-of-type(2) td.item"));
                    //Select first duck in the list
                    driver.FindElement(By.CssSelector("ul.shortcuts li.shortcut:nth-of-type(1) a")).Click();
                    //Remove Item from the order
                    driver.FindElement(By.CssSelector("button[name=remove_cart_item]")).Click();
                    //Verify the order table has changed
                    wait.Until(ExpectedConditions.StalenessOf(LastItemInTheOrder));
                }
            }

        }

        









    }
}