using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo
{
    public class BrowserDemoTest
    {
        private static IWebDriver _driver;

        [TearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("Chrome", TestName = "Testing Chrome")]
        [TestCase("Firefox", TestName = "Testing Firefox")]
        public static void TestBrowser(String browser)
        {
            if ("Chrome".Equals(browser))
                _driver = new ChromeDriver();
            if ("Firefox".Equals(browser))
                _driver = new FirefoxDriver();

            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");

            IWebElement actualResult = _driver.FindElement(By.CssSelector("#primary-detection > div"));
            Assert.IsTrue(actualResult.Text.Contains(browser), $"Browser is not {browser}");
        }

    }
}
