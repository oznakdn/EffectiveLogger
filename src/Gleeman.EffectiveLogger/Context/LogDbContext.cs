namespace Gleeman.EffectiveLogger.Event;
public class LogDbContext : DbContext
{
    private readonly LogOption _logOption;
    public LogDbContext(DbContextOptions<LogDbContext> options, IOptions<LogOption> logOption) : base(options)
    {
        _logOption = logOption.Value;

        if (_logOption.WriteToDatabase && !string.IsNullOrEmpty(_logOption.ConnectionString))
        {
            Database.EnsureCreated();
        }
    }


    public DbSet<LogModel> Logs { get; set; }

}
