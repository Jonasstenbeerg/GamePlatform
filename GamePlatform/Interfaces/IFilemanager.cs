namespace GamePlatform.Interfaces
{
    public interface IFilemanager
    {
        StreamReader StreamReader(string path);
        StreamWriter StreamWriter(string path);
    }
}