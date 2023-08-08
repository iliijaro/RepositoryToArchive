namespace TestProject1.Tests.UI.PositiveTests;

[TestFixture]
public class TestCaseDeleteTest : BaseTest
{
    [Test, Category("Positive cases"), 
     Description("Test case to check that the TestCase is deleted")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Admin")] 
    [AllureSuite("Positive Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("28")]
    [AllureTag("Regression")]

    [TestCase(49)]
    public void CheckThatTestCaseIsDeleted(int id)
    {
        LoginPage.LogIn(UserAdmin);

        TestCasesPage.OpenPage()
            .DeleteTestCaseById(id)
            .RefreshPage();
        
        Assert.That(TestCasesPage.DeletedTestCaseIsDisplayed(id), 
            Is.False, "Test Case is still displayed in Suit and not deleted!");
    }
}