namespace Gleeman.EffectiveLogger;


public class LogOptions
{
    public bool WriteToFile { get; set; } = false;
    public bool WriteToConsole { get; set; } = false;
    public string FilePath { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string ConnectionString { get; set; }
    public Assembly MigrationAssembly { get; set; }
}

