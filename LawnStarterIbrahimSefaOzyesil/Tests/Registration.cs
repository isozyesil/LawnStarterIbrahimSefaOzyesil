using LawnStarterIbrahimSefaOzyesil.Paages;
using LawnStarterIbrahimSefaOzyesil.Assembly;
using NUnit.Framework;
using Faker;

namespace LawnStarterIbrahimSefaOzyesil.Tests
{
    [TestFixture]
    internal class Registration : TestBase
    {
        [Test]
        public void SignUp()
        {
            Logger.Info("Starting Test: FillOutQuotePage");
            FillQuotePage();
            FillSchedulingPage();
            FillAccountAndPaymentPage();
            VerifyBookingConfirmation();
            Logger.Info("Test Completed Successfully");
        }
        private void FillQuotePage()
        {
            Pages.QuoteQuestionsPage.SelectProperyType("Full Yard");
            Pages.QuoteQuestionsPage.SelectLessThan5ftShrubs("5");
            Pages.QuoteQuestionsPage.SelectBetween5ftAnd10ftShrubs("0");
            Pages.QuoteQuestionsPage.SelectShrubsAndHedgesMoreThan10ft("0");
            Pages.QuoteQuestionsPage.ClickOnGetMyQuoteButton();            
        }
        private void FillSchedulingPage()
        {
            Pages.SchedulingPage.ClickOnContinueButton();            
        }
        private void FillAccountAndPaymentPage()
        {
            Pages.AccountsAndPaymentPage.SetFullNAme(Name.First());
            Pages.AccountsAndPaymentPage.setLastName(Name.Last());
            Pages.AccountsAndPaymentPage.setEmaillAddress(Internet.Email());
            Pages.AccountsAndPaymentPage.SetCardNumber("4111111111111111");
            Pages.AccountsAndPaymentPage.SetExpiryDate("12/26");
            Pages.AccountsAndPaymentPage.SetCVV("123");
            Pages.AccountsAndPaymentPage.ClickOnAgreementCheckBox();
            Pages.AccountsAndPaymentPage.ClickOnBookNowButton();
        }
        private void VerifyBookingConfirmation()
        {
            
        }
    }
}
