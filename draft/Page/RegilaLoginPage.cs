using draft.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IKFinalProjectVCS.Page
{
    public class RegilaLoginPage : BasePage
    {
        private const string PageAddress = "https://regila.lt/prisijungimas?back=my-account";
        private const string _wrongDetailsEntered = "Identifikavimas nepavyko";
        private IWebElement _emailInput => Driver.FindElement(By.Name("email"));
        private IWebElement _passInput => Driver.FindElement(By.Name("password"));
        private IWebElement _loginButton => Driver.FindElement(By.Id("submit-login"));
        private IWebElement _FeedbackMessage => Driver.FindElement(By.CssSelector(".ps-alert-error > li:nth-child(2)"));


        public RegilaLoginPage(IWebDriver webdriver) : base(webdriver) { }

        public RegilaLoginPage NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public RegilaLoginPage InsertEmail(string email) 
        {
            _emailInput.Clear();
            _emailInput.SendKeys(email);
            return this;
        }
        public RegilaLoginPage InsertPass(string pass)
        {
            _passInput.Clear();
            _passInput.SendKeys(pass);
            return this;
        }
        public RegilaLoginPage PressLogin() 
        {
            _loginButton.Click();
            return this;
        }
        public RegilaLoginPage VerifyWrongDetailsFeedbackMessage() 
        {
            Thread.Sleep(2000);
            Assert.IsTrue(_wrongDetailsEntered.Contains(_FeedbackMessage.Text), $"Failed, expected result was {_wrongDetailsEntered}, but actual result was {_FeedbackMessage.Text}");
            return this;
        }
    }
}
