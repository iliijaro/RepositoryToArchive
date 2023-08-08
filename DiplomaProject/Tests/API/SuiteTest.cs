namespace TestProject1.Tests.API;

public class SuiteTest : BaseApiTest
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [Test(Description = "NFE POST api_test")]
    [Description("Add Suit to Project using all required data")]
    [Category("API")]
    public void AddSuiteTest()
    {
        var expectedSuite = TestDataHelper.AddTestSuite("SuiteTestData.json");
        _logger.Info("Expected Suite: " + expectedSuite);

        var actualSuite = _suiteService.AddSuit(expectedSuite, 2);
        _logger.Info("Actual Suite: " + actualSuite.ToString());
        
        Console.WriteLine($"Suite Name: {actualSuite.Name}," +
                          $"Suite Description: {actualSuite.Description}, Suite Id: {actualSuite.Id}");

        Assert.Multiple(() =>
        {
            Assert.That(actualSuite.Name, Is.EqualTo(expectedSuite.Name));
            Assert.That(actualSuite.Description, Is.EqualTo(expectedSuite.Description));
        });
    }

    [Test(Description = "AFE GET api_test")]
    [Description("Get suite using incorrect data (Id)")]
    [Category("API")]
    public void GetInvalidSuitTest()
    {
        var actualSuite = _suiteService.GetSuitAsync(0);
        _logger.Info("Actual Suite: " + actualSuite.ToString());
        
        Assert.That(actualSuite.Result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}