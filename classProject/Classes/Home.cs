using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonProj;

namespace AmazonProj
{
    public class Home
    {
        private IWebDriver driver;
        private SearchBar searchBar;
        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }
        public SearchBar SearchBar
        {
            get
            {
                if (this.searchBar == null)
                {
                    this.searchBar = new SearchBar(this.driver);
                }
                return this.searchBar;
            }

        }
    }
}