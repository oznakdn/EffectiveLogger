namespace Gleeman.EffectiveLogger.Concretes;

public class EffectiveLogger<T> : IEffectiveLogger<T> where T : class
{
    private readonly LogOption _logOption;
    private readonly LogDbContext _dbContext;
    private LogHandler _logHandler;
    private LogHelper _logHelper;
    public EffectiveLogger(IOptions<LogOption> logOption, LogDbContext dbContext)
    {
        _dbContext = dbContext;
        _logOption = logOption.Value;
        _logHandler = new();
        _logHelper = new(_dbContext);
    }
    public void Debug(string message)
    {
        Write(LogLevelConsts.Debug, message);
    }

    public void Fail(string message)
    {
        Write(LogLevelConsts.Fail, message);
    }

    public void Information(string message)
    {
        Write(LogLevelConsts.Information, message);
    }

    public void Warning(string message)
    {
        Write(LogLevelConsts.Warning, message);
    }

    private void Write(string logLevel, string message)
    {
        if (_logOption.WriteToConsole)
        {
            _logHandler.LogHandle((s, e) => _logHelper.WriteToConsole(e.Date, e.LogLevel, e.Message), new LogEventArgs
            {
                Date = DateTime.Now,
                LogLevel = logLevel,
                Message = message
            });
        }

        if (_logOption.WriteToFile && !string.IsNullOrEmpty(_logOption.FilePath) && !string.IsNullOrEmpty(_logOption.FileName))
        {
            _logHandler.LogHandle((s, e) => _logHelper.WriteToFile(_logOption.FilePath, _logOption.FileName, e.Date, e.LogLevel, e.Message), new LogEventArgs
            {
                Date = DateTime.Now,
                LogLevel = logLevel,
                Message = message
            });
        }

        if (_logOption.WriteToDatabase && !string.IsNullOrEmpty(_logOption.ConnectionString))
        {
            _logHandler.LogHandle((s, e) => _logHelper.WriteToDatabase(e.Date, e.LogLevel, e.Message), new LogEventArgs
            {
                Date = DateTime.Now,
                LogLevel = logLevel,
                Message = message
            });
        }
    }

}

