using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace Assignment.POM
{
    public class ProductsPage: PageBase
    {
        public ProductsPage(IWebDriver driver, IConfiguration config) : base(driver, config)
        {

        }

        #region "locators"
        string byKeywordTextXpath = "//input[@name='text_search_1_707']";
        string searchNowButtonXpath = "//a[text()='Search Now']";
        string openSearchLinkXpath = "//a[text()='Open Search']";
        string categoryDropDownXpath = "//select[@class='select2-hidden-accessible']";
        string productCategoryFirstProductElementXpath = "(//a[text()='Ethernet Cables'])[1]";
        string firstItemLinkXpath = "(//div[@class='text-holder'])[1]//a";

        #endregion



        #region "elements"

        public IWebElement byKeywordTextElement => WaitForVisible(By.XPath(byKeywordTextXpath));
        public IWebElement searchNowButtonElement => WaitForVisible(By.XPath(searchNowButtonXpath));
        public IWebElement openSearchLinkElement => WaitForVisible(By.XPath(openSearchLinkXpath));
        public IWebElement categoryDropDownElement => WaitForVisible(By.XPath(categoryDropDownXpath));
        public IWebElement productCategoryFirstProductElementElement => WaitForVisible(By.XPath(productCategoryFirstProductElementXpath));
        public IWebElement firstItemLinkElement => WaitForVisible(By.XPath(firstItemLinkXpath));

        #endregion



        #region "Methods"

        //method to verify products page title
        public string GetProductsPageTitle()
        {
            string xpath = "//h1[text()='Product Search - Automation, Control & Instrumentation Products']";
            IWebElement title = driver.FindElement(By.XPath(xpath));

            WaitForVisible(By.XPath(xpath));

            return title.Text;

        }

        //verify headers
        public bool VerifyHeaderContainsWeidmuller()
        {
            bool verify  =false;
            string xpath = "//div[@class='text-holder']//a[contains(text(),'Weidmuller')]";
            IReadOnlyCollection<IWebElement> headers = driver.FindElements(By.XPath(xpath));
            WaitForVisible(By.XPath(xpath));

            foreach (var temp in headers)
            {
                string text = temp.Text;
                verify = text.Contains("Weidmuller");
                if(verify == false)
                {
                    break;
                }
                

            }

            return verify;


        }



        #endregion

    }
}
