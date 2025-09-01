using LawnStarterIbrahimSefaOzyesil.Helpers;

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
            Pages.QuoteQuestionsPage.SelectLessThan5ftShrubs("3");
            Pages.QuoteQuestionsPage.SelectBetween5ftAnd10ftShrubs("0");
            Pages.QuoteQuestionsPage.SelectShrubsAndHedgesMoreThan10ft("0");
            Pages.QuoteQuestionsPage.ClickOnGetMyQuoteButton();            
        }
        private void FillSchedulingPage()
        {
            var futureDate = TestDataHelper.FutureDate(6);
            Pages.SchedulingPage.SelectTrimmingPlan("Bi-Weekly");
            Pages.SchedulingPage.SetPreferredDate(futureDate);      
            Pages.SchedulingPage.ClickOnContinueButton();            
        }
        private void FillAccountAndPaymentPage()
        {                    
            Pages.AccountsAndPaymentPage.SetFullNAme(TestDataHelper.FullName);
            Pages.AccountsAndPaymentPage.SetLastName(TestDataHelper.LastName);
            Pages.AccountsAndPaymentPage.SetEmaillAddress(TestDataHelper.Email);            
            Pages.AccountsAndPaymentPage.SetCardNumber(TestDataHelper.CardNumber);
            Pages.AccountsAndPaymentPage.SetExpiry(TestDataHelper.Expiry);
            Pages.AccountsAndPaymentPage.SetCVV(TestDataHelper.CVV);
            Pages.AccountsAndPaymentPage.ClickOnAgreementCheckBox();
            Pages.AccountsAndPaymentPage.ClickOnBookNowButton();
        }
        private void VerifyBookingConfirmation()
        {
            Pages.OtherSeervicesPage.ClickOnNoThanksButton();
            Pages.PropertyInfoPage.VerifyThatPropertyPageIsLoaded();
        }
    }
}
