

using draft.Drivers;
using draft.Page;
using draft.Tools;
using IKFinalProjectVCS.Page;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace draft.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static RegilaProductPage _page;
        public static RegilaSignUpPage _signUpPage;
        public static RegilaLoginPage _loginPage;
        
        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();

            _page = new RegilaProductPage(driver);
            _signUpPage = new RegilaSignUpPage(driver);
            _loginPage = new RegilaLoginPage(driver);
        }

        [TearDown]
        public static void TakeScreeshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}

