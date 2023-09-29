namespace Gleeman.EffectiveLogger.SQLite.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddSQLiteLog(this IServiceCollection services, Action<LogOptions> options)
    {

        var logOptions = Configuration.ServiceConfiguration.LogOptions;
        options.Invoke(logOptions);

        Configuration.ServiceConfiguration.AddLoggerService(services, option => option = logOptions);

        services.AddDbContext<LogContext>(option => option.UseSqlite(logOptions.ConnectionString,
       x => x.MigrationsAssembly(logOptions.MigrationAssembly!.FullName)));


        return services;
    }
}