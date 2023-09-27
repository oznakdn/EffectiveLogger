namespace Gleeman.EffectiveLogger.MySQL.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddMySqlLog(this IServiceCollection services, Action<DatabaseOptions> options)
    {

        DatabaseOptions databaseOptions = new();
        options.Invoke(databaseOptions);

        LogOptions logOptions = Gleeman.EffectiveLogger.Configuration.ServiceConfiguration.LogOptions;

        logOptions.WriteToDatabase = true;
        logOptions.DatabaseOptions!.MySqlConnectionString = databaseOptions.ConnectionString;

        services.AddEffectiveLogger(option => option = logOptions);

        services.AddDbContext<LogContext>(option => option.UseMySql(logOptions.DatabaseOptions.MySqlConnectionString, 
            ServerVersion.AutoDetect(databaseOptions.ConnectionString),
            x => x.MigrationsAssembly(databaseOptions.Assembly.FullName)));

        return services;
    }
}
