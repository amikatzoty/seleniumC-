
using AmazonProj;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonProj
{
    public class Amazon
    {
        private IWebDriver driver;
        private Pages pages;
        public Amazon(IWebDriver driver)
        {
            this.driver = driver;
        }
        public Pages Pages
        {
            get
            {
                if (pages == null)
                {
                    this.pages = new Pages(this.driver);
                }
                return this.pages;
            }
        }
    }
}