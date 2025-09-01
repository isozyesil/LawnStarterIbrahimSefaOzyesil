using LawnStarterIbrahimSefaOzyesil.Assembly;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
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
        private IWebElement getCardNumberIframe => browsers.WaitUntilVisible(By.CssSelector("iframe[title='Secure card number input frame']"));
        private IWebElement getExpiryIframe => browsers.WaitUntilVisible(By.CssSelector("iframe[title='Secure expiration date input frame']"));
        private IWebElement getCVCIframe => browsers.WaitUntilVisible(By.CssSelector("iframe[title='Secure CVC input frame']"));
        private IWebElement getBookNow => browsers.FindAndGetFirstElement(By.CssSelector("[data-testid='button-text']"));
        private IWebElement getAgreementCheckBox => browsers.FindAndGetFirstElement(By.CssSelector("div[data-testid='checkbox-0']"));
        public void SetFullNAme(string fullName)
        {
            getFullName.SendKeys(fullName);
        }
        public void SetLastName(string lastName)
        {
            getLastName.SendKeys(lastName);
        }
        public void SetEmaillAddress(string emailaddress)
        {
            getEmailAddress.SendKeys(emailaddress);
        }
        public void SetCardNumber(string cardNumber)
        {
            TypeInIframe(getCardNumberIframe, cardNumber, "input[name='cardnumber']");
        }
        public void SetExpiry(string expiry)
        {
            TypeInIframe(getExpiryIframe, expiry, "input[name='exp-date']");
        }
        public void SetCVV(string cvv)
        {
            TypeInIframe(getCVCIframe, cvv, "input[name='cvc']");
        }
        public void ClickOnAgreementCheckBox()
        {
            getAgreementCheckBox.Click();
        }
        public void ClickOnBookNowButton()
        {
            getBookNow.Click();
        }
        private void TypeInIframe(IWebElement iframe, string value, string inputSelector)
        {            
            browsers.GetDriver.SwitchTo().Frame(iframe);           
            var input = browsers.WaitUntilVisible(By.CssSelector(inputSelector));
            input.SendKeys(value);
            browsers.GetDriver.SwitchTo().DefaultContent();
        }
    }
}