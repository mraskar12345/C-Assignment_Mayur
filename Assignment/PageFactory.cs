using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Assignment
{
    public class PageFactory
    {
        public IWebDriver Driver;


        public PageFactory(IWebDriver driver)
        {
            Driver = driver;
        }


        public T GetPage<T>() where T : PageBase
        {

            var args = new Object[] { Driver };
            return (T)Activator.CreateInstance(typeof(T), args);

        }





    }
}
