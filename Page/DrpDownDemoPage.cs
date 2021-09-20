using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSRuduo.Page
{
    public class DropDownDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";

        private SelectElement _dropDown = new SelectElement(Driver.FindElement(By.Id("select-demo")));

        IWebElement _resultText => Driver.FindElement(By.CssSelector("#easycont > div > div.col-md-6.text-left > div:nth-child(4) > div.panel-body > p.selected-value"));

        public DropDownDemoPage(IWebDriver webDriver) : base(webDriver) { }

    }
}