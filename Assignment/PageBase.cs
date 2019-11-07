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
using OpenQA.Selenium.Interactions;
using AventStack.ExtentReports;

namespace Assignment
{
    public class PageBase
    {
        protected IWebDriver driver;
        protected IConfiguration config;
        private int waitTime;


        public PageBase(IWebDriver driver, IConfiguration config)
        {
            this.driver = driver;
            this.config = config;
            waitTime = int.Parse(config["Timeout"]);

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

        //function to hover to element
        public void HoverToElement(IWebElement element, string message, int stepNumber = -1)
        {
            string step = (stepNumber == -1) ? "" : "Step " + stepNumber.ToString();
            message = step + " " + message;
            Actions action = new Actions(driver);
            action.MoveToElement(element).Build().Perform();
            TestBase.test.Log(Status.Pass, message);

        }
    }
}
