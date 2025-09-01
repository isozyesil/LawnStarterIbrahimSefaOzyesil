using LawnStarterIbrahimSefaOzyesil.Assembly;
using OpenQA.Selenium;
using Selenium.WebDriver.WaitExtensions;

namespace LawnStarterIbrahimSefaOzyesil.Pages
{
    public class SchedulingPage
    {
        public SchedulingPage(Browsers browsers)
        {
            this.browsers = browsers;
        }
        private Browsers browsers;
        private IWebElement GetPlanOption(string planName) => browsers.WaitUntilVisible(By.XPath($"//button//div[contains(normalize-space(),'{planName}')]"));
        private IWebElement GetTrimmingPlan(string planName) => browsers.WaitUntilVisible(By.XPath($"//button[.//div[@data-testid='undefined-col' and normalize-space(text())='{planName}']]"));
        private IWebElement ContinueButton => browsers.FindAndGetFirstElement(By.XPath("//button[.//div[@data-testid='button-text' and normalize-space(text())='Continue']]"));
        private IWebElement PreferredDateInput => browsers.WaitUntilVisible(By.CssSelector("input[placeholder='EEEE, MMMM DD, YYYY']"));
        private IWebElement CalendarHeader => browsers.WaitUntilVisible(By.CssSelector("div.MuiPickersCalendarHeader-label"));
        private IWebElement NextMonthButton => browsers.WaitUntilVisible(By.CssSelector("button[title='Next month']"));
        private IWebElement GetDayCell(int day) => browsers.WaitUntilVisible(By.XPath($"//button[@role='gridcell' and normalize-space()='{day}']"));
        public void SelectTrimmingPlan(string planName)
        {
            var plan = GetPlanOption(planName);
            plan.Click();
        }

        public void ClickOnContinueButton()
        {
            ContinueButton.Click();
        }
        public void SetPreferredDate(DateTime targetDate)
        {
            OpenCalendar(); 

            string expectedMonthYear = targetDate.ToString("MMMM yyyy");          

            while (!CalendarHeader.Text.Trim().Contains(expectedMonthYear, StringComparison.OrdinalIgnoreCase))
            {
                NextMonthButton.Click();
            }

            SelectDay(targetDate.Day);
        }
        private void OpenCalendar()
        {
            PreferredDateInput.Click();
        }
        private void SelectDay(int day)
        {
            var cell = GetDayCell(day);
           
            cell.Click();
        }
    }
}