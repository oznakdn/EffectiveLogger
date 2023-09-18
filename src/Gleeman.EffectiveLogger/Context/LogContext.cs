namespace Gleeman.EffectiveLogger.Context;

public class LogContext : DbContext
{
    private readonly LogOptions _logOptions;
    public LogContext(DbContextOptions<LogContext> options, IOptions<LogOptions> logOption) : base(options)
    {
        _logOptions = logOption.Value;


        if (_logOptions.WriteToDatabase == true)
        {
            if (!string.IsNullOrEmpty(_logOptions.DatabaseOptions.SQLiteConnectionString) ||
                !string.IsNullOrEmpty(_logOptions.DatabaseOptions.MSSqlServerConectionString) ||
                !string.IsNullOrEmpty(_logOptions.DatabaseOptions.PostgreSqlConnectionString) ||
                !string.IsNullOrEmpty(_logOptions.DatabaseOptions.MySqlConnectionString))
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
