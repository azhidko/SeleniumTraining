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
    public class UnitTest1

    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
         //   driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));


        }

        [Test]

        public void FirstTest()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            int linkCount = driver.FindElements(By.CssSelector("li[id=app-]>a")).Count;

            for (int i = 0; i <= linkCount - 1; i++)
            {
                List<IWebElement> linksToClick = driver.FindElements(By.CssSelector("li[id=app-]>a")).ToList();
                linksToClick[i].Click();
               

               int linkCountInside = driver.FindElements(By.CssSelector("ul.docs a")).Count;
                if (linkCountInside > 0)
                {
                    for (int k = 0; k <= linkCountInside - 1; k++)
                    {
                        List<IWebElement> linksToClickInside = driver.FindElements(By.CssSelector("ul.docs a")).ToList();
                        linksToClickInside[k].Click();
                        wait.Until(ExpectedConditions.ElementExists(By.TagName("h1")));
                    }
                }
                wait.Until(ExpectedConditions.ElementExists(By.TagName("h1")));

               

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
