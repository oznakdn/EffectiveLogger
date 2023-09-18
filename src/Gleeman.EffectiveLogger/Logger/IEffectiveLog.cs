namespace Gleeman.EffectiveLogger.Logger;

public interface IEffectiveLog<T> where T : class
{
    void Debug(string message);
    void Information(string message);
    void Warning(string message);
    void Fail(string message);
}
