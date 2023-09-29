namespace Gleeman.EffectiveLogger.MySQL.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddMySqlLog(this IServiceCollection services, Action<LogOptions> options)
    {
        var logOptions = Configuration.ServiceConfiguration.LogOptions;
        options.Invoke(logOptions);
        Configuration.ServiceConfiguration.AddLoggerService(services, option => option = logOptions);
        services.AddLoggerService(option => option = logOptions);
        services.AddDbContext<LogContext>(option => option.UseMySql(logOptions.ConnectionString, 
            ServerVersion.AutoDetect(logOptions.ConnectionString),
            x => x.MigrationsAssembly(logOptions.MigrationAssembly.FullName)));

        return services;
    }
}
