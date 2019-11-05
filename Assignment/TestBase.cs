using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.POM;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Assignment
{
    public class TestBase
    {

        protected PageFactory pageFactory;
        protected IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        protected HomePage homePage;
        protected BuildingAutomationPage buildingAutomationPage;



        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent = new ExtentReports();
            string projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var htmlReporter = new ExtentHtmlReporter(projectPath + "/Reports/" + timestamp + "/");
            
            extent.AttachReporter(htmlReporter);
            pageFactory = new PageFactory(driver);

        }


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"C:\Tools\Selenium");
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.automation.com";
            //logging test name in extent report
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //instantiate pages
            homePage = pageFactory.GetPage<HomePage>();
            buildingAutomationPage = pageFactory.GetPage<BuildingAutomationPage>();

        }



        [TearDown]

        public void TearDown()
        {
            //checking final status and loggin it
            var outCome = TestContext.CurrentContext.Result.Outcome.Status;
            if(outCome == TestStatus.Passed)
            {
                test.Pass("test passed");
            }
            else if(outCome == TestStatus.Failed)
            {
                test.Fail(TestContext.CurrentContext.Result.Message);
            }


            driver.Close();

        }

        [OneTimeTearDown]
        public void OnetimeTeardown()
        {
            extent.Flush();
            
        }



    }
}
