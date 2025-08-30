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
        private IWebElement GetTrimmingPlanButton(string planName) => browsers.FindAndGetFirstElement(By.XPath($"//button[.//div[@data-testid='undefined-col' and contains(normalize-space(.), '{planName}')]]")
    );

        public void SelectTrimmingPlan(string planName)
        {
            var option = GetTrimmingPlanButton(planName);
            option.Click();

        }

    }
}