using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSRuduo.Page;

namespace VCSRuduo.Tests
{
    class BasicCheckboxDemoTest
    {
        private static BasicCheckboxDemoPage _page;
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _page = new BasicCheckboxDemoPage(_driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Close();
        }

        [Test]
        public static void SingleCheckBoxTest()
        {
            _page.CheckSingleCheckBox()
                .AssertSingleCheckBoxDemoSuccessMessage()
                .UnCheckSingleCheckBox();
        }

        [Test]
        [Obsolete]
        public static void MultipleCheckBoxTest()
        {
            _page.CheckAllMultipleCheckBoxes();
            _page.AssertButtonName("Uncheck All");
        }

        [Test]
        public static void UncheckMultipleCheckBoxesTest()
        {
            _page.CheckAllMultipleCheckBoxes();
            _page.ClickGroupButton();
            _page.AssertMultipleCheckBoxesUnchecked();
        }

    }
}