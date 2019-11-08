using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace Assignment.POM
{
    public class ProductDetailsPage: PageBase
    {

        public ProductDetailsPage(IWebDriver driver, IConfiguration config) : base(driver, config)
        {

        }

        #region "locators"
        string productDetailsEntireSectionXpath = "(//div[@class='info-block'])[1]";
       
        #endregion



        #region "elements"

        public IWebElement productDetailsEntireSectionElement => WaitForVisible(By.XPath(productDetailsEntireSectionXpath));
      

        #endregion



        #region "Methods"

       

        #endregion
    }
}
