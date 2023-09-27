namespace Gleeman.EffectiveLogger.Configuration;

public static class ServiceConfiguration
{
    public static LogOptions LogOptions;

    static ServiceConfiguration()
    {
        LogOptions = new LogOptions();
        LogOptions.DatabaseOptions = new DatabaseOptions();
    }
    public static IServiceCollection AddEffectiveLogger(this IServiceCollection services, Action<LogOptions>logOptions)
    {
        logOptions.Invoke(LogOptions);
        services.AddTransient<ILogEvent, LogEvent>();
        services.AddTransient<ILogFactory, LogFactory>();
        services.AddTransient<ILogging, Logging>();
        services.AddTransient(typeof(IEffectiveLog<>),typeof(EffectiveLog<>));
        return services;
    }
}