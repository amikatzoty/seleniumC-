using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using AmazonProj;
using NUnit.Framework;
using classProject.Utils;

namespace classProject.Tests
{
    public class UnitTest2 : BrowserFactory
    {

        List<IWebElement> mouses = new List<IWebElement>();
        new Dictionary<string, string> itemfilter = new Dictionary<string, string>();

        //Dictionary<string, string> filterDictionary = new Dictionary<string, string>();
      //  List<IWebElement> elementsList;
      //  List<Item> itemsList;

        [Test]
        public void test()
        {
            Amazon Amazon = new Amazon(driver);
            driver.Navigate().GoToUrl("https://www.amazon.com");

            Amazon.Pages.Home.SearchBar.Text = "mouse";
            Amazon.Pages.Home.SearchBar.Click();
            //Amazon.Pages.Home.SearchBar.Text = "mouse";
            //Amazon.Pages.Home.SearchBar.Click();

            //creat a result list after filltering
            List<Item> items = Amazon.Pages.Results.GetResultBy(new Dictionary<string, string>() {
                { "Price_Lower_Then", "100" },{"Price_Hiegher_OR_Equal_Then", "10" },{"Free_Shipping", "true"}});

            foreach (Item item in items)
            {
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Price + "\n");
                //Console.WriteLine(item.Url);
            }
            Assert.Pass();
            //Amazon.Pages.Results.GetResultsBy();
        }
        [TearDown]
        public void closeBrowser()
        {
            //driver.Quit();
        }
    }
}