namespace Gleeman.EffectiveLogger.PostgreSQL.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddPostgreSqlLog(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {

        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        string connectionString = configuration.GetValue<string>("LogOptions:DatabaseOptions:PostgreSqlConnectionString")!;
        services.AddDbContext<LogContext>(option => option.UseNpgsql(connectionString, x => x.MigrationsAssembly(assembly.FullName)));
        services.AddEffectiveLogger(configuration);
        return services;
    }
}
