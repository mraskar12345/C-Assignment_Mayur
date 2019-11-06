﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace Assignment
{
    public class PageBase
    {
        protected IWebDriver driver;
        private int waitTime;

        public PageBase(IWebDriver driver)
        {
            this.driver = driver;
            //waitTime = int.Parse(ConfigurationManager.AppSettings["Timeout"]);

            waitTime = 30;
        }

        //method to wait till element is visible
        protected IWebElement WaitForVisible(By locator, int seconds = -1)
        {
            if (seconds == -1)
                seconds = waitTime;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        //method to wait till element exists
        protected IWebElement WaitForExists(By locator, int seconds = -1)
        {
            if (seconds == -1)
                seconds = waitTime;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }

        //method to wait till element is clickable
        protected IWebElement WaitForClickable(By locator, int seconds = -1)
        {
            if (seconds == -1)
                seconds = waitTime;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
