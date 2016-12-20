using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace csharp
{
    public class Application
    {


        private IWebDriver driver;
        private WebDriverWait wait;
        private ProductPage productpage;
        private BasketPage basketpage;

        public Application()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            productpage = new ProductPage(driver);
            basketpage = new BasketPage(driver);
           
        }

        public void Quit()
        {
            driver.Quit();
            driver = null;
        }
       
        public void NavigateToTheShop()
        {
            driver.Url = "http://localhost/litecart/en/";

            wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));


        }

        public void SelectDucksFromMostPopular(int ducks)
        {

            for (int i = 0; i < ducks; i++)

            {          
                productpage.ClickOnTheProduct();
                int ItemsInTheBasket = productpage.CountProductsInTheBasket();
                //Checking if there is a size control
                if (productpage.VerifySizeControl())
                {
                    string size = "Small";
                    productpage.SelectSize(size);
                 }
                productpage.AddItemToBasket(i, ItemsInTheBasket);
                driver.Navigate().Back();
                wait.Until(ExpectedConditions.TitleIs("Online Store | My Store"));
              }
            
        }

        public void NavigateToTheBasket()
        {
            basketpage.OpenBasket();
        }

        public void RemoveItemsFromBasket()
        {
            //Get amount of unique items in the order
            int UniqueItems = driver.FindElements(By.CssSelector("ul.shortcuts li.shortcut")).Count;
            basketpage.RemoveItemsFromBasket(UniqueItems);

        }
    }
}
