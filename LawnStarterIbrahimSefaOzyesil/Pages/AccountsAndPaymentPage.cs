using LawnStarterIbrahimSefaOzyesil.Assembly;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LawnStarterIbrahimSefaOzyesil.Pages
{
    public class AccountsAndPaymentPage
    {
        private Browsers browsers;

        public AccountsAndPaymentPage(Browsers browsers)
        {
            this.browsers = browsers;
        }
        private IWebElement getFullName => browsers.WaitUntilVisible(By.Id("firstName"));
        private IWebElement getLastName => browsers.FindAndGetFirstElement(By.Id("lastName"));
        private IWebElement getEmailAddress => browsers.FindAndGetFirstElement(By.Id("email"));
        private IWebElement CardNumberIframe => browsers.FindAndGetFirstElement(By.CssSelector("div#card-number iframe"));
        private IWebElement ExpiryIframe => browsers.FindAndGetFirstElement(By.CssSelector("div#card-expiry iframe"));
        private IWebElement CvcIframe => browsers.FindAndGetFirstElement(By.CssSelector("div#card-cvc iframe"));
        private IWebElement getBookNow => browsers.FindAndGetFirstElement(By.CssSelector("[data-testid='button-text']"));
        private IWebElement getAgreementCheckBox => browsers.FindAndGetFirstElement(By.Id("checkbox-0"));

        public void SetFullNAme(string fullName)
        {
            getFullName.SendKeys(fullName);

        }
        public void setLastName(string lastName)
        {
            getLastName.SendKeys(lastName);

        }
        public void setEmaillAddress(string emailaddress)
        {
            getEmailAddress.SendKeys(emailaddress);

        }
        public void SetCardNumber(string cardNumber)
        {
            TypeInIframe(CardNumberIframe, cardNumber);

        }
        public void SetExpiryDate(string expiryDate)
        {

            TypeInIframe(ExpiryIframe, expiryDate);
        }
        public void SetCVV(string cvv)
        {
            TypeInIframe(CvcIframe, cvv);

        }
        public void ClickOnAgreementCheckBox()
        {
            getAgreementCheckBox.Click();
        }
        public void ClickOnBookNowButton()
        {
            getBookNow.Click();
        }
        private void TypeInIframe(IWebElement iframe, string value)
        {
            browsers.GetDriver.SwitchTo().Frame(iframe);

            var input = browsers.GetDriver.FindElement(By.CssSelector("input"));
            input.SendKeys(value);

            browsers.GetDriver.SwitchTo().DefaultContent();
        }
    }
}