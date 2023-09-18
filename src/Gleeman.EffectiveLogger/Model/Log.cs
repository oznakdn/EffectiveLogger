namespace Gleeman.EffectiveLogger.Model;

public class Log
{
    public Guid LogId { get; set; }
    public string LogLevel { get; set; }
    public DateTime LogDate { get; set; }
    public string Message { get; set; }
}
