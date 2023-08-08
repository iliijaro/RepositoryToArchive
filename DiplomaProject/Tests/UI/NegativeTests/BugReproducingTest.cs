namespace TestProject1.Tests.UI.NegativeTests;

[TestFixture]
public class BugReproducingTest : BaseTest
{
    [Test, Category("Negative cases"),
     Description("Test case to reproduce the bug with wrong expected window to display")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureOwner("Admin")]
    [AllureSuite("Negative Cases Suit")]
    [AllureSubSuite("GUI")] 
    [AllureIssue("KAN-2")]
    [AllureTms("22")]
    [AllureTag("Regression")]

    public void ReproduceBugWithWrongWindow()
    {
        LoginPage.LogIn(UserAdmin);
        
        TestCasesPage.OpenPage()
            .TapPageHotKey("s");
        
        Assert.That(TestCasesPage.OpenPushDefectWindow(), Is.True, "'Push Defect Window' is not opened! Something went wrong!");
    }
}