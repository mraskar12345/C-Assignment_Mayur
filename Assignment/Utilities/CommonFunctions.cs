
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Assignment.Utilities
{
    public static class CommonFunctions 
    {

        public static void AssertLog(bool condition, string message,int stepNumber=-1)
        {
            string step = (stepNumber == -1) ? "" : "Step " + stepNumber.ToString();
            message = step + " " + message;
            try
            {
                Assert.That(condition,message);

            }
            catch (AssertionException ex)
            {
                TestBase.test.Log(Status.Fail, message);
                throw ex;
            }
            TestBase.test.Log(Status.Pass, message);



        }

        //function to click element
        public static void Click(this IWebElement element , string message, int stepNumber = -1)
        {
            string step = (stepNumber == -1) ? "" : "Step " + stepNumber.ToString();
            message = step + " " + message;
            element.Click();
            TestBase.test.Log(Status.Pass, message);



        }

        //function to Enter text
        public static void EnterText(this IWebElement element,string text, string message, int stepNumber = -1)
        {
            string step = (stepNumber == -1) ? "" : "Step " + stepNumber.ToString();
            message = step + " " + message;
            element.SendKeys(text);
            TestBase.test.Log(Status.Pass, message);

        }

        //functions to select form drop down
        public static void SelectFromDropDown(this IWebElement element, string option,string message, int stepNumber = -1)
        {
            string step = (stepNumber == -1) ? "" : "Step " + stepNumber.ToString();
            message = step + " " + message;
            SelectElement select = new SelectElement(element);
            select.SelectByText(option);
            TestBase.test.Log(Status.Pass, message);



        }
       



    }
}
