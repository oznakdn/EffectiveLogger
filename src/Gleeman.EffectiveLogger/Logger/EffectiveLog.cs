namespace Gleeman.EffectiveLogger.Logger;

public class EffectiveLog<T> : IEffectiveLog<T> where T : class
{

    private readonly ILogging _logging;
    public EffectiveLog(ILogging logging)
    {
        _logging = logging;
    }

    public void Debug(string message)
    {
        _logging.LogWrite(LogLevelType.dbug, message);
    }

    public void Fail(string message)
    {
        _logging.LogWrite(LogLevelType.fail, message);

    }

    public void Information(string message)
    {
        _logging.LogWrite(LogLevelType.info, message);

    }

    public void Warning(string message)
    {
        _logging.LogWrite(LogLevelType.warn, message);
    }
}