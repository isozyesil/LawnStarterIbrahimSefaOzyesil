using LawnStarterIbrahimSefaOzyesil.Assembly;
using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnStarterIbrahimSefaOzyesil.Pages
{    public class PropertyInfoPage
    {
        private Browsers browsers;
        public PropertyInfoPage(Browsers browsers)
        {
            this.browsers = browsers;
        }
        private IWebElement propertyInfoPage => browsers.WaitUntilVisible(By.Id("app"));
        public void VerifyThatPropertyPageIsLoaded()
        {
           Assert.IsTrue(propertyInfoPage.Displayed, "Property Info page is not loaded.");   
        }
    }
}