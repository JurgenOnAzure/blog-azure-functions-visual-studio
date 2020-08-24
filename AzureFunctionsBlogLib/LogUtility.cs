using System;
using System.IO;

namespace AzureFunctionsBlogLib
{
  public static class LogUtility
  {
    private const string logFileName = "log.txt";

    public static void AppendToLogFile(string logFileDirectoryName, string functionName)
    {
      if (string.IsNullOrEmpty(logFileDirectoryName))
      {
        throw new ArgumentNullException(nameof(logFileDirectoryName));
      }

      if (string.IsNullOrEmpty(functionName))
      {
        throw new ArgumentNullException(nameof(functionName));
      }

      var fullLogFileName = Path.Combine(logFileDirectoryName, logFileName);

      File.AppendAllText(
        fullLogFileName,
        $"Function {functionName} was called @ {DateTime.Now}{Environment.NewLine}");
    }

    public static string GetLogFileContent(string logFileDirectoryName)
    {
      if (string.IsNullOrEmpty(logFileDirectoryName))
      {
        throw new ArgumentNullException(nameof(logFileDirectoryName));
      }

      var fullLogFileName = Path.Combine(logFileDirectoryName, logFileName);

      var content = File.Exists(fullLogFileName)
        ? File.ReadAllText(fullLogFileName)
        : "(no content yet)";

      return content;
    }
  }
}
