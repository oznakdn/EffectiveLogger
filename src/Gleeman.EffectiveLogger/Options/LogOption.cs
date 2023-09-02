namespace Gleeman.EffectiveLogger.Options;

public class LogOption
{
    public bool WriteToConsole { get; set; }
    public bool WriteToFile { get; set; }
    public bool WriteToDatabase { get; set; }
    public string FilePath { get; set; }
    public string FileName { get; set; }
    public string ConnectionString { get; set; }

}
