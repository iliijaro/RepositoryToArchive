using TestProject1.Models;

namespace TestProject1.Utilities.Helpers;

public static class LoggerHelper
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    static LoggerHelper()
    {
        _logger = LogManager.GetCurrentClassLogger();
    }
    
    public static void LogEventAll(string logMessage)
    {
        _logger.Trace(logMessage);
        _logger.Debug(logMessage);
        _logger.Error(logMessage);
        _logger.Warn(logMessage);
        _logger.Info(logMessage);
        _logger.Fatal(logMessage); 
    }
    
    public static void LogEventFromWarning(string logMessage)
    {
        _logger.Warn(logMessage);
        _logger.Error(logMessage);
        _logger.Fatal(logMessage); 
    }

    public static void LogAPIRequestInfo(RestRequest request)
    {
        _logger.Info("Request: " + request.Resource);
    }

    public static void LogAPIResponseStatusInfo(RestResponse response)
    {
        _logger.Info("Response Status: " + response.ResponseStatus);
    }
    
    public static void LogAPIResponseBodyContext(RestResponse response)
    {
        _logger.Info("Response Body: " + response.Content);
    }

    public static void LogAPIExpectedSuite(Suite suite)
    {
        _logger.Info("Expected Suite: " + suite);
    }
    
    public static void LogAPIActualSuite(Task<RestResponse> suite)
    {
        _logger.Info("Actual Suite: " + suite.ToString());
    }
    
    public static void LogAPIActualSuite(Suite suite)
    {
        _logger.Info("Actual Suite: " + suite.ToString());
    }
}