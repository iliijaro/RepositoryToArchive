using TestProject1.Models;

namespace TestProject1.Tests.UI.NegativeTests;

[TestFixture]
public class InvalidCredentialsTest : BaseTest
{
    [Test,Order(2), Category("Negative cases"),
     Description("Test case to check that user can not log in with invalid credentials")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Random User")]
    [AllureSuite("Negative Cases Suit")]
    [AllureSubSuite("GUI")]
    [AllureTms("23")]
    [AllureTag("Smoke")]


    public void CheckInvalidCredentials()
    {
        var user = new UserBuilder()
                .SetRandomUsername()
                .SetRandomPassword()
                .Build();
        
        LoginPage.OpenPage()
                .LogIn(user);
            
        Assert.Multiple(() =>
        {
            Assert.That(LoginPage.ErrorMessageIsDisplayed(), Is.True, "Error message is not displayed!");
            Assert.That(LoginPage.LoginButtonIsDisplayed(),Is.True, "Login button is not presented on this page!");
        });
    }
}
