namespace TestProject1.Models;

public static class MilestoneBuilder
{
    public static Milestone CreateRandomMilestone => new Milestone()
    {
        Name = FakerData.GenerateRandomString(10),
        Reference = FakerData.GenerateRandomString(7),
        Description = FakerData.GenerateRandomString(23),
    };
    
    public static Milestone CreateMilestoneWithNameOnly(string name) => new Milestone()
    {
        Name = name,
        Reference = "",
        Description = "",
    };
    
    public static Milestone CreateMilestone(string name, string reference, string description) => new Milestone()
    {
        Name = name,
        Reference = reference,
        Description = description,
    };
}