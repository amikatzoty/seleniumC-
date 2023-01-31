using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AmazonProj;
using System.IO;
using AngleSharp.Dom;

namespace AmazonProj
{
    public class Results
    {
        private IWebDriver driver;
        
        
        private string xpath = "//span[@class='a-price-whole']";
        
        private Dictionary<string, string> filter = new Dictionary<string, string>();
        
        public Dictionary<string, string> Filter
        {
            get { return this.filter; }
            set { this.filter = value; }
        }
        public Results(IWebDriver driver)
        {
            this.driver = driver;
        }
        enum DictionaryKeys
        {
            price_lower_then,
            price_higher_or_equal,
            free_shipping
        }

        public List<Item> GetResultBy(Dictionary<string, string> filter)
        {
            IList<IWebElement> elements = new List<IWebElement>(); 
            //preform our fillter search
            foreach (var filterxpath in filter)
            {
                switch (filterxpath.Key)
                {
                    case "Price_Lower_Then":
                        
                        xpath += "[text()<" + filterxpath.Value + "]";
                        break;
                    case "Price_Hiegher_OR_Equal_Then":
                        xpath += "[text()>=" + filterxpath.Value + "]";
                        break;
                    case "Free_Shipping":

                        xpath += "/../../../../../../../..//span[contains(text(),'משלוח בחינם') or contains(text(),'משלוח חינם')]";


                        break;
                }
            }
            xpath += "/../../../../../..";
            elements = driver.FindElements(By.XPath(xpath));
            //correct xpath = //span[contains(text(),'משלוח בחינם') or contains(text(),'משלוח חינם')]/../../../../..//span[@class='a-price-whole'][text()>='10' and text() <100]/../../../../../../../../..
            //another corret xpath = //span[contains(text(),'משלוח בחינם') or contains(text(),'משלוח חינם')]/../../../../..//span[@class='a-price-whole'][text()>='10'][text() <100]/../../../../../../../../..
            //best xpath = //span[@class='a-price-whole'][text()>='10'][text() <100]/../../../../../../../..//span[contains(text(),'משלוח בחינם') or contains(text(),'משלוח חינם')]


            List<Item> items = new List<Item>();
            for(int i = 0; i < elements.Count; i++) 
            {
                

                String name = elements[i].FindElement(By.XPath(".//span[@class='a-size-medium a-color-base a-text-normal']")).Text;
                String price = elements[i].FindElement(By.XPath(".//span[@class='a-price-whole']")).Text + "." + elements[i].FindElement(By.XPath(".//span[@class='a-price-fraction']")).Text + "$";
                String shipping = "Free Shipment";
                
                 Item item = new Item(name,price, shipping);
                 items.Add(item);
            }

            return items;


           

            
        }




    }
}
