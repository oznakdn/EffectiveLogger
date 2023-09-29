namespace Gleeman.EffectiveLogger.Configuration;

public static class ServiceConfiguration
{
    public static LogOptions LogOptions;

    static ServiceConfiguration()
    {
        LogOptions = new LogOptions();
    }
    public static IServiceCollection AddLoggerService(this IServiceCollection services, Action<LogOptions>logOptions)
    {
        logOptions.Invoke(LogOptions);
        services.AddTransient<ILogEvent, LogEvent>();
        services.AddTransient<ILogFactory, LogFactory>();
        services.AddTransient<ILogging, Logging>();
        services.AddTransient(typeof(IEffectiveLog<>),typeof(EffectiveLog<>));
        return services;
    }
}