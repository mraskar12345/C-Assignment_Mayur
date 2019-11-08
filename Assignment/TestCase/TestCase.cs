using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Assignment
{
    public class TestCase : TestBase
    {

        public WebDriverWait wait;

        [Test]
        public void Assignment1()
        {

            Actions action = new Actions(driver);
            //step 1-hover to industries and click on building automation
            homePage.HoverToIndustries(homePage.industriesLinkElement);
            homePage.buildingAutomationLinkElement.Click("click building automation link", 1);
                        
            //step 2-click on Building Automation e-Newsletter Archive
            buildingAutomationPage.eNewsLetterArchiveElement.Click("click enews letter archive",2);

            //verify that the navigation path displays “Portal > Industries > Building Automation > Building Automation e-Newsletter Archive”
            bool verify = buildingAutomationPage.VerifyPath();
            CommonFunctions.AssertLog(verify,"verified path is correct",2);

            // step 3-print count and title of all news papers
            buildingAutomationPage.PrintNewsPaperTitles();
            

        }


        [Test]
        public void Assignment2()
        {
            string text1 = string.Empty;
            string firstPdtTextAfter = string.Empty;

            //step-1 click products link
            homePage.productsLinkElement.Click("click products link",1);

            //verify title is Product Search - Automation, Control & Instrumentation Products
            CommonFunctions.AssertLog(productsPage.GetProductsPageTitle() == "Product Search - Automation, Control & Instrumentation Products", "product page title is correct", 1);

            //step -2 enter Weidmuller in bykeyword field
            productsPage.byKeywordTextElement.EnterText("Weidmuller", "enter text Weidmuller", 2);
            //step 3- click search now
            productsPage.searchNowButtonElement.Click("click search now", 3);
            //verify all header contains weidmuller
            CommonFunctions.AssertLog(productsPage.VerifyHeaderContainsWeidmuller(), "verify weidmuller is present in all headers",3);
            //step 4- click open search link
            productsPage.openSearchLinkElement.Click("click open search link", 4);
            //step 5- clear bykeyword field
            productsPage.byKeywordTextElement.Clear();
            //step -6 select category industril communication.ethernet cables
            productsPage.categoryDropDownElement.SelectFromDropDown("Industrial Communications / Ethernet Cables", "select Industrial Communications / Ethernet Cables from drop down", 6);
           
            //step-7 click search now
            productsPage.searchNowButtonElement.Click();
            //step 7- verify pdt category is ethernet cables for first product
            string text = productsPage.productCategoryFirstProductElementElement.Text;
            CommonFunctions.AssertLog(text == "Ethernet Cables", "product category is ethernet cables", 7);

            //step 8 -click first item link
            string textBefore = productsPage.firstItemLinkElement.Text;
            productsPage.firstItemLinkElement.Click("click first item link", 8);
            //verify details deisplayed
            CommonFunctions.AssertLog(productDetailsPage.productDetailsEntireSectionElement.Displayed, "product details dispalyed", 8);

            //step - 9 navigate back
            driver.Navigate().Back();
            //fetch first item text and compare with previous text
            string textAfter = productsPage.firstItemLinkElement.Text;
            CommonFunctions.AssertLog(textBefore == textAfter, "both before and after texts are same for first item", 9);

                                              
        }


        [Test]
        public void Asisgnment3()
        {

            //step 1-hover to job center and click 2018 salary survey results
            homePage.HoverToJobCenter(homePage.jobCenterLinkElement);
            homePage.salarySurveyResult2018Element.Click("click 2018 salary survey result", 1);

            //step 2-get average salary for south asia from section "average salary by region of world"
            string avgSalary = jobCenter_SalarySurveyResultsPage.GetAverageSalary("South Asia");
            Console.WriteLine(avgSalary);
            TestBase.test.Log(Status.Pass, "stpe 2 done");

            //step 3- get percent respondents for msection region of unitd states
            string percentRespondents = jobCenter_SalarySurveyResultsPage.GetPercentRespondents("Mountain (West)");
            Console.WriteLine(percentRespondents);
            TestBase.test.Log(Status.Pass, "step 3 done");


        }


       

    }
}
