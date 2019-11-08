using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace Assignment.POM
{
    public class JobCenter_SalarySurveyResultsPage: PageBase
    {
        public JobCenter_SalarySurveyResultsPage(IWebDriver driver, IConfiguration config) : base(driver, config)
        {

        }

        #region "locators"
        string productDetailsEntireSectionXpath = "(//div[@class='info-block'])[1]";

        #endregion



        #region "elements"

        public IWebElement productDetailsEntireSectionElement => WaitForVisible(By.XPath(productDetailsEntireSectionXpath));


        #endregion



        #region "Methods"

        //method to get average salary for south asia region
        public string GetAverageSalary(string region)
        {
            int i = 1;
            string follow = string.Empty;

            string xpath = "(//div[@class='heading-box'])[3]//following-sibling::table[1]//tr//td[1]";
            WaitForVisible(By.XPath(xpath));
            IReadOnlyCollection<IWebElement> firstColumn = driver.FindElements(By.XPath(xpath));
            foreach (var temp in firstColumn)
            {
                follow = temp.Text;
                if (follow.Trim() == region)
                {
                    break;
                }
                i++;
            }

            string xpath1 = "(//div[@class='heading-box'])[3]//following-sibling::table[1]//tr[" + i + "]//td[2]";

            IWebElement value = driver.FindElement(By.XPath(xpath1));
            
            return value.Text;
        }



        //method to get percent correspondence
        public string GetPercentRespondents(string region)
        {

            int i = 1;
            string follow = string.Empty;

            string xpath = "(//div[@class='heading-box'])[4]//following-sibling::table[1]//tr//td[1]";
            IReadOnlyCollection<IWebElement> firstColumn = driver.FindElements(By.XPath(xpath));
            WaitForVisible(By.XPath(xpath));

            foreach (var temp in firstColumn)
            {
                follow = temp.Text;
                if (follow.Trim() == region)
                {
                    break;
                }
                i++;
            }

            string xpath1 = "(//div[@class='heading-box'])[4]//following-sibling::table[1]//tr[" + i + "]//td[3]";

            IWebElement value = driver.FindElement(By.XPath(xpath1));
            
            return value.Text;
        }



        #endregion

    }
}
