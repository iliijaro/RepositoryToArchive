using TestProject1.Models;

namespace TestProject1.Services;

public class UserService : BaseService
{
    private static readonly string ADD_USER = "index.php?/api/v2/add_user";
    private static readonly string GET_USER = "index.php?/api/v2/get_user/{user_id}";

    public UserService(ApiClient apiClient) : base(apiClient) { }

    public User AddUser(User user)
    {
        var request = new RestRequest(ADD_USER, Method.Post)
            .AddHeader("Content-Type", "application/json")
            .AddBody(user);

        return _apiClient.Execute<User>(request);
    }
                
    public User GetUser(int userId)
    {
        var request = new RestRequest(GET_USER)
            .AddUrlSegment("user_id", userId);

        return _apiClient.Execute<User>(request);
    }

    public async Task<RestResponse> GetUserAsync(int userId)
    {
        var request = new RestRequest(GET_USER)
            .AddUrlSegment("project_id", userId);

        return await _apiClient.ExecuteAsync(request);
    }
}