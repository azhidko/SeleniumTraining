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
    public class Task12

    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));


        }

        [Test]

        public void AddProduct()
        {
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            //Count number of rows in the table
            driver.FindElement(By.CssSelector("table.dataTable tr.row:nth-of-type(3) td:nth-of-type(3) a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            int RowsBefore = driver.FindElements(By.CssSelector("table.dataTable tr.row")).Count;
           driver.FindElement(By.CssSelector("table.dataTable tr.row:nth-of-type(2) a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            driver.FindElement(By.CssSelector("div a.button:nth-of-type(2)")).Click();
            wait.Until(ExpectedConditions.TitleIs("Add New Product | My Store"));
            //Fill in Feneral Tab
            driver.FindElement(By.CssSelector("td label:nth-of-type(1) input")).Click();
            driver.FindElement(By.CssSelector("span.input-wrapper > input")).SendKeys("NewDuck");
            driver.FindElement(By.CssSelector("input[name=code]")).SendKeys("rd0015");
            driver.FindElement(By.CssSelector("div.input-wrapper tbody tr:nth-of-type(1) td input[name*=categories]")).Click();
           driver.FindElement(By.CssSelector("div.input-wrapper tbody tr:nth-of-type(2) td input[name*=categories]")).Click();
            //Check if right category is selected
            string DefaultCategory = driver.FindElement(By.CssSelector("select[name=default_category_id] option")).GetAttribute("innerText");
            NUnit.Framework.Assert.AreEqual(DefaultCategory, "Rubber Ducks");
            IWebElement quantity = driver.FindElement(By.CssSelector("input[name=quantity]"));
            quantity.Clear();
            quantity.SendKeys("30");
            driver.FindElement(By.CssSelector("input[type=file]")).SendKeys("C:/xampp/htdocs/litecart/images/products/2-green-duck-1.png");
            //Switch to Infromation tab
            driver.FindElement(By.CssSelector("ul.index li:nth-of-type(2) > a")).Click();
            //Verify if tab was switched
            string StringManufacturer = driver.FindElement(By.CssSelector("div#tab-information tr:nth-of-type(1) strong")).GetAttribute("innerText");
            NUnit.Framework.Assert.AreEqual(StringManufacturer, "Manufacturer");
            //Fill in Information tab
            driver.FindElement(By.CssSelector("select[name=manufacturer_id]")).Click();
            driver.FindElement(By.CssSelector("select[name=manufacturer_id] option:nth-of-type(2)")).Click();
            driver.FindElement(By.CssSelector("span.input-wrapper input[name*=short_description]")).SendKeys("The best duck in the world");
            driver.FindElement(By.CssSelector("div.trumbowyg-editor")).SendKeys("The is the best duck in the world. You definitely should buy it");
            //Switch to Prices tab
            driver.FindElement(By.CssSelector("ul.index li:nth-of-type(4) > a")).Click();
            //Verifiy if tab was switched
            string StringPrices = driver.FindElement(By.CssSelector("div#tab-prices h2:nth-of-type(1)")).GetAttribute("innerText");
            NUnit.Framework.Assert.AreEqual(StringPrices, "Prices");
            //Fill in information tab
            IWebElement PutchasePrice = driver.FindElement(By.CssSelector("input[name=purchase_price]"));
            PutchasePrice.Clear();
            PutchasePrice.SendKeys("20");
            IWebElement Price = driver.FindElement(By.CssSelector("tbody tr:nth-of-type(2) span.input-wrapper input[name*=prices]"));
            PutchasePrice.Clear();
            PutchasePrice.SendKeys("30");
            //Save the Product
            driver.FindElement(By.CssSelector("button[name=save]")).Click();
            wait.Until(ExpectedConditions.TitleIs("Catalog | My Store"));
            //Count number of rows in the table
            int RowsAfter = driver.FindElements(By.CssSelector("table.dataTable tr.row")).Count;
            NUnit.Framework.Assert.AreEqual(RowsBefore, RowsAfter-1);
        }

       






        [TearDown]

        public void stop()
        {
            driver.Quit();
            driver = null;
        }


    }
}
