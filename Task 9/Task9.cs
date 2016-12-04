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
    public class Task9

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

        public void ThirdTest()
        {
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            wait.Until(ExpectedConditions.TitleIs("Countries | My Store"));
           

            int countryCount = driver.FindElements(By.CssSelector("tr.row td:nth-of-type(5) > a")).Count;
            string[] CountryTitles = new string[countryCount];
            string[] CountryToBeSorted = new string[countryCount];


            for (int i = 0; i <= countryCount - 1; i++)
            {
                List<IWebElement> Countries = driver.FindElements(By.CssSelector("tr.row td:nth-of-type(5) > a")).ToList();
                string  text = Countries[i].Text;
                CountryTitles[i] = text;
                CountryToBeSorted[i] = text;                            

            }

            Array.Sort<string>(CountryToBeSorted);
            if (!CountryTitles.SequenceEqual(CountryToBeSorted))
            {
                throw new Exception("Countries are in not alphabetical order ");
            }


            for (int i=0; i<=countryCount-1; i++)
            {
                List<IWebElement> Countries = driver.FindElements(By.CssSelector("tr.row td:nth-of-type(5) > a")).ToList();
                List<IWebElement> CountriesWithZones = driver.FindElements(By.CssSelector("tr.row td:nth-of-type(6)")).ToList();
                int NofZones = Int32.Parse(CountriesWithZones[i].GetAttribute("innerText"));
                if (NofZones > 0)
                {
                    Countries[i].Click();
                    int ZoneCount = driver.FindElements(By.CssSelector("tr td:nth-of-type(3) > input[type=hidden]")).Count;
                    string[] ZoneTitles = new string[ZoneCount];
                    string[] ZoneToBeSorted = new string[ZoneCount];
                    for (int k = 0; k <= ZoneCount - 1; k++)
                    {
                        List<IWebElement> Zones = driver.FindElements(By.CssSelector("tr td:nth-of-type(3) > input[type=hidden]")).ToList();
                        string text = Zones[k].GetAttribute("value");
                        ZoneTitles[k] = text;
                        ZoneToBeSorted[k] = text;
                    }
                    Array.Sort<string>(ZoneToBeSorted);
                    if (!ZoneTitles.SequenceEqual(ZoneToBeSorted))
                    {
                        throw new Exception("Zones are in not alphabetical order ");
                    }
                   driver.Navigate().Back();
                }
            }

           
           
        }

        [Test]

        public void FourthTest() {

            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();

            wait.Until(ExpectedConditions.TitleIs("Geo Zones | My Store"));

             int count = driver.FindElements(By.CssSelector("tr.row td:nth-of-type(3) > a")).Count;
          
            for (int i = 0; i <= count - 1; i++)
            {
                List<IWebElement> Countries = driver.FindElements(By.CssSelector("tr.row td:nth-of-type(3) > a")).ToList();
                Countries[i].Click();
                   int ZoneCount = driver.FindElements(By.CssSelector("table#table-zones tr td:nth-of-type(3) select  option[selected=selected]")).Count;
                   string[] ZoneTitles = new string[ZoneCount];
                   string[] ZoneToBeSorted = new string[ZoneCount];
                   for (int k = 0; k <= ZoneCount - 1; k++)
                   {
                       List<IWebElement> Zones = driver.FindElements(By.CssSelector("table#table-zones tr td:nth-of-type(3) select  option[selected=selected]")).ToList();

                       string text = Zones[k].GetAttribute("innerText");
                       ZoneTitles[k] = text;
                       ZoneToBeSorted[k] = text;

                   }
                   Array.Sort<string>(ZoneToBeSorted);
                   if (!ZoneTitles.SequenceEqual(ZoneToBeSorted))
                   {
                       throw new Exception("Zones are in not alphabetical order ");
                   }
                  
                driver.Navigate().Back();
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
