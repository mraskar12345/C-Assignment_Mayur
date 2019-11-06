
using AventStack.ExtentReports;
using NUnit.Framework;

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


    }
}
