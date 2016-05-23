using System;
using System.IO;
using XmlSerializerFactory = Snippets.Factories.XmlSerializerFactory;

namespace Snippets.Serialization
{
    public class XmlConversation
    {
        static public object XmlStringToObject(Type t, string xmlString)
        {
            object returnObject = null;
            var sReader = new StringReader(xmlString);
            var seri = XmlSerializerFactory.GetSerializer(t);
            returnObject = seri.Deserialize(sReader);
            return returnObject;
        }

        static public string ObjectToXmlString(object inputObject)
        {
            string xmlString = null;
            using (var memStream = new MemoryStream())
            {
                var serializer = XmlSerializerFactory.GetSerializer(inputObject.GetType());
                serializer.Serialize(memStream, inputObject);
                memStream.Position = 0;
                xmlString = new StreamReader(memStream).ReadToEnd();
                memStream.Close();
            }

            return xmlString;
        }
    }
}
