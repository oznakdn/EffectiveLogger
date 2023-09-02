namespace Gleeman.EffectiveLogger.Configuration;

public static class ServiceConfigurationExtension
{
    public static IServiceCollection AddEffectiveLogger(this IServiceCollection services, IConfiguration configuration, ProviderType? providerType, string? migrationProject)
    {
        services.Configure<LogOption>(configuration.GetSection(nameof(LogOption)));
        string connectionString = configuration.GetValue<string>("LogOption:ConnectionString")!;
        if (providerType != null)
        {
            services.AddDbContext<LogDbContext>(option =>
            {
                switch (providerType)
                {
                    case ProviderType.SQLite:
                        option.UseSqlite(connectionString,
                            x => x.MigrationsAssembly(nameof(migrationProject))); break;
                    case ProviderType.MsSQL:
                        option.UseSqlServer(connectionString,
                            x => x.MigrationsAssembly(nameof(migrationProject))); break;
                    case ProviderType.PostgreSQL:
                        option.UseNpgsql(connectionString,
                            x => x.MigrationsAssembly(nameof(migrationProject))); break;
                    case ProviderType.MySQL:
                        option.UseMySql(ServerVersion.AutoDetect(connectionString), 
                            x => x.MigrationsAssembly(nameof(migrationProject))); break;
                }
            });
        }

        services.AddTransient(typeof(IEffectiveLogger<>), typeof(EffectiveLogger<>));

        return services;
    }
}
