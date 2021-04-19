using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace draft.Page
{
    public class RegilaProductPage : BasePage
    {
        private const string PageAddress = "https://regila.lt/nepralaidus-sviesai-roletai/55-2019-black-out-balto-atspalvio-roletai.html#/30-kreipianciosios-yra/33-vald_p-desine/158-roletu_tipas-prie_lango/322-spalva-bo3000/418-spalvu_grupes-balta";
        private const string _afterSuccessfulInputNewsletterMessage = "Jūs sėkmingai užsiprenumeravote šį naujienlaiškį.";
        private const string _emailAlreadyRegisteredToGetNewsletterMessage = "Šis el.pašto adresas jau registruotas.";
        private const string _productAddedToChartMessage = "Prekė sėkmingai pridėta į krepšelį";
        private IWebElement _newsletterInput => Driver.FindElement(By.CssSelector("#footer > div.container > div > div.block_newsletter.col-lg-8.col-12 > div > div > form > div.input-group > input"));
        private IWebElement _orderNewsletterButton => Driver.FindElement(By.Name("submitNewsletter"));
        private IWebElement _newsletterAlert => Driver.FindElement(By.CssSelector(".alert"));
        private IWebElement _measureUnitCM => Driver.FindElement(By.XPath("//label[contains(.,'cm')]"));
        private IWebElement _resultBox => Driver.FindElement(By.XPath("//h3[contains(.,'Prekė sėkmingai pridėta į krepšelį')]"));
        private IWebElement _medziagosPlotisInput => Driver.FindElement(By.Name("textField167"));
        private IWebElement _gaminioPlotisInput => Driver.FindElement(By.Name("textField168"));
        private IWebElement _gaminioAukstisInput => Driver.FindElement(By.Name("textField169"));
        private IWebElement _kaireValdymoPuse => Driver.FindElement(By.XPath("//label[contains(.,'Kairė')]"));
        private IWebElement _desineValdymoPuse => Driver.FindElement(By.XPath("//label[contains(.,'Dešinė')]"));
        private IWebElement _kiekis => Driver.FindElement(By.Id("quantity_wanted"));
        private IWebElement _addToChartButton => Driver.FindElement(By.CssSelector("#add-to-cart-or-refresh > div.product-add-to-cart > div > div.add.col > button"));
        public RegilaProductPage(IWebDriver webdriver) : base(webdriver) { }
        public RegilaProductPage NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public RegilaProductPage InsertEmailToOrderNewsletter(string email)
        {
            _newsletterInput.Clear();
            _newsletterInput.SendKeys(email);
            return this;
        }
        public RegilaProductPage ClickOrderNewsletterButton()
        {
            _orderNewsletterButton.Click();
            return this;
        }
        public RegilaProductPage AssertOrderNewsletterSuccessFeedback()
        {
            GetWait(5); 
            Assert.IsTrue(_afterSuccessfulInputNewsletterMessage.Contains(_newsletterAlert.Text));
            return this;
        }
        public RegilaProductPage AssertOrderNewsletterWithTheSameEMailFeedback()
        {
            GetWait(5); 
            Assert.IsTrue(_emailAlreadyRegisteredToGetNewsletterMessage.Contains(_newsletterAlert.Text));
            return this;
        }
        public RegilaProductPage CheckMeasureCMBox(bool selected)
        {
            if (selected != _measureUnitCM.Selected)
            {
                _measureUnitCM.Click();
            }
            return this;
        }
        public RegilaProductPage InsertMedziagosPlotis(string medziagosPlotis)
        {
            _medziagosPlotisInput.Clear();
            _medziagosPlotisInput.SendKeys(medziagosPlotis);
            return this;
        }
        public RegilaProductPage InsertGaminioPlotis(string gaminioPlotis)
        {
            _gaminioPlotisInput.Clear();
            _gaminioPlotisInput.SendKeys(gaminioPlotis);
            return this;
        }
        public RegilaProductPage InsertGaminioAukstis(string gaminioAukstis)
        {
            _gaminioAukstisInput.Clear();
            _gaminioAukstisInput.SendKeys(gaminioAukstis);
            return this;
        }
        public RegilaProductPage CheckKaireValdymoPuse(bool selected)
        {

            if (selected == _desineValdymoPuse.Selected)
            {
                _kaireValdymoPuse.Click();
            }
            return this;
        }
        public RegilaProductPage InsertKiekis(string kiekis)
        {
            if (_kiekis.Equals(kiekis))
            {
                return this;
            }
            else
            {
                _kiekis.Clear();
                _kiekis.SendKeys(kiekis);
            }
            return this;
        }
        public RegilaProductPage ClickAddToChartButton()
        {

            _addToChartButton.Click();
            return this;
        }
        public RegilaProductPage CheckIfProductAddedToChart()
        {
            GetWait(5); 
            Assert.IsTrue(_resultBox.Text.Contains(_productAddedToChartMessage));
            return this;
        }
    }
}

