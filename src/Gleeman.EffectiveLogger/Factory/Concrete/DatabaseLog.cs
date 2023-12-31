﻿namespace Gleeman.EffectiveLogger.Factory.Concrete;

internal class DatabaseLog : AbstractLog
{
    private readonly LogContext _logContext;
    public DatabaseLog(LogContext logContext)
    {
        _logContext = logContext;
    }

    public override void Write(LogLevelType logLevelType, string message)
    {
        _logContext.Logs.AddRange(new Model.Log
        {
            Date = DateTime.UtcNow.ToString(),
            Level = logLevelType.ToString(),
            Message = message
        });

        _logContext.SaveChanges();
    }
}
