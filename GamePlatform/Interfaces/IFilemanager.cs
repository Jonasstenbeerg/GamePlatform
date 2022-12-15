namespace GamePlatform.Interfaces
{
    public interface IFileManager
    {
        StreamReader GetStreamReader(string path);
        StreamWriter GetStreamWriter(string path);
    }
}