using TestProject1.Models;

namespace TestProject1.BaseEntities;

[TestFixture]
[AllureNUnit]
public class BaseTest
{
    private IWebDriver Driver { get; set; } = Browser.Instance.Driver;
    private Actions Actions { get; set; }
    private WaitService Wait { get; set; }

    private AllureLifecycle _allure;
    protected LoginPage LoginPage { get; set; }
    protected MilestonesPage MilestonesPage { get; set; }
    protected TestCasesPage TestCasesPage { get; set; }
    protected AddTestCasePage AddTestCasePage { get; set; }
    protected DashboardPage DashboardPage { get; set; }
    protected User UserAdmin { get; set; }
    

    [SetUp]
    public void Setup()
    {
        UserAdmin = new UserBuilder()
            .SetAdminUser()
            .Build();
        
        LoggerHelper.LogEventAll("Automation Test starts");
        LoggerHelper.LogEventAll("Driver, Actions, Wait and Allure init");
        Driver = Browser.Instance.Driver;
        Actions = new Actions(Driver);
        Wait = new WaitService(Driver);
        _allure = AllureLifecycle.Instance;
        
        LoggerHelper.LogEventAll("Pages initialization");
        LoginPage = new LoginPage(Driver, Wait);
        DashboardPage = new DashboardPage(Driver, Wait);
        AddTestCasePage = new AddTestCasePage(Driver, Wait);
        MilestonesPage = new MilestonesPage(Driver, Wait);
        TestCasesPage = new TestCasesPage(Driver,Actions, Wait);
        
        LoggerHelper.LogEventAll("Opening the TestRail Login page");
        Browser.Instance.GoToTestRailHome();
    }
    
    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            LoggerHelper.LogEventAll("Test Failed : Screenshot done");
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var screenshotBytes = screenshot.AsByteArray;
            _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
        }
        
        LoggerHelper.LogEventAll("Browser closed");
        Browser.Instance.CloseBrowser();
    }
}