namespace Gleeman.EffectiveLogger.Helpers;

public class Logging : ILogging
{
    private readonly LogOptions _logOptions;
    private readonly ILogEvent _logEvent;
    private readonly ILogFactory _logFactory;
    public Logging(IOptions<LogOptions> logOptions, ILogEvent logEvent, ILogFactory logFactory)
    {
        _logOptions = logOptions.Value;
        _logEvent = logEvent;
        _logFactory = logFactory;
    }

    public void LogWrite(LogLevelType levelType, string message)
    {
        var writeConsole = _logFactory.CreateLog(LogType.ConsoleLog);
        _logEvent.LogHandler((s, e) => writeConsole.Write(levelType, e), $"{levelType.ToString()}: {message}");

        if (_logOptions.WriteToFile != null && _logOptions.WriteToFile == true)
        {
            var writeFile = _logFactory.CreateLog(LogType.FileLog);
            _logEvent.LogHandler((s, e) => writeFile.Write(_logOptions.FilePath, _logOptions.FileName, e), $"{levelType.ToString()}: {message}");
        }

        if (_logOptions.WriteToDatabase != null && _logOptions.WriteToDatabase == true && (!string.IsNullOrEmpty(_logOptions.DatabaseOptions.SQLiteConnectionString) ||
            !string.IsNullOrEmpty(_logOptions.DatabaseOptions.MSSqlConectionString) ||
            !string.IsNullOrEmpty(_logOptions.DatabaseOptions.PostgreSqlConnectionString) ||
            !string.IsNullOrEmpty(_logOptions.DatabaseOptions.MySqlConnectionString)))
        {
            var writeDatabase = _logFactory.CreateLog(LogType.DatabaseLog);
            _logEvent.LogHandler((s, e) => writeDatabase.Write(levelType, e), $"{levelType.ToString()}: {message}");
        }
    }
}
