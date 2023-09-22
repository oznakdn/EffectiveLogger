namespace Gleeman.EffectiveLogger.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection AddEffectiveLogger(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LogOptions>(configuration.GetSection(nameof(LogOptions)));
        services.AddTransient<ILogEvent, LogEvent>();
        services.AddTransient<ILogFactory, LogFactory>();
        services.AddTransient<ILogging, Logging>();
        services.AddTransient(typeof(IEffectiveLog<>),typeof(EffectiveLog<>));
        return services;
    }
}