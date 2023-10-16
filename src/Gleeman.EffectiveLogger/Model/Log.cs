namespace Gleeman.EffectiveLogger.Model;

public class Log
{
    public Guid Id { get; set; }
    public string Level { get; set; }
    public string Date { get; set; }
    public string Message { get; set; }
}
