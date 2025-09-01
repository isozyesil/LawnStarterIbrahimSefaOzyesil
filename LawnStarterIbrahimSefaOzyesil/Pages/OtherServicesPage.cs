using LawnStarterIbrahimSefaOzyesil.Assembly;
using OpenQA.Selenium;


namespace LawnStarterIbrahimSefaOzyesil.Pages
{
    public class OtherSeervicesPage
    {
        private Browsers browsers;
        public OtherSeervicesPage(Browsers browsers)
        {
            this.browsers = browsers;
        }
        private IWebElement getNoThanksButton => browsers.WaitUntilVisible(By.CssSelector("button[data-testid='no-thanks-btn']"));       
        public void ClickOnNoThanksButton()
        {
            getNoThanksButton.Click();
        }
    }
}