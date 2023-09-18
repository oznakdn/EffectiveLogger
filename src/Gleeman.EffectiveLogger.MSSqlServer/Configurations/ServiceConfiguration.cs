namespace Gleeman.EffectiveLogger.MSSqlServer.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddMSSqlServerLog(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {

        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        string connectionString = configuration.GetValue<string>("LogOptions:DatabaseOptions:MSSqlConectionString")!;
        services.AddDbContext<LogContext>(option => option.UseSqlServer(connectionString, x => x.MigrationsAssembly(assembly.FullName)));
        services.AddEffentiveLogger(configuration);
        return services;
    }
}
