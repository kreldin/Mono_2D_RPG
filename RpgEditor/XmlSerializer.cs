using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace RpgEditor
{
    internal static class XmlSerializer
    {
        public static void Serialize<T>(string filename, T data)
        {
            var settings = new XmlWriterSettings
            {
                Indent = true
            };

            using (var writer = XmlWriter.Create(filename, settings))
                IntermediateSerializer.Serialize(writer, data, null);
        }

        public static T Deserialize<T>(string filename)
        {
            T data;

            using (var stream = new FileStream(filename, FileMode.Open))
            {
                using (var reader = XmlReader.Create(stream))
                    data = IntermediateSerializer.Deserialize<T>(reader, null);
            }

            return data;
        }
    }
}
