namespace Gleeman.EffectiveLogger;


public class LogOptions
{
    public bool? WriteToFile { get; set; }
    public bool? WriteToDatabase { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public DatabaseOptions? DatabaseOptions { get; set; }
}

public class DatabaseOptions
{
    public string SQLiteConnectionString { get; set; } = string.Empty;
    public string MSSqlServerConectionString { get; set; } = string.Empty;
    public string PostgreSqlConnectionString { get; set; } = string.Empty;
    public string MySqlConnectionString { get; set; } = string.Empty;
}
