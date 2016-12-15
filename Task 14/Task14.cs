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
    public class Task14

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

        public void WorkingWithWindowses()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            wait.Until(ExpectedConditions.TitleIs("My Store"));
            //Click on Countries
            driver.FindElement(By.CssSelector("ul#box-apps-menu li:nth-of-type(3) > a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));
            //Click to edit the first country in the list
            driver.FindElement(By.CssSelector("table tr.row:nth-of-type(2) a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Edit Country | My Store"));
            //Count number of links to click
            int LinkCount = driver.FindElements(By.CssSelector("table tr td:nth-of-type(1) > a[target=_blank]")).Count;

            for (int i = 0; i < LinkCount; i++)
            {
                List<IWebElement> linksToClick = driver.FindElements(By.CssSelector("table tr td:nth-of-type(1) > a[target=_blank]")).ToList();
                 linksToClick[i].Click();
                //switch to new window.
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector("head")));
                driver.Close();
                //switch back to your first window
                driver.SwitchTo().Window(driver.WindowHandles.First());
                wait.Until(ExpectedConditions.TitleIs("Edit Country | My Store"));
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
