using System.IO;

namespace DemoApp.AudioLibrary
{
    public class CodecFactory
    {
        public ICodec ExtractCodec(AudioFile file)
        {
            string fileExtension = Path.GetExtension(file.FilePath);
            return fileExtension == ".mp3" ? new MP3Codec() : new WMACodec();
        }
    }
}
