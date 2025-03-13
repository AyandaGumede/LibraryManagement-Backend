using Borrowing.Services.Interfaces;
using Borrowing.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorrowingRecord.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingRecordController : ControllerBase
    {
        private readonly IBorrowingServices _borrowingServices;

        public BorrowingRecordController(IBorrowingServices borrowingServices)
        {
            _borrowingServices = borrowingServices;
        }

        // Get all borrowing records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrowing.Model.BorrowingRecord>>> GetAll()
        {
            var records = await _borrowingServices.GetAllAsync();
            return Ok(records);
        }

        // Get a single borrowing record by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Borrowing.Model.BorrowingRecord>> GetById(int id)
        {
            var record = await _borrowingServices.GetByIdAsync(id);
            if (record == null)
                return NotFound($"Borrowing record with ID {id} not found.");

            return Ok(record);
        }

        // Add a new borrowing record
        [HttpPost]
        public async Task<ActionResult<Borrowing.Model.BorrowingRecord>> Add([FromBody] Borrowing.Model.BorrowingRecord record)
        {
            if (record == null)
                return BadRequest("Invalid borrowing record.");

            var createdRecord = await _borrowingServices.AddAsync(record);
            return CreatedAtAction(nameof(GetById), new { id = createdRecord.Id }, createdRecord);
        }

        // Update an existing borrowing record
        [HttpPut("{id}")]
        public async Task<ActionResult<Borrowing.Model.BorrowingRecord>> Update(int id, [FromBody] Borrowing.Model.BorrowingRecord record)
        {
            if (record == null || id != record.Id)
                return BadRequest("Invalid data for update.");

            var updatedRecord = await _borrowingServices.UpdateAsync(record);
            return Ok(updatedRecord);
        }

        // Delete a borrowing record by ID
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _borrowingServices.DeleteAsync(id);
            if (!deleted)
                return NotFound($"Borrowing record with ID {id} not found.");

            return NoContent();
        }

        // Get all currently borrowed books
        [HttpGet("borrowed")]
        public async Task<ActionResult<IEnumerable<Borrowing.Model.BorrowingRecord>>> GetBorrowedBooks()
        {
            var records = await _borrowingServices.GetBorrowedBooksAsync();
            return Ok(records);
        }

        // Get recently returned books
        [HttpGet("returned/recent")]
        public async Task<ActionResult<IEnumerable<Borrowing.Model.BorrowingRecord>>> GetRecentlyReturnedBooks()
        {
            var records = await _borrowingServices.GetRecentlyReturnedBooksAsync();
            return Ok(records);
        }

        // Get overdue (non-returned) books
        [HttpGet("overdue")]
        public async Task<ActionResult<IEnumerable<Borrowing.Model.BorrowingRecord>>> GetNonReturnedBooks()
        {
            var records = await _borrowingServices.GetNonReturnedBooksAsync();
            return Ok(records);
        }
    }
}
