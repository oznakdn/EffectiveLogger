namespace Gleeman.EffectiveLogger.Helpers;

public class LogHelper
{
    private readonly LogDbContext _dbContext;
    public LogHelper(LogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void WriteToConsole(DateTime date, string logLevel, string message)
    {
        switch (logLevel)
        {
            case "dbug":
                Console.ForegroundColor = ConsoleColor.Green; break;
            case "info":
                Console.ForegroundColor = ConsoleColor.Blue; break;
            case "warn":
                Console.ForegroundColor = ConsoleColor.Yellow; break;
            case "fail":
                Console.ForegroundColor = ConsoleColor.Red; break;
        }

        Console.WriteLine($"{logLevel}: {date} {message}");
    }

    public void WriteToFile(string path, string fileName, DateTime date, string logLevel, string message)
    {
        string shortDate = DateTime.Now.ToShortDateString();
        fileName = $"{shortDate}-{fileName}.txt";
        string directory = $"{path}\\{fileName}";

        FileStream file = null;

        if (File.Exists(directory))
        {
            file = new FileStream(directory, FileMode.Append);
        }
        else
        {
            file = new FileStream(directory, FileMode.CreateNew);
        }

        using StreamWriter stream = new StreamWriter(file);
        stream.WriteLine($"{logLevel}: {date} {message}");
        stream.Close();
        file.Close();
    }


    //TODO: Context null geliyor
    public void WriteToDatabase(DateTime date, string logLevel, string message)
    {
        _dbContext.Logs.AddRange(new LogModel
        {
            Date = date,
            LogLevel = logLevel,
            Message = message
        });
        _dbContext.SaveChanges();
    }
}
