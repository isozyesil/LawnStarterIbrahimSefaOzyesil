using LawnStarterIbrahimSefaOzyesil.Assembly;
using OpenQA.Selenium;


namespace LawnStarterIbrahimSefaOzyesil
{
    public class TestBase
    {
        public Browsers Browser { get; set; }
        public Assembly.Pages Pages { get; set; }

        [SetUp]
        public void StartUpTest()
        {
            Browser = new Browsers();
            Pages = new Assembly.Pages(Browser);
            Logger.Info("Test Started");
        }
        [TearDown]
        public void EndTest()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;

            if (outcome == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Logger.Error($"Test {testName} FAILED");
                TakeScreenshot(testName);
            }
            else
            {
                Logger.Info($"Test {testName} PASSED");
            }

            Browser.Close();
        }
        private void TakeScreenshot(string testName)
        {
            try
            {
                {
                    ITakesScreenshot screenshotDriver = (ITakesScreenshot)Browser.GetDriver;
                    Screenshot screenshot = screenshotDriver.GetScreenshot();

                    string screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");

                    if (!Directory.Exists(screenshotsDir))
                        Directory.CreateDirectory(screenshotsDir);

                    string filePath = Path.Combine(
                        screenshotsDir,
                        $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png"
                    );
                    screenshot.SaveAsFile(filePath);

                    TestContext.AddTestAttachment(filePath, "Screenshot on failure");
                    Logger.Info($"Screenshot saved: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to capture screenshot: " + ex.Message);
            }
        }

    }
}
