using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using classProject.Tests;

namespace AmazonProj
{
    public class SearchBar
    {
        private IWebDriver driver;
        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string Text
        {
            get
            {
                //implemenet return text from search bar
                //  element = this.driver.FindElement();
                // return element.Text;
                var SearchBar = UnitTest2.driver.FindElement(By.Id("twotabsearchtextbox"));
                return SearchBar.Text;
            }
            set
            {
                //implement Set text into text bar
                // element = this.driver.FindElement();
                //  element.type(value)
                var SearchBar = UnitTest2.driver.FindElement(By.Id("twotabsearchtextbox"));
                SearchBar.SendKeys(value);
            }
        }
        public void Click()
        {
            var SearchBar = UnitTest2.driver.FindElement(By.Id("nav-search-submit-button"));
            SearchBar.Click();
        }
    }
}