using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class CheckboxDemo
    {
        public static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [Test]
        public static void TestSingleCheckboxDemo()
        {
            IWebElement singleCheckBox = _driver.FindElement(By.Id("isAgeSelected"));
            singleCheckBox.Click();

            IWebElement singleCheckBoxResult = _driver.FindElement(By.Id("txtAge"));
            Assert.IsTrue(singleCheckBoxResult.Text.Contains("Success"));
        }

        [Test]
        public static void TestMultipleCheckBox()
        {
            IReadOnlyCollection<IWebElement> multipleCheckBoxes = _driver.FindElements(By.ClassName("cb1-element"));

            foreach (IWebElement checkBox in multipleCheckBoxes)
            {
                checkBox.Click();
            }
        }

        [Test]
        public static void TestButton()
        {
            IWebElement button = _driver.FindElement(By.CssSelector("#check1"));
            if (button.GetAttribute("value").Equals("Check All"))
            {
                button.Click();
            }
        }
    }
}