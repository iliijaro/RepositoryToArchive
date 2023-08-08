namespace TestProject1.Core;

public class Browser
{
    private static Browser instance = null!;
    private IWebDriver driver;
    private Actions actions = null!;

    public static Browser Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Browser();
            }
            return instance;
        }
    }

    public IWebDriver Driver => driver;

    private Browser()
    {
        var options = new ChromeOptions();
        options.AddArguments("incognito");
        //options.AddArguments("--headless");
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        if(Driver != null) driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0); 
    }


    public void GoToUrl(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public void GoToTestRailHome()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }
    
    public void GoToTestRailUrl(string addUrl)
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL+ addUrl);
    }

    public string GetUrl()
    {
        return Driver.Url;
    }

    public void TapTheKey(string key)
    {
        actions = new Actions(Driver);
        actions.KeyDown(key).KeyUp(key).Perform();
    }

    public void CloseBrowser()
    {
        driver.Dispose();
        instance = null!;
    }
}
