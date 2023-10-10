using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurricane_Insurance.Pages
{
    public class LandingPage
    {
        IWebDriver driver;
        By QuoteButton = By.ClassName("MuiButton-label");
        By ZipCode = By.ClassName("MuiInputBase-input");

        //Landing Page Constructor
        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Enters in a valid zip code
        public void TypeZipCode()
        {
            driver.FindElement(ZipCode).SendKeys("78748");
        }

        //Clicks on Quote Button
        public void ClickOnQuoteButton()
        {
            driver.FindElement(QuoteButton).Click();
        }

        //Enters a blank zip code
        public void TypeBlankZipCode()
        {
            driver.FindElement(ZipCode).SendKeys("");
        }

        //Enters an incorrect zip code
        public void TypeInvalidZip() 
        {
            driver.FindElement(ZipCode).SendKeys("0000");
        }
    }
}
