using GamePlatform.Interfaces;

namespace GamePlatform.Data
{
    internal class Filemanager : IFilemanager
    {
        public StreamReader StreamReader(string path)
        {
            return new StreamReader(path);
        }

    }
}
