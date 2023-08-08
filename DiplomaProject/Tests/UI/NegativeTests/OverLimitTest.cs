namespace TestProject1.Tests.UI.NegativeTests;

[TestFixture]
public class OverLimitTest : BaseTest
{
    [Test, Order(3), Category("Negative cases"),
     Description("Test case to check that user can not enter >250 characters to the 'Search' field")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureOwner("Admin")]
    [AllureSuite("Negative Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("25")]
    [AllureTag("Regression")]
    [TestCase(270)]

    public void CheckMaxLengthSearchField(int charAmount)
    {
        LoginPage.LogIn(UserAdmin)
            .OpenPage()
            .SendTextToSearchField(charAmount);
        
        Assert.That(DashboardPage.ErrorDialogWindowIsDisplayed(), Is.True, "The Error dialog window is not displayed!");
    }
}