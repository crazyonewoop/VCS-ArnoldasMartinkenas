using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class Paskaita1NamuDarbai
    {

        public static IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement popup = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            wait.Until(e => e.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            popup.Click();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a + b = NaN")]
        public static void TestSum(string firstValue, string secondValue, string expectedResult)
        {
            IWebElement firstInput = _driver.FindElement(By.Id("sum1"));
            firstInput.Clear();
            firstInput.SendKeys(firstValue);

            IWebElement secondInput = _driver.FindElement(By.Id("sum2"));
            secondInput.Clear();
            secondInput.SendKeys(secondValue);

            IWebElement getTotalButton = _driver.FindElement(By.CssSelector("#gettotal > button"));
            getTotalButton.Click();

            IWebElement actualResult = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(expectedResult, actualResult.Text, "Sum is Incorrect");
        }


















        //private static IWebDriver _driver;

        //[OneTimeSetUp]
        //public static void SetUp()
        //{
        //    _driver = new ChromeDriver();
        //    _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        //    IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
        //    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //    wait.Until(d => popUp.Displayed);
        //    popUp.Click();
        //}

        //[OneTimeTearDown]
        //public static void TearDown()
        //{
        //    _driver.Close();
        //}

        //[TestCase("2", "2", "4", TestName = "2 + 2 = 4")]
        //[TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        //[TestCase("a", "b", "NaN", TestName = "a + b = NaN")]
        //public static void TestSumBlock(string firstVaue, string secondValue, string expectedResult)
        //{
        //    IWebElement firstInput = _driver.FindElement(By.Id("sum1"));
        //    IWebElement secondInput = _driver.FindElement(By.Id("sum2"));
        //    firstInput.Clear();
        //    firstInput.SendKeys(firstVaue);
        //    secondInput.Clear();
        //    secondInput.SendKeys(secondValue);
        //    IWebElement getTotalButton = _driver.FindElement(By.CssSelector("#gettotal > button"));
        //    getTotalButton.Click();
        //    IWebElement actualResult = _driver.FindElement(By.Id("displayvalue"));
        //    Assert.AreEqual(expectedResult, actualResult.Text, "Sum is Incorrect");
        //}


    }
}