using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonProj;
using OpenQA.Selenium;
namespace AmazonProj
{
    public class Item
    {
        private string title;
        private string price;
        private string shipping;
        public Item(string title, string price, string shipping)
        {
            this.title = title;
            this.price = price;
            this.shipping = shipping;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Shipping
        {
            get { return shipping; }
            set { shipping = value; }
        }
    }
}