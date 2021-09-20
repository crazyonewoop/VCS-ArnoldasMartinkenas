using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo.Page
{
    public class InputPage
    {
        public static IWebDriver _driver;

        private IWebElement _inputField => _driver.FindElement(By.Id("user-message"));
        private IWebElement _showMessageButton => _driver.FindElement(By.CssSelector("#get-input > button"));

        private IWebElement _actualResultText => _driver.FindElement(By.Id("display"));

        private IWebElement _firstInput => _driver.FindElement(By.Id("sum1"));

        private IWebElement _secondInput => _driver.FindElement(By.Id("sum2"));

        private IWebElement _getTotalButton => _driver.FindElement(By.CssSelector("#gettotal > button"));

        private IWebElement _actualSumResult => _driver.FindElement(By.Id("displayvalue"));

        public InputPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void InsertTextToInputField(string text)
        {
            _inputField.Clear();
            _inputField.SendKeys(text);
        }

        public void ClickShowMessageButton()
        {
            _showMessageButton.Click();
        }

        public void VerifyResult(string result)
        {
            Assert.AreEqual(result, _actualResultText.Text, "Text is different");
        }

        public void InsertBothValuesToInputField(string firstValue, string secondValue)
        {
            InsertTextToFirstInputField(firstValue);
            InsertTextToSecondInputField(secondValue);
        }

        private void InsertTextToFirstInputField(string text)
        {
            _firstInput.Clear();
            _firstInput.SendKeys(text);
        }

        private void InsertTextToSecondInputField(string text)
        {
            _secondInput.Clear();
            _secondInput.SendKeys(text);
        }

        public void ClickGetTotalButton()
        {
            _getTotalButton.Click();
        }

        public void VerifySumResult(string result)
        {
            Assert.AreEqual(result, _actualSumResult.Text, "Result is not correct!");
        }

    }
}