using System;
using System.IO;

namespace DemoApp.AudioLibrary
{
    public class BitrateReader
    {
        public static AudioFile Convert(BufferedAudio buffer, ICodec destinationCodec)
        {
            string extension = destinationCodec is MP3Codec ? ".mp3" : ".wma";
            
            return new AudioFile(Path.ChangeExtension(buffer.AudioFile, extension));
        }

        public static BufferedAudio Read(string filePath, ICodec sourceCodec)
        {
            return new BufferedAudio(filePath);
        }
    }
}
