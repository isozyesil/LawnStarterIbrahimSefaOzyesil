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
        private IWebElement fullNameTextbox => browsers.WaitUntilVisible(By.Id("firstName"));
        private IWebElement lastNameTextbox => browsers.FindAndGetFirstElement(By.Id("lastName"));
        private IWebElement emailAddressTextbox => browsers.FindAndGetFirstElement(By.Id("email"));
        private IWebElement cardNumberIframeTextbox => browsers.WaitUntilVisible(By.CssSelector("iframe[title='Secure card number input frame']"));
        private IWebElement expiryIframeTextbox => browsers.WaitUntilVisible(By.CssSelector("iframe[title='Secure expiration date input frame']"));
        private IWebElement cardCVCIframeTextbox => browsers.WaitUntilVisible(By.CssSelector("iframe[title='Secure CVC input frame']"));
        private IWebElement bookNowButton => browsers.FindAndGetFirstElement(By.CssSelector("[data-testid='button-text']"));
        private IWebElement agreementCheckBox => browsers.FindAndGetFirstElement(By.CssSelector("div[data-testid='checkbox-0']"));
        public void SetFullNAme(string fullName)
        {
            fullNameTextbox.SendKeys(fullName);
        }
        public void SetLastName(string lastName)
        {
            lastNameTextbox.SendKeys(lastName);
        }
        public void SetEmaillAddress(string emailaddress)
        {
            emailAddressTextbox.SendKeys(emailaddress);
        }
        public void SetCardNumber(string cardNumber)
        {
            TypeInIframe(cardNumberIframeTextbox, cardNumber, "input[name='cardnumber']");
        }
        public void SetExpiry(string expiry)
        {
            TypeInIframe(expiryIframeTextbox, expiry, "input[name='exp-date']");
        }
        public void SetCVV(string cvv)
        {
            TypeInIframe(cardCVCIframeTextbox, cvv, "input[name='cvc']");
        }
        public void ClickOnAgreementCheckBox()
        {
            agreementCheckBox.Click();
        }
        public void ClickOnBookNowButton()
        {
            bookNowButton.Click();
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