using LawnStarterIbrahimSefaOzyesil.Assembly;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnStarterIbrahimSefaOzyesil.Pages
{
    public class SchedulingPage
    {
        private Browsers browsers;

        public SchedulingPage(Browsers browsers)
        {
            this.browsers = browsers;
        }
        private IWebElement GetTrimmingPlan(string planName) => browsers.WaitUntilVisible(By.XPath($"//button[.//div[@data-testid='undefined-col' and normalize-space(text())='{planName}']]"));
        private IWebElement ContinueButton => browsers.FindAndGetFirstElement(By.XPath("//button[.//div[@data-testid='button-text' and normalize-space(text())='Continue']]"));

        public void SelectTrimmingPlan(string planName)
        {
            GetTrimmingPlan(planName).Click();
        }

        public void ClickOnContinueButton()
        {
            ContinueButton.Click();
        }
        
    }
}