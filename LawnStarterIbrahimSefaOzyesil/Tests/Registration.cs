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
            Pages.QuoteQuestionsPage.SelectLessThan5ftShrubs("3");
            Pages.QuoteQuestionsPage.SelectBetween5ftAnd10ftShrubs("0");
            Pages.QuoteQuestionsPage.SelectShrubsAndHedgesMoreThan10ft("0");
            Pages.QuoteQuestionsPage.ClickOnGetMyQuoteButton();            
        }
        private void FillSchedulingPage()
        {
            var futureDate = DateTime.Today.AddMonths(6);
            Pages.SchedulingPage.SetPreferredDate(futureDate);
            Pages.SchedulingPage.SelectTrimmingPlan("Bi-Weekly");
            Pages.SchedulingPage.SetPreferredDate(futureDate);            
            Pages.SchedulingPage.ClickOnContinueButton();            
        }
        private void FillAccountAndPaymentPage()
        {
            Random randomNumber = new Random();
            string expiryDate = DateTime.Now.AddYears(1).ToString("MM/yy");
            string randomCVV = randomNumber.Next(100, 999).ToString();
            Pages.AccountsAndPaymentPage.SetFullNAme(Name.First());
            Pages.AccountsAndPaymentPage.SetLastName(Name.Last());
            Pages.AccountsAndPaymentPage.SetEmaillAddress(Internet.Email());            
            Pages.AccountsAndPaymentPage.SetCardNumber("4111111111111111");
            Pages.AccountsAndPaymentPage.SetExpiry(expiryDate);
            Pages.AccountsAndPaymentPage.SetCVV(randomCVV);
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
