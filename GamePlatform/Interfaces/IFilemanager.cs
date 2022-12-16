namespace GamePlatform.Interfaces
{
    public interface IFileManager
    {
        StreamReader GetStreamReader(string filePath);
        StreamWriter GetStreamWriter(string filePath);
    }
}