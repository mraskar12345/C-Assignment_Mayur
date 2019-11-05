using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Assignment
{
    public class Base
    {

        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
       

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent = new ExtentReports();
            string projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var htmlReporter = new ExtentHtmlReporter(projectPath + "/Reports/" + timestamp + "/");
            
            extent.AttachReporter(htmlReporter);

        }



        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.automation.com";
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }



        [TearDown]

        public void TearDown()
        {

            driver.Close();

        }

        [OneTimeTearDown]
        public void OnetimeTeardown()
        {
            extent.Flush();
            
        }


    }
}
