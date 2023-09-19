namespace Gleeman.EffectiveLogger.MySQL.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddMySqlLog(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {

        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        string connectionString = configuration.GetValue<string>("LogOptions:DatabaseOptions:MySqlConnectionString")!;
        services.AddDbContext<LogContext>(option => option.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString), x => x.MigrationsAssembly(assembly.FullName)));
        services.AddEffectiveLogger(configuration);
        return services;
    }
}
