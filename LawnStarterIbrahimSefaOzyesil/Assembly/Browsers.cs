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
        private readonly string baseURL = Config.BaseUrl;
        private readonly string browser = Config.Browser;
        private readonly int defaultTimeout = Config.DefaultTimeout;
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
        public IWebDriver GetDriver => webDriver;

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
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(defaultTimeout));
            wait.Until(ExpectedConditions.ElementIsVisible(identifier));
            return webDriver.FindElement(identifier);
        }
        public IWebDriver WaitForPageToLoad()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(defaultTimeout));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            return webDriver;
        }
        public IWebElement WaitUntilVisible(By locator, int timeoutSeconds = 0)
        {
            if (timeoutSeconds == 0)
                timeoutSeconds = defaultTimeout;
            var wait = new WebDriverWait(GetDriver, TimeSpan.FromSeconds(timeoutSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
