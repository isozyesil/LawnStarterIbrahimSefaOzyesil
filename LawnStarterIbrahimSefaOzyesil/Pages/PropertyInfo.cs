using LawnStarterIbrahimSefaOzyesil.Assembly;
using OpenQA.Selenium;

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