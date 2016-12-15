using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Collections.Generic;
using System.Linq;


namespace csharp
{
    [TestClass]
    public class Task13

    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));


        }

        [Test]

        public void WorkingWithBasket()
        {
            driver.Url = "http://localhost/litecart/en/";

            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));


            for (int i = 0; i < 3; i++)

                {
                //Selecting two dacks from Most Popular
                if (i <=1)
                {
                    driver.FindElement(By.CssSelector("div#box-most-popular div.content ul a")).Click();
                    IWebElement CurrentCourtElement = driver.FindElement(By.CssSelector("span.quantity"));
                    //Count number of items in the basket
                    int ItemsInTheBasket = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));
                    //Checking if there is a size control
                    if (driver.FindElements(By.CssSelector("select[name*=options]")).Count > 0)
                    {
                        //Select size
                        driver.FindElement(By.CssSelector("select[name*=options]")).Click();
                        driver.FindElement(By.CssSelector("select[name*=options] option:nth-of-type(2)")).Click();
                        string SizeValue = driver.FindElement(By.CssSelector("select[name*=options]")).GetAttribute("value");
                        //Check if right value was selected
                        NUnit.Framework.Assert.AreEqual(SizeValue, "Small");
                    }
                    driver.FindElement(By.CssSelector("button[name=add_cart_product]")).Click();
                    string CourtNumber = (i + 1).ToString();
                    wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span.quantity"), CourtNumber));
                    int ItemsInTheBasketNew = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));
                    NUnit.Framework.Assert.AreEqual(ItemsInTheBasket, ItemsInTheBasketNew - 1);
                    driver.Navigate().Back();
                    wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));

                }
                else //Selecting one duck from Campaigns 
                {
                    IWebElement DuckToClick = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title]"));

                    DuckToClick.Click();
                    wait.Until(ExpectedConditions.TitleIs("Yellow Duck | Subcategory | Rubber Ducks | My Store"));
                    IWebElement CurrentCourtElement = driver.FindElement(By.CssSelector("span.quantity"));
                    //Count number of items in the basket
                    int ItemsInTheBasket = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));

                    //Select size
                    driver.FindElement(By.CssSelector("select[name*=options]")).Click();
                    driver.FindElement(By.CssSelector("select[name*=options] option:nth-of-type(2)")).Click();
                    string SizeValue = driver.FindElement(By.CssSelector("select[name*=options]")).GetAttribute("value");
                    //Check if right value was selected
                    NUnit.Framework.Assert.AreEqual(SizeValue, "Small");
                    driver.FindElement(By.CssSelector("button[name=add_cart_product]")).Click();
                    string CourtNumber = (i + 1).ToString();
                    wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("span.quantity"), CourtNumber));
                    int ItemsInTheBasketNew = Int32.Parse(driver.FindElement(By.CssSelector("span.quantity")).GetAttribute("innerText"));
                    NUnit.Framework.Assert.AreEqual(ItemsInTheBasket, ItemsInTheBasketNew - 1);
                    driver.Navigate().Back();
                    wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
                }
            }

            driver.FindElement(By.CssSelector("div#cart a.link")).Click();
            wait.Until(ExpectedConditions.TitleIs("Checkout | My Store"));
            //Get amount of unique items in the order
            int UniqueItems = driver.FindElements(By.CssSelector("ul.shortcuts li.shortcut")).Count;

            for (int i = 0; i < UniqueItems; i++)
            {
                if (i == UniqueItems-1)
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



        [TearDown]

        public void stop()
        {
            driver.Quit();
            driver = null;
        }


    }
}
