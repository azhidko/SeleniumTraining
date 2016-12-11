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
using System.Text;

namespace csharp
{
    [TestClass]
    public class Task11

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

        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        [Test]

        public void AddUserTest()
        {
            driver.Url = "http://localhost/litecart/en/";

            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            driver.FindElement(By.CssSelector("form[name=login_form] a")).Click();
            wait.Until(ExpectedConditions.TitleIs("Create Account | My Store"));

            //Fill in data for new user
            driver.FindElement(By.CssSelector("input[name=firstname]")).SendKeys("Andrey");
            driver.FindElement(By.CssSelector("input[name=lastname]")).SendKeys("Zhidko");
            driver.FindElement(By.CssSelector("input[name=address1]")).SendKeys("Adress");
            driver.FindElement(By.CssSelector("input[name=postcode]")).SendKeys("12345");
            driver.FindElement(By.CssSelector("input[name=city]")).SendKeys("Kiev");
            string country = driver.FindElement(By.CssSelector("span.select2-selection__rendered")).GetAttribute("innerText");
            NUnit.Framework.Assert.AreEqual(country, "Ukraine");
            //generate unique email
            string NewUserLogin = RandomString(4) + "@google.com";        
            driver.FindElement(By.CssSelector("input[name=email]")).SendKeys(NewUserLogin);
            //Fill in Phone
           IWebElement phone = driver.FindElement(By.CssSelector("input[name=phone]"));
            phone.Clear();
            phone.SendKeys("+380123456789");
            string AccauntPassword = "test";
            driver.FindElement(By.CssSelector("input[name=password]")).SendKeys(AccauntPassword);
            driver.FindElement(By.CssSelector("input[name=confirmed_password]")).SendKeys(AccauntPassword);
            //Click to Create New User
            driver.FindElement(By.CssSelector("button[name=create_account]")).Click();
            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
            //Log out
            driver.FindElement(By.CssSelector("div.content ul.list-vertical li:nth-of-type(4) > a")).Click();
            //Log in again
            driver.FindElement(By.CssSelector("input[name=email]")).SendKeys(NewUserLogin);
            driver.FindElement(By.CssSelector("input[name=password]")).SendKeys(AccauntPassword);
            driver.FindElement(By.CssSelector("button[name=login]")).Click();
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div#box-account h3.title")));



        }



        [TearDown]

        public void stop()
        {
            driver.Quit();
            driver = null;
        }


    }
}
