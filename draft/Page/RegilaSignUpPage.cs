/* 2021-04-12 Ingrida Kudeliovė
 * 4 Case: Use of filters:
     * Open a pop-up modal
     * Find the filter attribute
     * Search for or type the desired value
     * Apply and close the modal
*/
using draft.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IKFinalProjectVCS.Page
{
    public class RegilaSignUpPage : BasePage
    {
        private const string PageAddress = "https://regila.lt/prisijungimas?create_account=1";
        private const string _feedbackMessageEntryRequired = "Please fill in this field";
        private IWebElement _submitButton => Driver.FindElement(By.XPath("//button[contains(.,'Išsaugoti')]"));
        private IWebElement _FeedbackNameRequiredMessage => Driver.FindElement(By.CssSelector("#customer-form > section > div:nth-child(2) > div")); 
        
        public RegilaSignUpPage(IWebDriver webdriver) : base(webdriver) { }

        public RegilaSignUpPage NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public RegilaSignUpPage PressSignUpButton()
        {
            _submitButton.Click();
            return this;
        }
        
        public RegilaSignUpPage VerifyNameDetailsRequiredFeedbackMessage()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(_feedbackMessageEntryRequired.Contains(_FeedbackNameRequiredMessage.Text));
            return this;
        }

    }
}
