namespace DemoApp.AudioLibrary
{
    public class BufferedAudio
    {
        public string AudioFile { get; private set; }

        public BufferedAudio(string audioFile)
        {
            AudioFile = audioFile;
        }
    }
}