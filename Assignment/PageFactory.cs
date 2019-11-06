using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace Assignment
{
    public class PageFactory
    {
        public IWebDriver Driver;
        public IConfiguration Config;


        public PageFactory(IWebDriver driver, IConfiguration config)
        {
            Driver = driver;
            Config = config;

        }


        public T GetPage<T>() where T : PageBase
        {

            var args = new Object[] { Driver, Config };
            return (T)Activator.CreateInstance(typeof(T), args);

        }





    }
}
