namespace Gleeman.EffectiveLogger.Helpers;

public class Logging : ILogging
{
    private readonly ILogEvent _logEvent;
    private readonly ILogFactory _logFactory;
    public Logging(ILogEvent logEvent, ILogFactory logFactory)
    {
        _logEvent = logEvent;
        _logFactory = logFactory;
    }

    public void LogWrite(LogLevelType levelType, string message)
    {
        LogOptions logOptions = ServiceConfiguration.LogOptions;

        if(logOptions.WriteToConsole)
        {
            var writeConsole = _logFactory.CreateLog(LogType.ConsoleLog);
            _logEvent.LogHandler((s, e) => writeConsole.Write(levelType, e), $"{levelType.ToString()}: {message}");
        }
      

        if (logOptions.WriteToFile == true && !string.IsNullOrEmpty(logOptions.FilePath))
        {
            var writeFile = _logFactory.CreateLog(LogType.FileLog);
            _logEvent.LogHandler((s, e) => writeFile.Write(logOptions.FilePath, logOptions.FileName, e), $"{levelType.ToString()}: {message}");
        }

        if (!string.IsNullOrEmpty(logOptions.ConnectionString))
        {
            var writeDatabase = _logFactory.CreateLog(LogType.DatabaseLog);
            _logEvent.LogHandler((s, e) => writeDatabase.Write(levelType, e), $"{levelType.ToString()}: {message}");
        }
    }
}
