namespace TestProject1.BaseEntities;

public class BaseService
{
    protected ApiClient _apiClient;

    protected BaseService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }
}