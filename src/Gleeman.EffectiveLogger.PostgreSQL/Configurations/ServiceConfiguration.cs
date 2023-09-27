namespace Gleeman.EffectiveLogger.PostgreSQL.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddPostgreSqlLog(this IServiceCollection services, Action<DatabaseOptions> options)
    {

        DatabaseOptions databaseOptions = new();
        options.Invoke(databaseOptions);

        LogOptions logOptions = Gleeman.EffectiveLogger.Configuration.ServiceConfiguration.LogOptions;

        logOptions.WriteToDatabase = true;
        logOptions.DatabaseOptions!.PostgreSqlConnectionString = databaseOptions.ConnectionString;

        services.AddEffectiveLogger(option => option = logOptions);

        services.AddDbContext<LogContext>(option => option.UseNpgsql(logOptions.DatabaseOptions.PostgreSqlConnectionString,
            x => x.MigrationsAssembly(databaseOptions.Assembly.FullName)));
        
        return services;
    }
}
