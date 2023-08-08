using TestProject1.Models;

namespace TestProject1.Services;

public class MilestoneService : BaseService
{        
    private static readonly string ADD_MILESTONE = "index.php?/api/v2/add_milestone/{project_id}";
    private static readonly string GET_MILESTONE = "index.php?/api/v2/get_milestone/{milestone_id}";
    
    public MilestoneService(ApiClient apiClient) : base(apiClient) { }
    
    public Milestone AddAsMilestone(Milestone someMilestone, int projectId)
    {
        var request = new RestRequest(ADD_MILESTONE, Method.Post)
            .AddUrlSegment("project_id", projectId)
            .AddHeader("Content-Type", "application/json")
            .AddBody(someMilestone);

        return _apiClient.Execute<Milestone>(request);
    }               

    public Milestone GetMilestone(int milestone_id)
    {
        var request = new RestRequest(GET_MILESTONE)
            .AddUrlSegment("milestone_id", milestone_id);

        return _apiClient.Execute<Milestone>(request);
    }

    public async Task<RestResponse> GetMilestoneAsync(int milestoneId)
    {
        var request = new RestRequest(GET_MILESTONE)
            .AddUrlSegment("milestone_id", milestoneId);

        return await _apiClient.ExecuteAsync(request);
    }
}