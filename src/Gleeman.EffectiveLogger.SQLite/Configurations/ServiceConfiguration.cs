namespace Gleeman.EffectiveLogger.SQLite.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddSQLiteLog(this IServiceCollection services, Action<DatabaseOptions> options)
    {

        DatabaseOptions databaseOptions = new();
        options.Invoke(databaseOptions);

        LogOptions logOptions = Gleeman.EffectiveLogger.Configuration.ServiceConfiguration.LogOptions;

        logOptions.WriteToDatabase = true;
        logOptions.DatabaseOptions!.SQLiteConnectionString = databaseOptions.ConnectionString;

        services.AddEffectiveLogger(option => option = logOptions);

        services.AddDbContext<LogContext>(option => option.UseSqlite(logOptions.DatabaseOptions.SQLiteConnectionString, 
            x => x.MigrationsAssembly(databaseOptions.Assembly.FullName)));
        return services;
    }
}