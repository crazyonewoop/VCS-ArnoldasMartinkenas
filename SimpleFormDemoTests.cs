using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class SimpleFormDemoTests
    {
        [Test]
        public static void TestSingleInputField()
        {
            //Pakelia browser
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();

            //Susiranda web elementa
            IWebElement inputField = driver.FindElement(By.Id("user-message"));

            string myText = "Labas!";
            //irsao teksta i input field
            inputField.SendKeys(myText);

            //popup identifikacija
            IWebElement popup = driver.FindElement(By.Id("at-cv-lightbox-close"));
            popup.Click();

            //identifikuoja ShowMessage mygtuka
            IWebElement showMessageButton = driver.FindElement(By.CssSelector("#get-input > button"));

            //Paspaudzia ant showMessageButton mygtuko
            showMessageButton.Click();

            //Identifikuojam actual result elementa
            IWebElement actualResultText = driver.FindElement(By.Id("display"));

            //Tikrinam Expected vs Actual
            Assert.AreEqual(myText, actualResultText.Text, "Text is different");
            Assert.IsTrue(actualResultText.Text.Contains(myText), "Text is different");

            //uzdaro driveri
            driver.Quit();

        }
    }
}