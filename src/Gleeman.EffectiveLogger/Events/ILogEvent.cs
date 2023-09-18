namespace Gleeman.EffectiveLogger.Events;

public interface ILogEvent
{
    public void LogHandler(EventHandler<string> handle, string message);
}
