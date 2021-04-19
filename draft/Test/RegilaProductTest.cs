using NUnit.Framework;

namespace draft.Test
{
    public class RegilaProductTest : BaseTest
    {
        [Order(1)]
        [TestCase("test2@test.com", TestName = "Order newsletter, e-mail never been entered")]
        public static void OrderNewsletterTest(string email)
        {
            _page.NavigateToPage()
                .InsertEmailToOrderNewsletter(email)
                .ClickOrderNewsletterButton()
                .AssertOrderNewsletterSuccessFeedback();
        }
        [Order(2)]
        [TestCase("test2@test.com", TestName = "Newsletter already been ordered feedback")]
        public static void OrderNewsletterUsingTheSameEmailTwiceTest(string email)
        {
            _page.NavigateToPage()
                .InsertEmailToOrderNewsletter(email)
                .ClickOrderNewsletterButton()
                .AssertOrderNewsletterWithTheSameEMailFeedback();

        }
       [TestCase(true, "64", "68", "120", true, "2", TestName ="Baltu roletu apibudinimas ir pridejimas i krepseli")]
       public static void SingleCheckBoxTest(bool measure, string mPlotis, string gPlotis, string aukstis, bool valdymas, string kiekis)
        {
            _page.NavigateToPage()
                .CheckMeasureCMBox(measure)
                .InsertMedziagosPlotis(mPlotis)
                .InsertGaminioPlotis(gPlotis)
                .InsertGaminioAukstis(aukstis)
                .CheckKaireValdymoPuse(valdymas)
                .InsertKiekis(kiekis)
                .ClickAddToChartButton()
                .CheckIfProductAddedToChart();
            
        }
    }
}

