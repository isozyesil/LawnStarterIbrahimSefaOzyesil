using LawnStarterIbrahimSefaOzyesil.Assembly;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace LawnStarterIbrahimSefaOzyesil.Paages
{
    public class QuoteQuestionsPage
    {
        private Browsers browsers;
        public QuoteQuestionsPage(Browsers browsers)
        {
            this.browsers = browsers;
        }
        private IWebElement lessThan5ftShrubDropdown => browsers.FindAndGetFirstElement(By.Id("react-select-2-input"));
        private IWebElement shrubBetween5ftAnd10ftOptionByNumber => browsers.FindAndGetFirstElement(By.Id("react-select-3-input"));
        private IWebElement shrubsAndHedgesMoreThan10ft => browsers.FindAndGetFirstElement(By.Id("react-select-4-input"));
        private IWebElement quoteButton => browsers.FindAndGetFirstElement(By.CssSelector("[data-testid='get-my-quote-btn']"));
        private IWebElement PropertyByID(string testId) => browsers.WaitUntilVisible(By.CssSelector($"[data-testid='{testId}']"));
        private IWebElement ShrubLessThan5ftOptionByNumber(string optionNo) => browsers.FindAndGetFirstElement(By.Id($"react-select-2-option-{optionNo}"));
        private IWebElement ShrubBetween5ftAnd10ftOptionByNumber(string optionNo) => browsers.FindAndGetFirstElement(By.Id($"react-select-3-option-{optionNo}"));
        private IWebElement ShrubsAndHedgesMoreThan10ft(string optionNo) => browsers.FindAndGetFirstElement(By.Id($"react-select-4-option-{optionNo}"));
        public void SelectProperyType(params string[] propertyTypes)
        {
            foreach (var type in propertyTypes)
            {
                string testId = propertyTypeMap[type];
                var checkbox = PropertyByID(testId);
                checkbox.Click();
            }
        }
        public void SelectLessThan5ftShrubs(string numberOfShrubs)
        {
            ClickToLessThan5ftShrubsDropdown();
            var option = ShrubLessThan5ftOptionByNumber(numberOfShrubs);
            option.Click();
        }
        public void SelectBetween5ftAnd10ftShrubs(string numberOfShrubs)
        {
            ClickToBetween5ftAnd10ftShrubsDropdown();
            var option = ShrubBetween5ftAnd10ftOptionByNumber(numberOfShrubs);
            option.Click();
        }
        public void SelectShrubsAndHedgesMoreThan10ft(string numberOfShrubs)
        {
            ClickShrubsAndHedgesMoreThan10ft();
            var option = ShrubsAndHedgesMoreThan10ft(numberOfShrubs);
            option.Click();
        }
        public void ClickOnGetMyQuoteButton()
        {
            quoteButton.Click();
        }
        private void ClickToLessThan5ftShrubsDropdown()
        {
            lessThan5ftShrubDropdown.Click();
        }
        private void ClickToBetween5ftAnd10ftShrubsDropdown()
        {
            shrubBetween5ftAnd10ftOptionByNumber.Click();
        }
        private void ClickShrubsAndHedgesMoreThan10ft()
        {
            shrubsAndHedgesMoreThan10ft.Click();
        }
        private readonly Dictionary<string, string> propertyTypeMap = new Dictionary<string, string>
        {
             { "Full Yard", "checkbox-0" },
             { "Front-yard", "checkbox-1" },
             { "Backyard", "checkbox-2" },
             { "Left side", "checkbox-3" },
             { "Right side", "checkbox-4" },
        };
    }
}