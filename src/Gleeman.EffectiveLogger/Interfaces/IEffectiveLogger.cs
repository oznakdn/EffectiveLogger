namespace Gleeman.EffectiveLogger.Interfaces;

public interface IEffectiveLogger<T> where T : class
{
    void Debug(string message);
    void Information(string message);
    void Fail(string message);
    void Warning(string message);
}
