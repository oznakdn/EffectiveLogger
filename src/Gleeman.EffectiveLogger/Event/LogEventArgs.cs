namespace Gleeman.EffectiveLogger.Event;

public class LogEventArgs : EventArgs
{
    public DateTime Date { get; set; }
    public string LogLevel { get; set; }
    public string Message { get; set; }

}
