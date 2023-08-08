namespace TestProject1.Tests.API;

public class MilestoneTest : BaseApiTest
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [Test]
    public void AddMilestoneTest()
    {
        var expectedMilestone = TestDataHelper.AddTestMilestone("MilestoneTestData.json");

        _logger.Info("Expected Milestone: " + expectedMilestone);

        var actualMilestone = _milestoneService.AddAsMilestone(expectedMilestone, 1);
        _logger.Info("Actual Milestone: " + actualMilestone.ToString());

        Console.WriteLine($"Milestone Id: {actualMilestone.Id}");

        Assert.That(actualMilestone.Name, Is.EqualTo(expectedMilestone.Name));
    }

    [Test]
    public void GetInvalidMilestoneTest()
    {
        var actualMilestone = _milestoneService.GetMilestoneAsync(0);
        _logger.Info("Actual Milestone: " + actualMilestone.ToString());                        

        Assert.That(actualMilestone.Result.StatusCode.ToString(), Is.EqualTo(HttpStatusCode.BadRequest.ToString()));
    }
}