namespace TestProject1.Pages;

public class DashboardPage : BasePage
{
    private TextField Search = new(By.Id("search_query"));

    private Button AddProjectButton = new(By.ClassName("sidebar-button"));
    
    private Window ErrorWindow = new(By.Id("ui-dialog-title-messageDialog"));
    
    private string EndPoint = "index.php?/dashboard";

    public DashboardPage(IWebDriver driver,  WaitService wait) : base(driver, wait) { }
    
    public override DashboardPage OpenPage()
    {
        LoggerHelper.LogEventAll("Dashboard page opening");
        Browser.Instance.GoToTestRailUrl(EndPoint);
        IsPageOpened();
        return new DashboardPage(Driver, Wait);
    }
    
    public override DashboardPage RefreshPage()
    {
        LoggerHelper.LogEventAll("Dashboard page refreshing");
        Driver.Navigate().Refresh();
        IsPageOpened();
        return new DashboardPage(Driver, Wait);
    }
    
    public override bool IsPageOpened()
    {
        LoggerHelper.LogEventAll("Dashboard page is opened");
        Wait.GetVisibleElement(By.ClassName("sidebar-button"));
        return true;
    }

    public void SendTextToSearchField(int amount)
    {
        LoggerHelper.LogEventAll("Sending text to the search field");
        Search.Write(FakerData.GenerateRandomString(amount));
        Wait.GetVisibleElement(By.CssSelector("#dialog-ident-messageDialog"));
    }

    public bool ErrorDialogWindowIsDisplayed()
    {
        LoggerHelper.LogEventAll("Error Window is displayed");
        try
        {
            return ErrorWindow.IsDisplayed();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message,exception.Data,exception.StackTrace);
            return false;
        }
    }
}