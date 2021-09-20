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
    public class Paskaita1
    {
        //4 yra lyginis skaičius
        //Dabar 19 valanda

        [Test]
        public static void TestIf4IsEven()
        {
            int leftOver = 4 % 2;
            Assert.AreEqual(0, leftOver, "4 is not even");
        }

        [Test]
        public static void TestNowIs20()
        {
            DateTime currentTime = DateTime.Now;
            Assert.AreEqual(21, currentTime.Hour, "Dabar ne 20 valanda");
        }

        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://login.yahoo.com/";
            driver.Manage().Window.Maximize();
            driver.Quit();
        }


        [Test]
        public static void TestFireFoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            driver.Manage().Window.Maximize();
            driver.Quit();
        }



        [Test]
        public static void distancepace()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.active.com/fitness/calculators/pace";
            driver.Manage().Window.Maximize();

            IWebElement dropdown = driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span > span.selectboxit-arrow-container"));
            dropdown.Click();

            IWebElement km = driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > ul > li.selectboxit-option.selectboxit-option-first.selectboxit-selected.selectboxit-focus"));
            km.Click();

            IWebElement timeH = driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(1) > input[type=number]"));
            string TimeH = "1";
            timeH.SendKeys(TimeH);

            IWebElement timeM = driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(2) > input[type=number]"));
            string TimeM = "5";
            timeM.SendKeys(TimeM);

            IWebElement distance = driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > label > input[type=number]"));
            string Distance = "13";
            distance.SendKeys(Distance);

            IWebElement calculate = driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(6) > div > a"));
            calculate.Click();

            IWebElement PaceMin = driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > label:nth-child(2) > input[type=number]"));
            string result = "";



            Assert.AreEqual(result, PaceMin.Text, "Result is diffreant");
            Assert.IsTrue(PaceMin.Text.Contains(result), "result is diffreant");




        }
    }
}