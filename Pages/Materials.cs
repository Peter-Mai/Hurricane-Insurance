using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurricane_Insurance.Pages
{
    public class Materials
    {
        IWebDriver driver;
        By StrawRadio = By.ClassName("MuiIconButton-label");
        By NextButton = By.ClassName("MuiButton-label");

        //Materials Constructor
        public Materials(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Clicks on Straw radio button
        public void ClickStraw()
        {
            driver.FindElement(StrawRadio).Click();

        }

        //Clicks on Next Button on the Materials Page
        public void ClickNextButton()
        {
            driver.FindElement(NextButton).Click();
        }


    }
}
