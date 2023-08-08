using TestProject1.Models;

namespace TestProject1.Pages;

public class MilestonesPage : BasePage
{
    private TextField Name = new(By.Id("name"));
    private TextField Description = new(By.Id("description_display"));
    private TextField Reference = new(By.Id("reference"));
    
    private UIElement SuccessMessage = new(".message-success");

    private Button AddMilestoneButton = new(By.Id("navigation-milestones-add"));
    private Button CreateMilestoneButton = new(By.Id("accept"));
    
    private readonly string EndPoint = "index.php?/milestones/overview/1";

    public MilestonesPage(IWebDriver driver,  WaitService wait) : base(driver, wait) { }
    
    public override MilestonesPage OpenPage()
    {
        LoggerHelper.LogEventAll("Milestones Page opening");
        Browser.Instance.GoToTestRailUrl(EndPoint);
        IsPageOpened();
        return new MilestonesPage(Driver, Wait);
    }
    
    public override MilestonesPage RefreshPage()
    {
        LoggerHelper.LogEventAll("Milestones Page refreshing");
        Driver.Navigate().Refresh();
        IsPageOpened();
        return new MilestonesPage(Driver, Wait);
    }
    
    public override bool IsPageOpened()
    {
        LoggerHelper.LogEventAll("Milestones Page is opened");
        Wait.GetVisibleElement(By.Id("navigation-milestones-add"));
        return true;
    }

    public void ClickAddMilestoneButton()
    {
        LoggerHelper.LogEventAll("Add Milestone button is clicked");
        AddMilestoneButton.Click();
    }

    public void CreateRandomMilestone(Milestone milestone)
    {
        LoggerHelper.LogEventAll("Random Milestone creating");
        ClickAddMilestoneButton();
        Name.Write(milestone.Name);
        Description.Write(milestone.Description);
        Reference.Write(milestone.Reference);
        CreateMilestoneButton.Click();
        Wait.GetVisibleElement(By.CssSelector(".message-success"));
    }
    
    public void CreateMilestone(string name,string description)
    {
        LoggerHelper.LogEventAll("Milestone creating");
        ClickAddMilestoneButton();
        Name.Write(name);
        Description.Write(description);
        CreateMilestoneButton.Click();
        Wait.GetVisibleElement(By.CssSelector(".message-success"));
    }
    
    public bool SuccessMessageIsDisplayed()
    {
        LoggerHelper.LogEventAll("Milestone created successful message is displayed");
        return SuccessMessage.IsDisplayed();
    }
}