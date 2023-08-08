namespace TestProject1.Tests.UI.PositiveTests;

[TestFixture]
public class FileLoadedTest : BaseTest
{
    [Test, Category("Positive cases"), 
     Description("Test case to check that the screenshot is loaded to TestCase")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Admin")]
    [AllureSuite("Positive Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("24")]
    [AllureTag("Regression")]
    [TestCase("ImageTest.PNG")]

    public void CheckThatFileIsLoaded(string fileName)
    {
        LoginPage.LogIn(UserAdmin);

        TestCasesPage
            .OpenPage()
            .OpenAddTestCasePage()
            .LoadFile(fileName);
        
        Assert.That(AddTestCasePage.BigFileIconIsDisplayed(), 
            Is.False, "File is not uploaded to the TestCase attachments");
    }
}