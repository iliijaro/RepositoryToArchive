namespace TestProject1.Tests.UI.SmokeTests;

[TestFixture]
public class SuccessfulLoginTest : BaseTest
{
    [Test, Order(1), Category("Smoke test"), 
     Description("Test case to check that user can successfully log in ")]
    [AllureSeverity(SeverityLevel.blocker)]
    [AllureSuite("Negative Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("23")]
    [AllureTag("Smoke")]
    public void SuccessfulLogIn()
    {
        LoginPage.LogIn(UserAdmin);
        
        Assert.That(DashboardPage.IsPageOpened(), Is.True, 
            "Dashboard Page is not opened, something went wrong during the Log In!");
    }
}