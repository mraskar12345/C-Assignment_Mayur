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

    public class IndustriesBuildingAutomationPage : PageBase
    {

        public IndustriesBuildingAutomationPage(IWebDriver driver, IConfiguration config) :base(driver, config)
        {

        }

        #region "locators"
        string eNewsLetterArchiveXpath = "//div[@class='holder']//a[text()='Building Automation e-Newsletter Archive']";
        

        #endregion



        #region "elements"
        public IWebElement eNewsLetterArchiveElement => WaitForVisible(By.XPath(eNewsLetterArchiveXpath));


        #endregion



        #region "Methods"

        //function to verify path is “Portal > Industries > Building Automation > Building Automation e-Newsletter Archive”
        public bool VerifyPath()
        {
            string text1 = string.Empty;
            string finalPath = string.Empty;
            string xpath = "//div[@class='breadcrumbs-block']//li";
            //fetch 3 elements which builds the path
            IReadOnlyCollection<IWebElement> NavigationPath = driver.FindElements(By.XPath(xpath));
            WaitForVisible(By.XPath(xpath));

            foreach (var temp in NavigationPath)
            {
                text1 = temp.Text;
                finalPath = finalPath + " " + text1;

            }

            bool verify = finalPath.Trim() == "Industries Building Automation Building Automation e-Newsletter Archive";

            return verify;

        }


        //function to print news paper titles
        public void PrintNewsPaperTitles()
        {
            string text = string.Empty;
            string xpath = "//div[@class='company-section add']//ul//li";
            IReadOnlyCollection<IWebElement> ENewsLetterArchive1 = driver.FindElements(By.XPath(xpath));
            WaitForVisible(By.XPath(xpath));

            int count = ENewsLetterArchive1.Count;
            Console.WriteLine(count);

            foreach (var temp in ENewsLetterArchive1)
            {
                text = temp.Text;
                Console.WriteLine(text);

            }
        }

        #endregion


    }
}
