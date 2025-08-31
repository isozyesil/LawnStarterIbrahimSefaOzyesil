using SeleniumExtras.PageObjects;
using LawnStarterIbrahimSefaOzyesil.Paages;
using LawnStarterIbrahimSefaOzyesil.Pages;


namespace LawnStarterIbrahimSefaOzyesil.Assembly
{
    public class Pages
    {
        private Browsers _browser;
        public Pages(Browsers browser)
        {
            _browser = browser;
            browser.LawnStarterQuoteCreation();
            browser.WaitForPageToLoad();
            PageFactory.InitElements(browser.GetDriver, QuoteQuestionsPage);
        }
        public QuoteQuestionsPage QuoteQuestionsPage
        {
            get { return new QuoteQuestionsPage(_browser); }
        }
        public SchedulingPage SchedulingPage
        {
            get { return new SchedulingPage(_browser); }
        }
        public AccountsAndPaymentPage AccountsAndPaymentPage
        {
            get { return new AccountsAndPaymentPage(_browser); }
        }

    }
}
