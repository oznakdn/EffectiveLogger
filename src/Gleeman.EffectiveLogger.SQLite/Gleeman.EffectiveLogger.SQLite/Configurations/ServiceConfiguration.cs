using Gleeman.EffectiveLogger.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Gleeman.EffectiveLogger.Configuration;

namespace Gleeman.EffectiveLogger.SQLite.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddSQLiteLog(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {

        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        string connectionString = configuration.GetValue<string>("LogOptions:DatabaseOptions:SQLiteConnectionString")!;
        services.AddDbContext<LogContext>(option => option.UseSqlite(connectionString, x => x.MigrationsAssembly(assembly.FullName)));
        services.AddEffentiveLogger(configuration);
        return services;
    }
}
