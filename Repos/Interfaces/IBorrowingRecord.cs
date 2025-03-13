using Borrowing.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BorrowingRecord.Repo.Interfaces
{
    public interface IBorrowingRecord
    {
        
        Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetAllAsync();

        
        Task<Borrowing.Model.BorrowingRecord?> GetByIdAsync(int id);

        
        Task<Borrowing.Model.BorrowingRecord> AddAsync(Borrowing.Model.BorrowingRecord record);

        
        Task<Borrowing.Model.BorrowingRecord> UpdateAsync(Borrowing.Model.BorrowingRecord record);

      
        Task<bool> DeleteAsync(int id);

        
        Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetBorrowedBooksAsync();

      
        Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetRecentlyReturnedBooksAsync();

        
        Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetNonReturnedBooksAsync();
    }
}
