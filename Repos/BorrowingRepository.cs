using AppDbContext;
using Borrowing.Model;
using BorrowingRecord.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowingRecord.Repos
{
    public class BorrowingRepo : IBorrowingRecord
    {
        private readonly AppDbContext.Namespace.AppDbContext _context;

        public BorrowingRepo(AppDbContext.Namespace.AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetAllAsync()
        {
            return await _context.BorrowingRecords.ToListAsync();
        }

        public async Task<Borrowing.Model.BorrowingRecord?> GetByIdAsync(int studentNumber)
        {
            return await _context.BorrowingRecords
                .FirstOrDefaultAsync(s => s.Status == "Borrowed" && s.StudentNumber == studentNumber);
        }

        public async Task<Borrowing.Model.BorrowingRecord> AddAsync(Borrowing.Model.BorrowingRecord record)
        {
            _context.BorrowingRecords.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<Borrowing.Model.BorrowingRecord> UpdateAsync(Borrowing.Model.BorrowingRecord record)
        {
            _context.BorrowingRecords.Update(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var record = await _context.BorrowingRecords.FindAsync(id);
            if (record == null) return false;

            _context.BorrowingRecords.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetBorrowedBooksAsync()
        {
            return await _context.BorrowingRecords
                .Where(b => b.Status == "Borrowed")
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetRecentlyReturnedBooksAsync()
        {
            var sevenDaysAgo = DateTime.Now.AddDays(-7);
            return await _context.BorrowingRecords
                .Where(b => b.Status == "Returned" && b.ReturnDate >= sevenDaysAgo)
                .ToListAsync();
        }

        public async Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetNonReturnedBooksAsync()
        {
            var today = DateTime.Now;
            return await _context.BorrowingRecords
                .Where(b => b.Status == "Borrowed" && b.ReturnDate < today)
                .ToListAsync();
        }
    }
}

