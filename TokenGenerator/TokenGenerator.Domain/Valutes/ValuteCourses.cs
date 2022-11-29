using System.Xml.Serialization;

namespace TokenGenerator.TokenGenerator.Domain.Valutes;

[Serializable, XmlRoot(ElementName = "ValCurs")]
public class ValuteCourses
{
    [XmlAttribute("Date")]
    public string Date { get; set; }
    
    [XmlAttribute("name")]
    public string Name { get; set; }
    
    [XmlElement(ElementName = "Valute")]
    public List<ValuteModel> Valutes { get; set; }
}