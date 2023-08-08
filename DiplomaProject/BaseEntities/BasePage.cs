namespace TestProject1.BaseEntities;

public abstract class BasePage
{
    protected Actions actions = null!;
    protected IWebDriver Driver { get; set; }
    protected WaitService Wait { get; set; }
    public abstract BasePage OpenPage();
    public abstract bool IsPageOpened();
    public abstract BasePage RefreshPage();
    
    protected BasePage(IWebDriver driver, Actions actions, WaitService wait)
    {
        Driver = driver;
        Wait = wait;
        this.actions = actions;
    }
    
    protected BasePage(IWebDriver driver, WaitService wait)
    {
        Driver = driver;
        Wait = wait;

    }
}