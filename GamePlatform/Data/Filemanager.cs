using GamePlatform.Interfaces;

namespace GamePlatform.Data
{
    internal class FileManager : IFileManager
    {
        public StreamReader GetStreamReader(string filePath)
        {
            return new StreamReader(filePath);
        }

        public StreamWriter GetStreamWriter(string filePath)
        {
            return new StreamWriter(filePath, append: true);
        }
    }
}