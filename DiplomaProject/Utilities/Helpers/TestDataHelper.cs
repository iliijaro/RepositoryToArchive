using TestProject1.Models;

namespace TestProject1.Utilities.Helpers;

public static class TestDataHelper
{
    public static Milestone AddTestMilestone(string FileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + FileName);
        var jsonObject = JObject.Parse(json);

        var milestone = new Milestone()
        {
            Name = (string)jsonObject["name"],
            Description = (string?)jsonObject["description"]
        };

        return milestone;
    }

    public static Suite AddTestSuite(string FileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                    + Path.DirectorySeparatorChar + FileName);
        var jsonObject = JObject.Parse(json);

        var suite = new Suite
        {
            Id = (int)jsonObject["id"],
            Description = (string)jsonObject["project_id"],
            Name = (string)jsonObject["name"]
        };

        return suite;
    }
}