using LawnStarterIbrahimSefaOzyesil.Paages;
using LawnStarterIbrahimSefaOzyesil.Assembly;
using Faker;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace LawnStarterIbrahimSefaOzyesil.Tests
{
    [TestFixture]
    internal class NoteActivities : TestBase
    {
        [Test]
        public void FillOutQuotePage()
        {
            Pages.QuoteQuestionsPage.SelectProperyType("Full Yard");
            Pages.QuoteQuestionsPage.SelectLessThan5ftShrubs("5");
            Pages.QuoteQuestionsPage.SelectBetween5ftAnd10ftShrubs("0");
            Pages.QuoteQuestionsPage.SelectShrubsAndHedgesMoreThan10ft("0");
            Pages.QuoteQuestionsPage.ClickOnGetMyQuoteButton();
            Pages.SchedulingPage.SelectTrimmingPlan("Bi-Weekly");
            Pages.SchedulingPage.SelectTrimmingPlan("Monthly");
            Pages.SchedulingPage.SelectTrimmingPlan("Quarterly");
        }
        [Test]
        public void VerifyToDoTaskCanBeCompleted()
        {
           
        }
    }
}
