namespace Gleeman.EffectiveLogger.Context;

public class LogModel
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string LogLevel { get; set; }
    public string Message { get; set; }
}
