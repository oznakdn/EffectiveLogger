namespace Gleeman.EffectiveLogger.Event;

public class LogHandler
{
    public void LogHandle(EventHandler<LogEventArgs> handle, LogEventArgs eventArgs) => handle?.Invoke(this,eventArgs);

}
