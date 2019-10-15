using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Assignment
{
    public class Functions : Assignment
    {


        public static string GetAverageSalary(string region)
        {
            int i = 1;
            string follow = string.Empty;
        

            IReadOnlyCollection<IWebElement> firstColumn = driver.FindElements(By.XPath("(//div[@class='heading-box'])[3]//following-sibling::table[1]//tr//td[1]"));
            foreach (var temp in firstColumn)
            {
                follow = temp.Text;
                if (follow.Trim() == region)
                {
                     break;
                }
                i++;
            }
            
            string xpath = "(//div[@class='heading-box'])[3]//following-sibling::table[1]//tr[" + i + "]//td[2]";

            IWebElement value = driver.FindElement(By.XPath(xpath));
            string text = value.Text;

            return text;
        }

        public static string GetPercentCorrespondence(string region)
        {

            int i = 1;
            string follow = string.Empty;
         

            IReadOnlyCollection<IWebElement> firstColumn = driver.FindElements(By.XPath("(//div[@class='heading-box'])[4]//following-sibling::table[1]//tr//td[1]"));
            foreach (var temp in firstColumn)
            {
                follow = temp.Text;
                if (follow.Trim() == region)
                {
                    break;
                }
                i++;
            }

            string xpath = "(//div[@class='heading-box'])[4]//following-sibling::table[1]//tr[" + i + "]//td[3]";

            IWebElement value = driver.FindElement(By.XPath(xpath));
            string text = value.Text;

            return text;
        }


    }
}
