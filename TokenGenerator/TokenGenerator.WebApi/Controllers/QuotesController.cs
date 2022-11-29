using Microsoft.AspNetCore.Mvc;
using TokenGenerator.TokenGenerator.Services.Interfaces;

namespace TokenGenerator.TokenGenerator.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IQuoteService _quoteService;
    
    public QuotesController(IQuoteService quoteService)
    {
        _quoteService = quoteService;
    }
    
    [HttpGet("/api/quotation")]
    public IActionResult Get([FromQuery] DateTime date)
    {
        return Ok(_quoteService.GetQuoteAsync(date));
    }
}