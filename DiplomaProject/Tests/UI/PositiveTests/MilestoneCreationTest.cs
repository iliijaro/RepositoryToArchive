using TestProject1.Models;

namespace TestProject1.Tests.UI.PositiveTests;

[TestFixture]
public class MilestoneCreationTest : BaseTest
{
    [Test, Category("Positive cases"), 
     Description("Test case to check that the new Milestone is created")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Admin")]
    [AllureSuite("Positive Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("11")]
    [AllureTag("Smoke")]

    public void NewMilestoneCreation()
    {
        LoginPage.LogIn(UserAdmin);
        
        MilestonesPage.OpenPage()
            .CreateRandomMilestone(MilestoneBuilder.CreateRandomMilestone);
        
        Assert.That(MilestonesPage.SuccessMessageIsDisplayed(),
            Is.True, "The message about successful creation is not displayed");
    }
}