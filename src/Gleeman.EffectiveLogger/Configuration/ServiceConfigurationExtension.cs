namespace Gleeman.EffectiveLogger.Configuration;

public static class ServiceConfiguration
{
    public static IServiceCollection AddEffentiveLogger(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<LogOptions>(configuration.GetSection(nameof(LogOptions)));
        services.AddScoped<ILogEvent, LogEvent>();
        services.AddScoped<ILogFactory, LogFactory>();
        services.AddScoped<ILogging, Logging>();
        services.AddScoped(typeof(IEffectiveLog<>),typeof(EffectiveLog<>));
        return services;
    }
}