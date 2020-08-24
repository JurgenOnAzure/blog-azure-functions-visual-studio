using AzureFunctionsBlogLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AzureFunctionsBlogApp
{
  public static class OnGetLogHttpTrigger
  {
    [FunctionName("OnGetLogHttpTrigger")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log,
        ExecutionContext executionContext)
    {
      log.LogInformation("C# HTTP trigger function processed a request.");

      var logContent = LogUtility.GetLogFileContent(
        logFileDirectoryName: executionContext.FunctionAppDirectory);

      return new OkObjectResult(logContent);
    }
  }
}
