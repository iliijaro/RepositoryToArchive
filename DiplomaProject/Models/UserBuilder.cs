namespace TestProject1.Models;

public class UserBuilder
{
    private User user;

    public UserBuilder()
    {
        user = new User();
    }

    public UserBuilder SetRandomUsername()
    {
        user.Username = FakerData.GenerateRandomEmail();
        return this;
    }

    public UserBuilder SetRandomPassword()
    {
        user.Password = FakerData.GenerateRandomPassword();
        return this;
    }

    public UserBuilder SetUsername(string username)
    {
        user.Username = username;
        return this;
    }

    public UserBuilder SetPassword(string password)
    {
        user.Password = password;
        return this;
    }

    public UserBuilder SetEmail(string email)
    {
        user.Email = email;
        return this;
    }

    public UserBuilder SetAdminUser()
    {
        user.Username = Configurator.Admin.Username;
        user.Password = Configurator.Admin.Password;
        return this;
    }

    public User Build()
    {
        return user;
    }
}
