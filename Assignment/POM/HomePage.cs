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
        string productsLinkXpath = "//li[@class='newnav']//a[text()='Products']";
        string jobCenterLinkXpath = "//li[@class='newnav right']//a[text()='Job Center']";
        string salarySurveyResult2018Xpath = "//a[text()='2018 Salary Survey Results ']";


        #endregion



        #region "elements"
        public IWebElement industriesLinkElement => WaitForVisible(By.XPath(industriesLinkXpath));
        public IWebElement buildingAutomationLinkElement => WaitForVisible(By.XPath(buildingAutomationLinkXpath));
        public IWebElement productsLinkElement => WaitForVisible(By.XPath(productsLinkXpath));
        public IWebElement jobCenterLinkElement => WaitForVisible(By.XPath(jobCenterLinkXpath));
        public IWebElement salarySurveyResult2018Element => WaitForVisible(By.XPath(salarySurveyResult2018Xpath));

        #endregion



        #region "Methods"
        //method to hover to industries
        public void HoverToIndustries(IWebElement element)
        {
            HoverToElement(element,"hover to industries",1);

        }
        
        //method to hover to job center
        public void HoverToJobCenter(IWebElement element)
        {
            HoverToElement(element, "hover to job center", 1);

        }






        #endregion






    }
}

