namespace TestProject1.Pages;

public class TestCasesPage : BasePage
{
    private readonly TextField Title = new("input.form-control-inline");
    
    private readonly UIElement CaseTitle = new(By.XPath("//span[@class='title']"));

    private readonly Button AddTestCaseLink = new("a.link[onclick*='App.Cases.add']");
    private readonly Button AddTestCaseButton = new(By.Id("sidebar-cases-add"));
    private readonly Button Submit = new(By.ClassName("icon-button-accept"));
    private readonly Button Reference = new(By.ClassName("referenceLink"));
    private readonly Button DeleteTestCaseButton = new("a#deleteCases");
    private readonly Button DeletePermanentlyFirst = new(".dialog-action-secondary.button-black");
    private readonly Button DeletePermanentlySecond = new(".dialog-action-default.button-black");
    //private readonly Button AddSubsectionButton = new("a.link[onclick*='App.Sections.add']");
    private readonly Button AddSectionSideBarButton = new(By.Id("addSection"));
    
    private readonly Window SubjectDialogueWindow = new(".ui-dialog.dialog");
    private readonly Window PushDefectDialogueWindow = new(By.Id("pushDefectDialog"));
    private readonly Window JiraPopup = new(By.ClassName("attributes"));
    
    private string EndPoint = "index.php?/suites/view/1";

    public TestCasesPage(IWebDriver driver, Actions actions, WaitService wait) : base(driver,actions, wait) { }
    public TestCasesPage(IWebDriver driver, WaitService wait) : base(driver, wait)
    {
    }

    public override TestCasesPage OpenPage()
    {
        LoggerHelper.LogEventAll("Test cases and suits page opening");
        Browser.Instance.GoToTestRailUrl(EndPoint);
        IsPageOpened();
        return new TestCasesPage(Driver, Wait);
    }
    
    public override TestCasesPage RefreshPage()
    {
        LoggerHelper.LogEventAll("Test cases and suits page refreshing");
        Driver.Navigate().Refresh();
        IsPageOpened();
        return new TestCasesPage(Driver, Wait);
    }

    public override bool IsPageOpened()
    {
        LoggerHelper.LogEventAll("Test cases and suits page is opened");
        Wait.GetVisibleElement(By.Id("inlineSectionActions-1"));
        return true;
    }

    private void ClickAddCaseLink()
    {
        LoggerHelper.LogEventAll("'Add Test Case' link button is clicked");
        Wait.GetVisibleElement(By.CssSelector("a.link[onclick*='App.Cases.add']"));
        AddTestCaseLink.Click();
    }
    
    private void NameTheTestCase(string name)
    {
        LoggerHelper.LogEventAll("Send text to the Test Case title field");
        Wait.GetVisibleElement(By.CssSelector(".form-control-inline.title"));
        Title.Write(name);
    }

    private void ClickSubmitButton()
    {
        LoggerHelper.LogEventAll("Submit button is clicked");
        Wait.GetVisibleElement(By.ClassName("icon-button-accept"));
        Submit.Click();
    }

    public void CreateTestCaseByTitle(string name)
    {
        LoggerHelper.LogEventAll("Test Case creation with Title only");
        ClickAddCaseLink();
        NameTheTestCase(name);
        ClickSubmitButton();
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    public string GetLastTestCaseTitle()
    {
        LoggerHelper.LogEventAll("Getting the last Test Case ID");
        return CaseTitle.GetLastElementText();
    }

    public void HoverToReference()
    {
        LoggerHelper.LogEventAll("Hover to reference of the Test Case");
        Reference.Hover();
        Wait.GetVisibleElement(By.ClassName("integration-bubble-body-container"));
        Thread.Sleep(TimeSpan.FromSeconds(1));
    }

    public bool JiraPopupIsDisplayed()
    {
        LoggerHelper.LogEventAll("Jira pop-up is displayed");
        return JiraPopup.IsDisplayed();
    }

    private IWebElement FindTestCaseById(int id)
    {
        LoggerHelper.LogEventAll("Finding the TestCase by ID");
        return Driver.FindElement(By.XPath($"//input[@value='{id}' and @type='checkbox']"));
    }

    public TestCasesPage DeleteTestCaseById(int id)
    {
        FindTestCaseById(id).Click();
        
        DeleteTestCaseButton.Click();
        DeletePermanentlyFirst.Click();
        Thread.Sleep(TimeSpan.FromSeconds(2));
        DeletePermanentlySecond.Click();
        return new TestCasesPage(Driver, Wait);
    }

    public bool DeletedTestCaseIsDisplayed(int id)
    {
        LoggerHelper.LogEventAll("Deleting Test Case by ID");
        try
        {
            return FindTestCaseById(id).Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void AddSubsection()
    {
        LoggerHelper.LogEventAll("'Add Subsection' button is clicked");
        AddSectionSideBarButton.Click();
    }

    public bool DialogWindowIsDisplayed()
    {
        LoggerHelper.LogEventAll("'Add Subsection' dialogue window is displayed");
        return SubjectDialogueWindow.IsDisplayed();
    }

    public AddTestCasePage OpenAddTestCasePage()
    {
        LoggerHelper.LogEventAll("AddTestCase page is opened");
        AddTestCaseButton.Click();
        Wait.GetVisibleElement(By.Id("entityAttachmentListEmptyIcon"));
        return new AddTestCasePage(Driver, Wait);
    }
    
    public bool OpenPushDefectWindow()
    {
        LoggerHelper.LogEventAll("'Open Push Defect' dialogue window is displayed");
        try
        {
            return PushDefectDialogueWindow.IsDisplayed();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return false;
        }
    }
    
    public void TapPageHotKey(string key)
    {
        LoggerHelper.LogEventAll("Hotkey tapped");
        Browser.Instance.TapTheKey("s");
    }
}