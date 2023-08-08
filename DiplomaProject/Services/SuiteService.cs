using TestProject1.Models;

namespace TestProject1.Services;

public class SuiteService : BaseService
{
    private static readonly string GET_SUIT = "index.php?/api/v2/get_suite/{suite_id}";
    private static readonly string ADD_SUIT = "index.php?/api/v2/add_suite/{project_id}";
    private static readonly string UPDATE_SUIT = "index.php?/api/v2/update_suite/{suite_id}";
    
    public SuiteService(ApiClient apiClient) : base(apiClient) { }
    
    public Suite AddSuit(Suite suite, int projectId)
    {
        var request = new RestRequest(ADD_SUIT, Method.Post)
            .AddHeader("Content-Type", "application/json")
            .AddUrlSegment("project_id", projectId)
            .AddBody(suite);

        return _apiClient.Execute<Suite>(request);
    }
    
    public Suite UpdateSuit(Suite suite)
    {
        var request = new RestRequest(UPDATE_SUIT, Method.Post)
            .AddHeader("Content-Type", "application/json")
            .AddUrlSegment("suite_id", suite.Id)
            .AddBody(suite);

        return _apiClient.Execute<Suite>(request);
    }
    
    public Suite GetSuit(int suiteId)
    {
        var request = new RestRequest(GET_SUIT)
            .AddUrlSegment("suite_id", suiteId);

        return _apiClient.Execute<Suite>(request);
    }
    
    public async Task<RestResponse> GetSuitAsync(int projectId)
    {
        var request = new RestRequest(GET_SUIT)
            .AddUrlSegment("project_id", projectId);

        return await _apiClient.ExecuteAsync(request);
    }
}