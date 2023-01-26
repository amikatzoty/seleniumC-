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

namespace AmazonProj
{
    public class Results
    {
        private IWebDriver driver;
        //IReadOnlyList<IWebElement> items;
        private string xpath = "//div[@class='a-section a-spacing-small a-spacing-top-small'";
        //IList<IWebElement> items;
        private Dictionary<string, string> filter = new Dictionary<string, string>();
        //private string xpath = "$x("//span[@class='a-price' and translate(descendant::span[@class='a-offscreen']//.,'$','')]")";
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
            //preform our fillter search
            foreach (var filterxpath in filter)
            {
                switch (filterxpath.Key)
                {
                    case "Price_Lower_Then":
                        xpath += "and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class='a-price-decimal']), descendant::span[@class='a-price-fraction']) <" + filterxpath.Value;
                        break;
                    case "Price_Hiegher_OR_Equal_Then":
                        xpath += "and concat(concat(descendant::span[@class='a-price-whole'], descendant::span[class='a-price-decimal']),descendant::span[@class='a-price-fraction']) >=" + filterxpath.Value;
                        break;
                    case "Free_Shipping":
                        if (filterxpath.Value == "true") xpath += " and descendant::span[contains(text(), 'FREE')]";
                        break;
                }
            }
            xpath += "]";


            List<IWebElement> elements = driver.FindElements(By.XPath(xpath)).ToList();
            List<Item> items = new List<Item>();
            //string url = elements[0].FindElement(By.XPath((".//a[@class='a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']"))).GetAttribute("href");
            foreach (IWebElement element in elements)
            {
                //the the title and the price and add it to the list
                string title = element.FindElement(By.XPath((".//span[@class='a-size-medium a-color-base a-text-normal']"))).Text;
                string price = element.FindElement(By.XPath(".//span[@class='a-price-whole']")).Text + '.' + element.FindElement(By.CssSelector(".a-price-fraction")).Text + '$';
                string url = element.FindElement(By.XPath((".//a[@class='a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']"))).GetAttribute("href");
                items.Add(new Item(title, price, url));
            }
            return items;
        }




        /*  public List<Item> GetResultsBy(Dictionary<string,string>filters )
          {
              string xpath = "$x(\"//span[@class='a-price' and translate(descendant::span[@class='a-offscreen']//.,'$','')]\")";
              foreach (KeyValuePair<string,string> filter in filters)
              {
                  switch (filter.Key)
                  {
                      case DictionaryKeys.price_lower_then.ToString():
                          xpath = filter.Value;
                          break;
                      case DictionaryKeys.price_higher_or_equal.ToString():
                          xpath = filter.Value;
                          break;
                      case DictionaryKeys.free_shipping.ToString():
                          xpath = filter.Value;
                          break;
                  }
              }
          }*/
    }
}