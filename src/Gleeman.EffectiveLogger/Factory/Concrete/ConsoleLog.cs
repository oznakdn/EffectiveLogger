namespace Gleeman.EffectiveLogger.Factory.Concrete;

internal class ConsoleLog : AbstractLog
{
    public override void Write(LogLevelType logLevelType, string message)
    {

        switch (logLevelType)
        {
            case LogLevelType.dbug:
                Console.ForegroundColor = ConsoleColor.Green; break;

            case LogLevelType.info:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case LogLevelType.warn:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case LogLevelType.fail:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
        }

        Console.WriteLine(message);
        Debug.WriteLine(message);
    }
}
