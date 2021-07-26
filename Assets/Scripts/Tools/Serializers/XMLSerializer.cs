using System;
using System.IO;
using System.Xml.Serialization;

public class XMLSerializer<T> : IStringSerializer<T>
    where T : class
{
    private readonly XmlSerializer xmlSerializer;

    public XMLSerializer()
    {
        xmlSerializer = new XmlSerializer(typeof(T));
    }

    public string Serialize(T data)
    {
        using (StringWriter stringWriter = new StringWriter())
        {
            xmlSerializer.Serialize(stringWriter, data);
            return stringWriter.ToString();
        }

        throw new Exception("Something went wrong...");
    }

    public T Deserialize(string data)
    {
        using (StringReader stringReader = new StringReader(data))
        {
            return xmlSerializer.Deserialize(stringReader) as T;
        }

        throw new Exception("Something went wrong...");
    }
}
