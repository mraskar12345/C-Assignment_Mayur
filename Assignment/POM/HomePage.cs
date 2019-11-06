using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Assignment.POM
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver, IConfiguration config) : base(driver, config)
        {

        }

        #region "locators"
        string industriesLinkXpath = "//span[text()='Industries']";
        string buildingAutomationLinkXpath = "//a[text()='Building Automation']";

        #endregion



        #region "elements"
        public IWebElement industriesLinkElement => WaitForVisible(By.XPath(industriesLinkXpath));
        public IWebElement buildingAutomationLinkElement => WaitForVisible(By.XPath(buildingAutomationLinkXpath));

        #endregion



        #region "Methods"


        #endregion






    }
}
