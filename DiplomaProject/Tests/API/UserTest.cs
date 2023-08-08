namespace TestProject1.Tests.API;

public class UserTestApi : BaseApiTest
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    [Test(Description = "NFE GET api_test")]
    [Description("Get user using valid data")]
    [Category("API")]
    public void GetValidUserTest()
    {
        var actualUser = _userService.GetUser(1);
        _logger.Info("Actual User: " + actualUser.ToString());                        

        Console.WriteLine("Username: " + actualUser.Username);
        Console.WriteLine("Email: " + actualUser.Email);

        Assert.Multiple(() =>
        {
            Assert.That(actualUser.Id, Is.EqualTo(1));
            Assert.That(actualUser.Username, Is.EqualTo("Ilya Yarash"));
        });
    }                
}