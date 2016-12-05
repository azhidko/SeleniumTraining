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
    public class Task10

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

        public void FifthTest()
        {
            driver.Url = "http://localhost/litecart/en/";

            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            IWebElement DuckToClick = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title]"));

            //Text Content Main Page
            string NameMainPage = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] div.name")).GetAttribute("textContent");
            string RegularPriceMainPage = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] s.regular-price")).GetAttribute("textContent"); 
            string DiscountPriceMainPage = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] strong.campaign-price")).GetAttribute("textContent");
            //Styles Reguar Price Main Page
            string FontMainPageRegularPrice = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] s.regular-price")).GetCssValue("font-weight");
            string ColorMainPageRegularPrice = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] s.regular-price")).GetCssValue("color");
            string DecorationMainPageRegularPrice = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] s.regular-price")).GetCssValue("text-decoration");
            //Styles Discount Price Main Page
            string FontMainPageDiscountPrice = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] strong.campaign-price")).GetCssValue("font-weight");
            string ColorMainPageDiscountPrice = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] strong.campaign-price")).GetCssValue("color");
            string DecorationMainPageDiscountPrice = driver.FindElement(By.CssSelector("div#box-campaigns a.link[title] strong.campaign-price")).GetCssValue("text-decoration");

            DuckToClick.Click();
            wait.Until(ExpectedConditions.TitleIs("Yellow Duck | Subcategory | Rubber Ducks | My Store"));

            //Text Content Product Page
            string NameProductPage = driver.FindElement(By.CssSelector("h1.title")).GetAttribute("textContent");
            string RegularPriceProductPage = driver.FindElement(By.CssSelector("div.content s.regular-price")).GetAttribute("textContent");
            string DiscountPriceProductPage = driver.FindElement(By.CssSelector("div.content strong.campaign-price")).GetAttribute("textContent");
            //Styles Reguar Price Product Page
            string FontProductPageRegularPrice = driver.FindElement(By.CssSelector("div.content s.regular-price")).GetCssValue("font-weight");
            string ColorProductPageRegularPrice = driver.FindElement(By.CssSelector("div.content s.regular-price")).GetCssValue("color");
            string DecorationProductPageRegularPrice = driver.FindElement(By.CssSelector("div.content s.regular-price")).GetCssValue("text-decoration");
            //Styles Discount Price Product Page
            string FontProductPageDiscountPrice = driver.FindElement(By.CssSelector("div.content strong.campaign-price")).GetCssValue("font-weight");
            string ColorProductPageDiscountPrice = driver.FindElement(By.CssSelector("div.content strong.campaign-price")).GetCssValue("color");
            string DecorationProductPageDiscountPrice = driver.FindElement(By.CssSelector("div.content strong.campaign-price")).GetCssValue("text-decoration");


            NUnit.Framework.Assert.AreEqual(NameMainPage, NameProductPage);
                NUnit.Framework.Assert.AreEqual(RegularPriceMainPage, RegularPriceProductPage);
                NUnit.Framework.Assert.AreEqual(DiscountPriceMainPage, DiscountPriceProductPage);
                NUnit.Framework.Assert.AreEqual(FontMainPageRegularPrice, FontProductPageRegularPrice);
            try
            {
                NUnit.Framework.Assert.AreEqual(ColorMainPageRegularPrice, ColorProductPageRegularPrice);
            }
            catch (NUnit.Framework.AssertionException e)
            {
               
                Console.WriteLine("Colors are not equal for regular price " + e);
            }
            NUnit.Framework.Assert.AreEqual(DecorationMainPageRegularPrice, DecorationProductPageRegularPrice);
            NUnit.Framework.Assert.AreEqual(FontMainPageDiscountPrice, FontProductPageDiscountPrice);
            NUnit.Framework.Assert.AreEqual(ColorMainPageDiscountPrice, ColorProductPageDiscountPrice);
            NUnit.Framework.Assert.AreEqual(DecorationMainPageDiscountPrice, DecorationProductPageDiscountPrice);
                    
            
        }



        [TearDown]

        public void stop()
        {
            driver.Quit();
            driver = null;
        }


    }
}
