using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Assignment
{
    public class Assignment
    {

        public static IWebDriver driver;
        public WebDriverWait wait;

        [Test]
        public void Assignment1()
        {

            string text = string.Empty;


            string text1 = string.Empty;
            string finalPath = string.Empty;

            driver = new ChromeDriver(@"C:\Tools\Selenium");
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.automation.com";
           

           
            IWebElement Industries = driver.FindElement(By.XPath("//span[text()='Industries']"));

            //wait for industries to be present
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//span[text()='Industries']")));

            //hover to industries
            Actions action = new Actions(driver);
            action.MoveToElement(Industries).Build().Perform();

            //wait for Building Automation to be present
            IWebElement IndustriesBuildingAutomation = driver.FindElement(By.XPath("//a[text()='Building Automation']"));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//a[text()='Building Automation']")));

            //click building automation
            IndustriesBuildingAutomation.Click();

            //click on Building Automation e-Newsletter Archive
            IWebElement ENewsLetterArchive = driver.FindElement(By.XPath("//div[@class='holder']//a[text()='Building Automation e-Newsletter Archive']"));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='holder']//a[text()='Building Automation e-Newsletter Archive']")));
            ENewsLetterArchive.Click();

            //verify that the navigation path displays “Portal > Industries > Building Automation > Building Automation e-Newsletter Archive”
            IReadOnlyCollection<IWebElement> NavigationPath = driver.FindElements(By.XPath("//div[@class='breadcrumbs-block']//li"));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='breadcrumbs-block']//li")));

            foreach (var temp in NavigationPath)
            {
                text1 = temp.Text;
                finalPath = finalPath + " " +  text1;

            }

            Assert.That(finalPath.Trim() == "Industries Building Automation Building Automation e-Newsletter Archive");


                //print count and title of all news papers
                IReadOnlyCollection<IWebElement> ENewsLetterArchive1 = driver.FindElements(By.XPath("//div[@class='company-section add']//ul//li"));

            int count = ENewsLetterArchive1.Count;
            Console.WriteLine(count);

            foreach(var temp in ENewsLetterArchive1)
            {
                text = temp.Text;
                Console.WriteLine(text);
            }

           
            driver.Close();


        }


        [Test]
        public void Assignment2()
        {
            string text1 = string.Empty;
            string firstPdtTextAfter = string.Empty;

            driver = new ChromeDriver(@"C:\Tools\Selenium");
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.automation.com";



            IWebElement products = driver.FindElement(By.XPath("//li[@class='newnav']//a[text()='Products']"));
            //wait for products to be present
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//li[@class='newnav']//a[text()='Products']")));
            //click products
            products.Click();

            //verify title is Product Search - Automation, Control & Instrumentation Products
            IWebElement title = driver.FindElement(By.XPath("//h1[text()='Product Search - Automation, Control & Instrumentation Products']"));
            //wait for title to be present
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//h1[text()='Product Search - Automation, Control & Instrumentation Products']")));

            //verificaiton of title text
            string text = title.Text;
            Assert.That(text == "Product Search - Automation, Control & Instrumentation Products", "verify title is correct");

          



            //enter Weidmuller in bykeyword field
            IWebElement byKeyword = driver.FindElement(By.Name("text_search_1_707"));
            byKeyword.SendKeys("Weidmuller");

            //click search now
            IWebElement searchNow = driver.FindElement(By.XPath("//a[text()='Search Now']"));
            searchNow.Click();

            //identify all header elements
            IReadOnlyCollection<IWebElement> headers = driver.FindElements(By.XPath("//div[@class='text-holder']//a[contains(text(),'Weidmuller')]"));
            foreach(var temp in headers)
            {
                text1 = temp.Text;
                Assert.That(text1.Contains("Weidmuller"), "header contains Weidmuller");
                Console.WriteLine(text1 + "contains Weidnuller");

            }

            //click open search link
            IWebElement openSearchLink = driver.FindElement(By.XPath("//a[text()='Open Search']"));
            //clear bykeyword field
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Name("text_search_1_707")));
            openSearchLink.Click();
            //click search now
            try
            {
                byKeyword.Clear();
            }
            catch (StaleElementReferenceException ex)
            {
                IWebElement byKeyword1 = driver.FindElement(By.Name("text_search_1_707"));
                byKeyword1.Clear();
            }
            

            //select category industril communication.ethernet cables
            IWebElement categoryDropDown = driver.FindElement(By.XPath("//select[@class='select2-hidden-accessible']"));

            SelectElement category = new SelectElement(categoryDropDown);
            category.SelectByText("Industrial Communications / Ethernet Cables");


            //click search now
            try
            {
                searchNow.Click();
            }
            catch (StaleElementReferenceException ex)
            {
                IWebElement searchNow1 = driver.FindElement(By.XPath("//a[text()='Search Now']"));
                searchNow1.Click();
            }
            

            //product category for fist product
            IWebElement productCategoryFirstProduct = driver.FindElement(By.XPath("(//a[text()='Ethernet Cables'])[1]"));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("(//a[text()='Ethernet Cables'])[1]")));
            string text2 = productCategoryFirstProduct.Text;
            Assert.That(text2 == "Ethernet Cables" , "verify product category");

            //click first item hyper link
            IWebElement firstItem = driver.FindElement(By.XPath("//a[text()='Perle Systems announces INJ DIN Rail PoE Injectors']"));
            string firstPdtTextBefore = firstItem.Text;
            firstItem.Click();

            //verify pdt details displayed
            IWebElement productDetails = driver.FindElement(By.XPath("(//div[@class='info-block'])[1]"));
            bool visible = productDetails.Displayed;
            Assert.That(visible, "verify product details are displayed");

            //navigate back to previous page
            driver.Navigate().Back();

            //fetch first item text and cmpare with previous text
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//a[text()='Perle Systems announces INJ DIN Rail PoE Injectors']")));
            try
            {
                firstPdtTextAfter = firstItem.Text;
            }
            catch (StaleElementReferenceException ex)
            {
                IWebElement firstItem1 = driver.FindElement(By.XPath("//a[text()='Perle Systems announces INJ DIN Rail PoE Injectors']"));
                firstPdtTextAfter = firstItem1.Text;
            }
            
            Assert.That(firstPdtTextBefore == firstPdtTextAfter, "verify first item is still first item displayed");

            driver.Close();


        }


        [Test]
        public void Asisgnment3()
        {

            driver = new ChromeDriver(@"C:\Tools\Selenium");
            driver.Manage().Window.Maximize();

            driver.Url = "https://www.automation.com";



            IWebElement jobCenter = driver.FindElement(By.XPath("//li[@class='newnav right']//a[text()='Job Center']"));
            //wait for products to be present
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//li[@class='newnav right']//a[text()='Job Center']")));
            //hover to job center and click 2018 salary survey results
            Actions action = new Actions(driver);
            action.MoveToElement(jobCenter).Build().Perform();

            IWebElement salarySurveyResult2018 = driver.FindElement(By.XPath("//a[text()='2018 Salary Survey Results ']"));
            salarySurveyResult2018.Click();


            //get average salary
            string avgSalary = Functions.GetAverageSalary("South Asia");
            Console.WriteLine(avgSalary);




            //get percent correspondence
            string correspondence = Functions.GetPercentCorrespondence("Mountain (West)");
            Console.WriteLine(correspondence);

            driver.Close();

        }



    }
}
