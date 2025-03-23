using Microsoft.AspNetCore.Mvc;
using OrderService.Services;
using OrderService.Models;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IBookServiceApi _bookServiceApi;

        public OrderController(IBookServiceApi bookServiceApi)
        {
            _bookServiceApi = bookServiceApi;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] int[] bookIds)
        {
            var books = await _bookServiceApi.GetBooksAsync();

            var selectedBooks = books.Where(b => bookIds.Contains(b.Id)).ToList();

            if (!selectedBooks.Any())
                return BadRequest("No valid books selected");

            var totalPrice = selectedBooks.Sum(b => b.Price);

            var order = new Order
            {
                BookIds = bookIds,
                TotalPrice = totalPrice
            };

            return Ok(order);
        }
    }
}
