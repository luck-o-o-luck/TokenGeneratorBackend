using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TokenGenerator.TokenGenerator.Domain.Valutes;
using TokenGenerator.TokenGenerator.Services.Interfaces;

namespace TokenGenerator.TokenGenerator.Services.Implementations;

public class QuoteService : IQuoteService
{
    public ValuteCourses GetQuoteAsync(DateTime date)
    {
        var correctDateFormat = date.ToString("dd/MM/yyyy");
        
        var url = $"http://www.cbr.ru/scripts/XML_daily.asp?date_req={correctDateFormat}";
        
        var request = WebRequest.Create(url);
        var response = request.GetResponse(); 
        
        var stream = response.GetResponseStream();
        var reader = new StreamReader(stream, Encoding.UTF8);
        
        var result = reader.ReadToEnd();
        return Deserialize(result);
    }
    
    private ValuteCourses Deserialize(string xmlString)
    {
        var serializer = new XmlSerializer(typeof(ValuteCourses));
        var reader = new StringReader(xmlString);
        var valuteModel = (ValuteCourses)serializer.Deserialize(reader);
        return valuteModel;
    }
}