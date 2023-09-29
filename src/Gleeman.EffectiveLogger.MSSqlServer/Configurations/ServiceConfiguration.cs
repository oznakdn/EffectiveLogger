namespace Gleeman.EffectiveLogger.MSSqlServer.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddMSSqlServerLog(this IServiceCollection services, Action<LogOptions> options)
    {

        var logOptions = Configuration.ServiceConfiguration.LogOptions;
        options.Invoke(logOptions);
        Configuration.ServiceConfiguration.AddLoggerService(services, option => option = logOptions);

        services.AddLoggerService(option => option = logOptions);

        services.AddDbContext<LogContext>(option => option.UseSqlServer(logOptions.ConnectionString, 
            x => x.MigrationsAssembly(logOptions.MigrationAssembly.FullName)));
        return services;
    }
}
