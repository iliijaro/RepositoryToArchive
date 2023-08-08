namespace TestProject1.BaseEntities;

public class BaseElement
{
    private Browser Browser => Browser.Instance;
    private WaitService Wait { get; set; }
    private Actions Actions { get; set; }
    
    private By Locator { get; set; }

    public BaseElement(By locator)
    {
        Locator = locator;
    }

    public BaseElement(string locator)
    {
        Locator = By.CssSelector(locator);
    }
    
    public void Write(string message)
    {
        Browser.Driver.FindElement(Locator).SendKeys(message); 
    }

    public bool IsDisplayed()
    {
      return  Browser.Driver.FindElement(Locator).Displayed;
    }

    public void Click()
    {
        Browser.Driver.FindElement(Locator).Click(); 
    }

    public string GetLastElementText()
    {
       return Browser.Driver.FindElements(Locator).Last().Text;
    }

    public void Hover()
    {
        Actions = new Actions(Browser.Driver);
        var hyperlinkElement = Browser.Driver.FindElement(Locator);
        Actions.MoveToElement(hyperlinkElement).Perform();
    }
}
