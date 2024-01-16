using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

if (args.Length < 1) {
    Console.Error.WriteLine("No files provided");
    return;
}

foreach (string jsonFilePath in args)
{
    try
    {
        string jsonText = File.ReadAllText(jsonFilePath);
        XmlDocument xmlDocument = JsonConvert.DeserializeXmlNode(jsonText) ?? throw new ArgumentNullException();

        string newXmlFilePath = jsonFilePath.Replace(".json", ".xml");
        string xmlDeclaration = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>";

        string xmlText = xmlDeclaration + "\n" + PrettyXml(xmlDocument.OuterXml);
        
        File.WriteAllText(newXmlFilePath, xmlText);
    }
    catch (Exception e)
    {
        Console.Error.WriteLine($"Skipped file \"{jsonFilePath}\" due to Error {e.Message} ");
    }
}

return;


static string PrettyXml(string xml)
{
    var stringBuilder = new StringBuilder();

    var element = XElement.Parse(xml);

    var settings = new XmlWriterSettings
    {
        OmitXmlDeclaration = true, // Would add UTF-16
        Indent = true,
        NewLineOnAttributes = true
    };

    using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
    {
        element.Save(xmlWriter);
    }

    return stringBuilder.ToString();
}