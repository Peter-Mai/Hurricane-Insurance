using Hurricane_Insurance.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V115.FedCm;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hurricane_Insurance.Test
{
    [TestClass]
    public class HurricaneInsuranceTestScripts
    {
        [TestMethod]
       //Test Validation for Correct Zip Code
        public void VerifyCorrectZipCode()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sure-qa-challenge.vercel.app/");
            LandingPage landing = new LandingPage(driver);
            landing.TypeZipCode();

            //Act
            landing.ClickOnQuoteButton();




            //Assert
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement MaterialsText = driver.FindElement(By.CssSelector(".MuiTypography-root.MuiTypography-h5.MuiTypography-alignCenter"));
            string expectedText = MaterialsText.Text;
            Assert.AreEqual("What type of material is your home constructed with?", expectedText);
            driver.Quit();

        }

        [TestMethod]
        //Test Validation for Blank Zip Code
        public void VerifyBlankZipCode()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sure-qa-challenge.vercel.app/");
            LandingPage landing = new LandingPage(driver);
            landing.TypeBlankZipCode();
            //Act
            landing.ClickOnQuoteButton();

            //Assert
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement RequiredText = driver.FindElement(By.CssSelector(".MuiFormHelperText-root.Mui-error"));
            string expectedText = RequiredText.Text;
            Assert.AreEqual("Required", expectedText);
            driver.Quit();


        }

        [TestMethod]
        //Test Validation for Incorrect Zip Code
        public void VerifyInvalidZipCode()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sure-qa-challenge.vercel.app/");
            LandingPage landing = new LandingPage(driver);
            landing.TypeInvalidZip();

            //Act
            landing.ClickOnQuoteButton();

            //Assert
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            IWebElement InvalidZipCodeText = driver.FindElement(By.CssSelector(".MuiFormHelperText-root.Mui-error.MuiFormHelperText-filled"));
            string expectedText = InvalidZipCodeText.Text;
            Assert.AreEqual("Invalid zip code", expectedText);
            driver.Quit();
        }

        [TestMethod]
        //Test Validation for Correctly Submitting Building Materials
        public void SubmitBuildingMaterial()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sure-qa-challenge.vercel.app/");
            LandingPage landing = new LandingPage(driver);
            Materials materials = new Materials(driver);
            landing.TypeZipCode();
            landing.ClickOnQuoteButton();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            materials.ClickStraw();


            //Act
            materials.ClickNextButton();

            //Assert
            Thread.Sleep(1000);
            IWebElement WaterProximityText = driver.FindElement(By.CssSelector(".MuiTypography-root.MuiTypography-h5.MuiTypography-alignCenter"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            string expectedText = WaterProximityText.Text;
            Assert.AreEqual("Is your home located within 1 mile of a body of water?", expectedText);
            driver.Quit();

        }
    }
}
