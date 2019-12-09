using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Storing.Connectors
{
  public class FileSystemConnector
  {
    private const string _path = @"storage.xml";
    public List<AMedia> ReadXml(string path = _path)
    {
      var xml = new XmlSerializer(typeof(List<AMedia>)); //translator - XmlSerializer, let it know what to be encoded/decoded
      var reader = new StreamReader(path);               //what parses through text, file reader
      return xml.Deserialize(reader) as List<AMedia>;    //you get something that resembles AMedia
    }

    public void WriteXml(List<AMedia> data, string path = _path)
    {
      var xml = new XmlSerializer(typeof(List<AMedia>));
      var writer = new StreamWriter(path);
      xml.Serialize(writer,data); 
    }
  }
}