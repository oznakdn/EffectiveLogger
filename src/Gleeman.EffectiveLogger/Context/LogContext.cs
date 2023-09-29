namespace Gleeman.EffectiveLogger.Context;

public class LogContext : DbContext
{

    public LogContext(DbContextOptions<LogContext> options) : base(options)
    {

        LogOptions logOptions = ServiceConfiguration.LogOptions;
        if (!string.IsNullOrEmpty(logOptions.ConnectionString))
        {
            Database.EnsureCreated();
        }
        else
        {
            throw new ArgumentException("Connection string is null or empty!");
        }
    }

    public DbSet<Log> Logs { get; set; }

}
