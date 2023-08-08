using TestProject1.Models;

namespace TestProject1.Pages;

public class LoginPage : BasePage
{
    private TextField UserName = new (By.Id("name"));
    private TextField Password = new (By.Id("password"));
    
    private Button LoginButton = new (By.Id("button_primary"));
    private Button KeepMeCheckbox = new(".loginpage-checkmark");
    
    private Window ErrorMessage = new(By.ClassName("error-alert"));
    
    private string EndPoint = "index.php?/auth/login/";


    public LoginPage(IWebDriver driver,  WaitService wait) : base(driver, wait) { }
    
    public override LoginPage OpenPage()
    {
        LoggerHelper.LogEventAll("Login Page opening");
        Browser.Instance.GoToTestRailUrl(EndPoint);
        IsPageOpened();
        return new LoginPage(Driver, Wait);
    }
    
    public override LoginPage RefreshPage()
    {
        LoggerHelper.LogEventAll("Login Page refreshing");
        Driver.Navigate().Refresh();
        IsPageOpened();
        return new LoginPage(Driver, Wait);
    }
    
    public override bool IsPageOpened()
    {
        LoggerHelper.LogEventAll("Login Page is opened");
        Wait.GetVisibleElement(By.ClassName("loginpage-forgotpassword"));
        return true;
    }

    private LoginPage SetUserName(string name)
    {
        LoggerHelper.LogEventAll("Username is set");
        UserName.Write(name);
        return this;
    }
    
    public LoginPage SetRandomEmail()
    {
        LoggerHelper.LogEventAll("Random Email is set");
        UserName.Write(FakerData.GenerateRandomEmail());
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        LoggerHelper.LogEventAll("Password is set");
        Password.Write(password);
        return this;
    }

    public LoginPage SetRandomPassword()
    {
        LoggerHelper.LogEventAll("Random Password is set");
        Password.Write(FakerData.GenerateRandomPassword());
        return this;
    }

    private void ClickLoginButton()
    {
        LoggerHelper.LogEventAll("Click Login Button");
        LoginButton.Click();
    }

    public void ClickKeepLoggedCheckbox()
    {
        KeepMeCheckbox.Click();
    }

    public DashboardPage LogIn(User user)
    {
        SetUserName(user.Username)
            .SetPassword(user.Password)
            .ClickLoginButton();

        return new DashboardPage(Driver, Wait);
    }

    public bool ErrorMessageIsDisplayed()
    {
        LoggerHelper.LogEventAll("Login Error Message is displayed");
        return ErrorMessage.IsDisplayed();
    }

    public bool LoginButtonIsDisplayed()
    {
        return LoginButton.IsDisplayed();
    }
}