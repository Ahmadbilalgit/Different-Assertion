using NUnit.Framework;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SampleBasic

{

    public static class Entrypoint
    {
       static IWebDriver driver = new ChromeDriver("./");

        static void Assert_True()

        {
            Assert.IsTrue(driver.PageSource.Contains("Welcome to our store")); //The better approach would be to use try block in order to avoid any exception.
            System.Console.WriteLine("\n Greeting Text found");// In this case the assertion result are true, therefore code get executed witout any exception.

            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Featured products"));
            System.Console.WriteLine("\n" + "Feature Product found");
         
        }

        
       static void Assert_Equal()

        {

            try
            {
                Assert.AreEqual("My Home page", driver.Title);
                System.Console.WriteLine("\n Title is correct");
               
            }

            catch (Exception e)
            {

                System.Console.WriteLine("\n Title does not match");
            }

            IWebElement Link = driver.FindElement(By.LinkText("Apparel"));

            try
            {
                Assert.AreEqual(Link.Text, "Apparel");
                System.Console.WriteLine("\n Link Text are matched");

            }

            catch (Exception e)
            {

                System.Console.WriteLine("\n Link Text are not matched");
            }


            IWebElement Addtocart_button = driver.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div/div[4]/div[2]/div[1]/div/div[2]/div[3]/div[2]/input[1]"));
            String Test = Addtocart_button.GetAttribute("value");
            Assert.AreEqual("Add to cart", Test);
            System.Console.WriteLine("\n Button Label is Add to cart");
            

        }


        public static void Main()
        {
    
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
            Thread.Sleep(2000);
            Assert_True();
            Assert_Equal();
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();


        }

    }
}
