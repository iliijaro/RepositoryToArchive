namespace TestProject1.Tests.UI.PositiveTests;

[TestFixture]
public class BoundaryValuesTest : BaseTest
{
    [Retry(2)]
    [Test, Category("Positive cases"), Description("Test Case title boundary values")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureOwner("Admin")]
    [AllureSuite("Positive Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("41")]
    [AllureTag("Regression")]
    [TestCase(1)]
    [TestCase(249)]
    [TestCase(250)]
    public void TitleBoundaryValues(int n)
    {
        var expectedText = FakerData.GenerateRandomString(n);
        
        LoginPage.LogIn(UserAdmin);

        TestCasesPage.OpenPage()  
            .CreateTestCaseByTitle(expectedText);
        
        Assert.That(TestCasesPage.GetLastTestCaseTitle(), Is.EqualTo(expectedText), "The amount of characters are not equal");
    }
}