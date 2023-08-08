namespace TestProject1.Pages;

public class AddTestCasePage : BasePage
{
    private Input LoadLocator = new("input[type=file]");
    
    private UIElement BigAddIcon = new(By.Id("entityAttachmentListEmptyIcon"));
    
    private TextField Title = new(By.XPath("//input[@name='title' and @id='title']"));
    private TextField Preconditions = new(By.XPath("//div[@id='custom_preconds_display']"));
    private TextField Steps = new(By.XPath("//div[@id='custom_steps_display']"));
    private TextField Expected = new(By.XPath("//div[@id='custom_expected_display']"));
    private TextField Reference = new(By.XPath("//input[@name='refs']"));
    
    private Button AddTestCase = new(By.XPath("//button[@id='accept']"));

    private string EndPoint = "index.php?/cases/add/1";

    public AddTestCasePage(IWebDriver driver,  WaitService wait) : base(driver, wait) { }
    
    public override AddTestCasePage OpenPage()
    {
        LoggerHelper.LogEventAll("'AddTestCase' page opening");
        Browser.Instance.GoToTestRailUrl(EndPoint);
        IsPageOpened();
        return new AddTestCasePage(Driver,Wait);
    }
    
    public override AddTestCasePage RefreshPage()
    {
        LoggerHelper.LogEventAll("'AddTestCase' page refreshing");
        Driver.Navigate().Refresh();
        IsPageOpened();
        return new AddTestCasePage(Driver,Wait);
    }
    
    public override bool IsPageOpened()
    {
        LoggerHelper.LogEventAll("'AddTestCase' page opened");
        Wait.GetVisibleElement(By.Id("entityAttachmentListEmptyIcon"));
        return true;
    }
    
    public AddTestCasePage LoadFile(string fileName)
    {
        LoggerHelper.LogEventAll("Loading file to TestCase");
        LoadLocator.Write(Configurator.LoadableContent.FilePath + fileName);
        Wait.GetVisibleElement(By.ClassName("attachment-list-add-icon"));
        return new AddTestCasePage(Driver,Wait);
    }

    private void SetTestCaseFields(int amount)
    {
        LoggerHelper.LogEventAll("Setting all fields to TestCase");
        var randomString = FakerData.GenerateRandomString(amount);
        
        Title.Write(randomString);
        Preconditions.Write(randomString);
        Steps.Write(randomString);
        Expected.Write(randomString);
        Reference.Write(randomString);
    }

    public void CreateRandomTestCase(string filePath, int amount)
    {
        SetTestCaseFields(amount);
        LoadFile(filePath);
    }

    public bool BigFileIconIsDisplayed()
    {
        LoggerHelper.LogEventAll("Checking the Big Icon is displayed on the sidebar");
        return BigAddIcon.IsDisplayed();
    }
}