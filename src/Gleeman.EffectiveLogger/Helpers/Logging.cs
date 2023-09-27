﻿using Gleeman.EffectiveLogger.Configuration;

namespace Gleeman.EffectiveLogger.Helpers;

public class Logging : ILogging
{
    private readonly ILogEvent _logEvent;
    private readonly ILogFactory _logFactory;
    public Logging(IOptions<LogOptions> logOptions, ILogEvent logEvent, ILogFactory logFactory)
    {
        _logEvent = logEvent;
        _logFactory = logFactory;
    }

    public void LogWrite(LogLevelType levelType, string message)
    {
        LogOptions logOptions = ServiceConfiguration.LogOptions;
        var writeConsole = _logFactory.CreateLog(LogType.ConsoleLog);
        _logEvent.LogHandler((s, e) => writeConsole.Write(levelType, e), $"{levelType.ToString()}: {message}");

        if (logOptions.WriteToFile != null && logOptions.WriteToFile == true)
        {
            var writeFile = _logFactory.CreateLog(LogType.FileLog);
            _logEvent.LogHandler((s, e) => writeFile.Write(logOptions.FilePath, logOptions.FileName, e), $"{levelType.ToString()}: {message}");
        }

        if (logOptions.WriteToDatabase != null && logOptions.WriteToDatabase == true && (
            !string.IsNullOrEmpty(logOptions.DatabaseOptions.SQLiteConnectionString) ||
            !string.IsNullOrEmpty(logOptions.DatabaseOptions.MSSqlServerConectionString) ||
            !string.IsNullOrEmpty(logOptions.DatabaseOptions.PostgreSqlConnectionString) ||
            !string.IsNullOrEmpty(logOptions.DatabaseOptions.MySqlConnectionString)))
        {
            var writeDatabase = _logFactory.CreateLog(LogType.DatabaseLog);
            _logEvent.LogHandler((s, e) => writeDatabase.Write(levelType, e), $"{levelType.ToString()}: {message}");
        }
    }
}
