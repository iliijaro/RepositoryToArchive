namespace TestProject1.Tests.UI.PositiveTests;

[TestFixture]
public class JiraPopUpDisplayedTest : BaseTest
{
    [Test, Category("Positive cases"), Description("Test case to check the Jira pop-up")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureOwner("Admin")]
    [AllureSuite("Positive Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("18")]
    [AllureTag("Regression")]

    public void JiraPopupShows()
    {
        LoginPage.LogIn(UserAdmin);

        TestCasesPage.OpenPage()
            .HoverToReference();
        
        Assert.That(TestCasesPage.JiraPopupIsDisplayed(), Is.True, "Pop-up is not displayed on the screen.");
    }
}