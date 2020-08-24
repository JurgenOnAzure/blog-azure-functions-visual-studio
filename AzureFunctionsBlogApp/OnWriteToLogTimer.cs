using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using AzureFunctionsBlogLib;

namespace AzureFunctionsBlogApp
{
  public static class OnWriteToLogTimer
  {
    [FunctionName("OnWriteToLogTimer")]
    public static void Run(
      [TimerTrigger("%OnWriteToLogTimerSchedule%")] TimerInfo myTimer, 
      ILogger log,
      ExecutionContext executionContext)
    {
      log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

      LogUtility.AppendToLogFile(
        logFileDirectoryName: executionContext.FunctionAppDirectory,
        functionName: executionContext.FunctionName);
    }
  }
}
