using Gleeman.EffectiveLogger.Configuration;

namespace Gleeman.EffectiveLogger.Context;

public class LogContext : DbContext
{
    
    public LogContext(DbContextOptions<LogContext> options) : base(options)
    {

        LogOptions logOptions = ServiceConfiguration.LogOptions;
        if (logOptions.WriteToDatabase == true)
        {
            if (!string.IsNullOrEmpty(logOptions.DatabaseOptions!.SQLiteConnectionString) ||
                !string.IsNullOrEmpty(logOptions.DatabaseOptions.MSSqlServerConectionString) ||
                !string.IsNullOrEmpty(logOptions.DatabaseOptions.PostgreSqlConnectionString) ||
                !string.IsNullOrEmpty(logOptions.DatabaseOptions.MySqlConnectionString))
            {
                Database.EnsureCreated();
            }
            else
            {
                throw new ArgumentException("Connection string is null or empty!");
            }
        }
       
    }

    public DbSet<Log> Logs { get; set; }

}
