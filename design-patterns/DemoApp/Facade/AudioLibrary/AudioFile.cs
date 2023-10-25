namespace DemoApp.AudioLibrary
{
    public class AudioFile
    {
        private string filePath;

        public AudioFile(string filePath)
        {
            this.filePath = filePath;
        }

        public string FilePath { get => filePath; }
    }
}
