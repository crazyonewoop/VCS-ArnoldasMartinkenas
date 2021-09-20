using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSRuduo.Page
{
    public class BasicCheckboxDemoPage : BasePage
    {
        private const string _singleCheckBoxMessageText = "Success - Check box is checked";

        private const string _pageAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";

        private IWebElement _singleCheckBox => Driver.FindElement(By.Id("isAgeSelected1"));

        private IWebElement _singleCheckBoxMessage => Driver.FindElement(By.Id("txtAge"));

        private IReadOnlyCollection<IWebElement> _multipleCheckBoxes => Driver.FindElements(By.ClassName("cb1-element"));

        private IWebElement _checkAllButton => Driver.FindElement(By.Id("check1"));

        public BasicCheckboxDemoPage(IWebDriver webDriver) : base(webDriver)
        {

            Driver.Url = _pageAddress;

        }

        public BasicCheckboxDemoPage CheckSingleCheckBox()
        {
            if (!_singleCheckBox.Selected)
            {
                _singleCheckBox.Click();
            }

            return this;
        }

        public BasicCheckboxDemoPage UnCheckSingleCheckBox()
        {
            if (_singleCheckBox.Selected)
                _singleCheckBox.Click();

            return this;
        }

        public BasicCheckboxDemoPage AssertSingleCheckBoxDemoSuccessMessage()
        {

            Assert.AreEqual(_singleCheckBoxMessageText, _singleCheckBoxMessage.Text, "tekstas nesutampa!");

            return this;
        }

        public BasicCheckboxDemoPage AssertSingleCheckBoxDemoSuccessMessageWithWait()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(_singleCheckBoxMessageText, _singleCheckBoxMessage.Text, "tekstas nesutampa!");

            return this;
        }


        public BasicCheckboxDemoPage CheckAllMultipleCheckBoxes()
        {
            UnCheckSingleCheckBox();
            foreach (IWebElement singleCheckbox in _multipleCheckBoxes)
            {
                if (!singleCheckbox.Selected)
                    singleCheckbox.Click();
            }

            return this;
        }

        [Obsolete]
        public BasicCheckboxDemoPage AssertButtonName(string expectedName)
        {
            GetWait().Until(ExpectedConditions.TextToBePresentInElementValue(_checkAllButton, "Uncheck All"));

            Assert.AreEqual(expectedName, _checkAllButton.GetAttribute("value"), "Wrong button label");

            return this;
        }

        public BasicCheckboxDemoPage ClickGroupButton()
        {
            _checkAllButton.Click();

            return this;
        }

        public BasicCheckboxDemoPage AssertMultipleCheckBoxesUnchecked()
        {
            foreach (IWebElement singleCheckbox in _multipleCheckBoxes)
            {
                Assert.False(singleCheckbox.Selected, "One of checkboxes is still checked!");
            }

            return this;
        }
    }
}