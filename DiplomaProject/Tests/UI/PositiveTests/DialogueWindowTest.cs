namespace TestProject1.Tests.UI.PositiveTests;

[TestFixture]
public class DialogueWindowTest : BaseTest
{
    [Test, Category("Positive cases"), 
     Description("Test case to check that 'Subject' Dialogue Window is opened")]
    [AllureSeverity(SeverityLevel.trivial)]
    [AllureOwner("Admin")]
    [AllureSuite("Positive Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("38")]
    [AllureTag("Regression")]

    public void CheckThatDialogueWindowIsOpened()
    {
        LoginPage.LogIn(UserAdmin);

        TestCasesPage.OpenPage()
            .AddSubsection();
        
        Assert.That(TestCasesPage.DialogWindowIsDisplayed(), Is.True, "Dialogue Window is not presented on the Page!");
    }
}