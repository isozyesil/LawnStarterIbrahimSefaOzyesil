using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LawnStarterIbrahimSefaOzyesil.Assembly
{
    public class Browsers
    {
        protected IWebDriver webDriver;
        private string baseURL = "https://dev-signup-web.lawnstarter.com/cart/contact-info/?address=1016%20Kirk%20Street%2C%20Orlando%2C%20FL%2032808%2C%20Orlando%2C%20FL%2032808&name=Jay+Doe&phone=999-999-9999&intent=bushTrimming&googlePlace=true";
        private string browser = "Chrome";
        private IWebElement element;
        public Browsers()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "Edge":
                    webDriver = new EdgeDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
        }
        public void LawnStarterQuoteCreation()
        {
            Goto(baseURL);
        }
        public IWebDriver GetDriver
        {
            get { return webDriver; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
        }
        public void Close()
        {
            webDriver.Quit();
        }
        public IWebElement FindAndGetFirstElement(By identifier)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(identifier));
            return webDriver.FindElement(identifier);
        }
        public IWebDriver WaitForPageToLoad()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            return webDriver;
        }
    }
}


