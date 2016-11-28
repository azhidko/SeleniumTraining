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
    public class Class1

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

        public void SecondTest()
        {
            driver.Url = "http://localhost/litecart/en/";
          
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            
            int linkCount = driver.FindElements(By.CssSelector("a.link[title]")).Count;

            for (int i = 0; i <= linkCount - 1; i++)
            {
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("a.link[title] div[class*=sticker]")));

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
