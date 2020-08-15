using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Drawing;
using System.Xml;
using System.ComponentModel;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using HtmlAgilityPack;
using System.Net.Http;
using OpenQA.Selenium.Support.UI;

namespace WebScrapping
{
    class Program
    {
         static void Main(string[] args)
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Url = "https://soundcloud.com/elias-vinicius/likes";

             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;

            Thread.Sleep(500);

            for(int i = 0; i<500; i++)
            {
                js.ExecuteScript("window.scrollBy(0,900000);");
            }

            List<string> lista = new List<string>();

            var a = driver.FindElements(By.XPath("//ul[@class = 'lazyLoadingList__list sc-list-nostyle sc-clearfix']//li//a[@class = 'soundTitle__title sc-link-dark']"));

            foreach (IWebElement list in a)
            {
                 var link = string.Format(list.GetAttribute("href").ToString());
                 lista.Add(link.ToString());
            }

            string path = @"C:\Lista.txt";
            using (StreamWriter sw = new StreamWriter(path))

                foreach(var list in lista)
                {
                    sw.WriteLine(list);
                    
                }

        }
    }
}
