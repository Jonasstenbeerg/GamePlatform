namespace GamePlatform.Interfaces
{
    public interface IFileManager
    {
        StreamReader StreamReader(string path);
        StreamWriter StreamWriter(string path);
    }
}