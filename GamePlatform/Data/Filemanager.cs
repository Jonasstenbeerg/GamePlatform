using GamePlatform.Interfaces;

namespace GamePlatform.Data
{
    internal class Filemanager : IFilemanager
    {
        public StreamReader StreamReader(string path)
        {
            return new StreamReader(path);
        }

        public StreamWriter StreamWriter(string path)
        {
            return new StreamWriter(path, append: true);
        }
    }
}
