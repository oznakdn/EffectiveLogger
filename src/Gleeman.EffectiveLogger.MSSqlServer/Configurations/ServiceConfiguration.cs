namespace Gleeman.EffectiveLogger.MSSqlServer.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddMSSqlServerLog(this IServiceCollection services, Action<DatabaseOptions> options)
    {


        DatabaseOptions databaseOptions = new();
        options.Invoke(databaseOptions);

        LogOptions logOptions = Gleeman.EffectiveLogger.Configuration.ServiceConfiguration.LogOptions;

        logOptions.WriteToDatabase = true;
        logOptions.DatabaseOptions.MSSqlServerConectionString = databaseOptions.ConnectionString;

        services.AddEffectiveLogger(option => option = logOptions);

        services.AddDbContext<LogContext>(option => option.UseSqlServer(logOptions.DatabaseOptions.MSSqlServerConectionString, 
            x => x.MigrationsAssembly(databaseOptions.Assembly.FullName)));
        return services;
    }
}
