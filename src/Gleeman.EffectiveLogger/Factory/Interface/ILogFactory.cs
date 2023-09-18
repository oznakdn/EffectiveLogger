namespace Gleeman.EffectiveLogger.Factory.Interface;

public interface ILogFactory
{
    AbstractLog CreateLog(LogType logType);
}
