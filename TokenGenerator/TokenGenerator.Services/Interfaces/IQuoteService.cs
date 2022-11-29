using TokenGenerator.TokenGenerator.Domain.Valutes;

namespace TokenGenerator.TokenGenerator.Services.Interfaces;

public interface IQuoteService
{
    ValuteCourses GetQuoteAsync(DateTime date);
}