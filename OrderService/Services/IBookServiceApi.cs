using RestEase;
using OrderService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Services
{
    public interface IBookServiceApi
    {
        [Get("/api/book")]
        Task<List<BookDto>> GetBooksAsync();

        [Get("/api/book/{id}")]
        Task<BookDto> GetBookByIdAsync([Path] int id);
    }
}
