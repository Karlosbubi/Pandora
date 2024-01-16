using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

if (args.Length < 1) {
    Console.Error.WriteLine("No files provided");
    return;
}

foreach (string xmlFilePath in args)
{
    try
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlFilePath);
        foreach (XmlNode node in xmlDocument)
        {
            if (node.NodeType == XmlNodeType.XmlDeclaration)
            {
                xmlDocument.RemoveChild(node);
            }
        }
        string jsonText = JsonConvert.SerializeXmlNode(xmlDocument, Formatting.Indented);
        
        string newJsonFilePath = xmlFilePath.Replace(".xml", ".json");
        File.WriteAllText(newJsonFilePath, jsonText);
    }
    catch (Exception e)
    {
        Console.Error.WriteLine($"Skipped file \"{xmlFilePath}\" due to Error {e.Message} ");
    }
}