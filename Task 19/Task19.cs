using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;


namespace csharp
{
    [TestClass]
    public class Task19 : TestBase

    {
      
        [Test]

        public void PageObject()
        {
            int ducks = 3;
            app.NavigateToTheShop();
            app.SelectDucksFromMostPopular(ducks);
            app.NavigateToTheBasket();
            app.RemoveItemsFromBasket();
         
          

        }



       

       
}
    
}
