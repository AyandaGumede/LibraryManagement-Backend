using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AddBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddBookController : ControllerBase
    {
        
        private readonly ILogger<AddBookController> _logger;

        public AddBookController( ILogger<AddBookController> logger)
        {
            _logger = logger;
        }
        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBook([FromBody] AllBooks.Model.AllBooks book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Invalid book data. Please provide valid book details.");
                }
                //move this to repository
                //_context.AllBooks.Add(book);
               // await _context.SaveChangesAsync();

                return Ok($"{book.Title} (ISBN: {book.Isbn}) has been added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while adding a book: {ex.Message}");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

    }
}