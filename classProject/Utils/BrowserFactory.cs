using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using System.Configuration;
using AmazonProj;

namespace classProject.Utils
{
    public class BrowserFactory
    {
        public static IWebDriver driver;
        
        [SetUp]
        public void startBrowser()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            //1.ChromeOptions options = new ChromeOptions();
            // FirefoxOptions options = new FirefoxOptions();
            //1.options.AddArgument("start-maximized");
            //1.driver = new ChromeDriver("C:\\Drivers\\Chrome\\", options);
            // driver = new FirefoxDriver("C:\\Drivers\\Firefox\\");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }

        public void InitBrowser(String browseName)
        {
            switch (browseName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;

            }
        }
    }
}
