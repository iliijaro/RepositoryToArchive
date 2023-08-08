namespace TestProject1.BaseEntities;

public class BaseApiTest
{
    private ApiClient _apiClient;
    protected SuiteService _suiteService;
    protected UserService _userService;
    protected MilestoneService _milestoneService;

    [OneTimeSetUp]
    public void InitApiClient()
    {
        _apiClient = new ApiClient();
        _suiteService = new SuiteService(_apiClient);
        _userService = new UserService(_apiClient);
        _milestoneService = new MilestoneService(_apiClient);
    }
}