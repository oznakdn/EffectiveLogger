namespace Gleeman.EffectiveLogger.Factory;

public class LogFactory : ILogFactory
{
    private AbstractLog instance { get; set; }
    private readonly LogContext _dbContext;

    public LogFactory(LogContext dbContext)
    {
        _dbContext = dbContext;
    }

    public AbstractLog CreateLog(LogType logType)
    {
        return instance = logType switch
        {
            LogType.ConsoleLog => instance = new ConsoleLog(),
            LogType.FileLog => instance = new FileLog(),
            LogType.DatabaseLog => instance = new DatabaseLog(_dbContext)
        };
    }
}
