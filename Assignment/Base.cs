using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Assignment
{
    public class Base
    {

        public static IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.automation.com";


        }





        [TearDown]

        public void TearDown()
        {

            driver.Close();

        }



    }
}
