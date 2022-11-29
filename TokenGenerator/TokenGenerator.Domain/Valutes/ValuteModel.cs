using System.Xml.Serialization;

namespace TokenGenerator.TokenGenerator.Domain.Valutes;

[Serializable, XmlRoot(ElementName = "Valute")]
public class ValuteModel
{
    [XmlAttribute("ID")]
    public string ID { get; set; }
    
    [XmlElement("NumCode")]
    public int NumCode { get; set; }
    
    [XmlElement("CharCode")]
    public string CharCode { get; set; }
    
    [XmlElement("Nominal")]
    public int Nominal { get; set; }
    
    [XmlElement("Name")]
    public string Name { get; set; }
    
    [XmlElement("Value")]
    public string Value { get; set; }
}