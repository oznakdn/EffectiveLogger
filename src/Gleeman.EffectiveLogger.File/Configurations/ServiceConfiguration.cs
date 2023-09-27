using Microsoft.Extensions.DependencyInjection;
using Gleeman.EffectiveLogger.Configuration;
namespace Gleeman.EffectiveLogger.File.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddFileLog(this IServiceCollection services, Action<FileOptions> options)
    {


        FileOptions fileOptions = new();
        options.Invoke(fileOptions);

        LogOptions logOptions = Gleeman.EffectiveLogger.Configuration.ServiceConfiguration.LogOptions;

        logOptions.WriteToFile = true;
        logOptions.FilePath = fileOptions.FilePath;
        logOptions.FileName = fileOptions.FileName;

        services.AddEffectiveLogger(option => option = logOptions);

        return services;
    }
}
