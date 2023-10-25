using DemoApp.AudioLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class AudioConverter
    {
        public static string Encode(string path, string resultFormat)
        {
            AudioFile file = new AudioFile(path);
            ICodec sourceCodec = new CodecFactory().ExtractCodec(file);
            ICodec destCodec = resultFormat == "mp3" ? new MP3Codec() : new WMACodec();
            BufferedAudio buffer = BitrateReader.Read(path, sourceCodec);
            AudioFile result = BitrateReader.Convert(buffer, destCodec);
            result = (new NoiseRemover()).Fix(result);
            return result.FilePath;
        }
    }
}
