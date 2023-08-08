namespace TestProject1.Utilities.Helpers;

public static class FakerData
{
    private static Faker Faker = new Faker("en");

    public static string GenerateRandomString(int charactersAmount)
    {
        return Faker.Random.String2(charactersAmount, "qwertyuiopasdfzxcgjbn");
    }

    public static string GenerateRandomEmail()
    {
        return Faker.Internet.Email();
    }
    
    public static string GenerateRandomPassword()
    {
        return Faker.Internet.Password();
    }
}