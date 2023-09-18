namespace Gleeman.EffectiveLogger.Helpers;

public interface ILogging
{
    void LogWrite(LogLevelType levelType, string message);
}
