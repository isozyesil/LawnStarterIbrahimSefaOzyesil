using LawnStarterIbrahimSefaOzyesil.Assembly;

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
        }
        [TearDown]
        public void EndTest()
        {
            Browser.Close();
        }
    }
}
