namespace Gleeman.EffectiveLogger.Factory.Concrete;

internal class FileLog : AbstractLog
{
    public override void Write(string filePath, string fileName, string message)
    {
        string shortDate = DateTime.Now.ToShortDateString();
        fileName = $"{shortDate}-{fileName}.txt";
        string directory = $"{filePath}\\{fileName}";

        FileStream file = null;

        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        if (File.Exists(directory))
        {
            file = new FileStream(directory, FileMode.Append);
        }
        else
        {
            file = new FileStream(directory, FileMode.CreateNew);
        }

        using StreamWriter stream = new StreamWriter(file);
        stream.WriteLine(message);
        stream.Close();
        file.Close();
    }
}
