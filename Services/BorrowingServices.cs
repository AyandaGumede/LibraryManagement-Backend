using Borrowing.Services.Interfaces;
using Borrowing.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorrowingRecord.Repo.Interfaces;

namespace Borrowing.Services
{
    public class BorrowingServices : IBorrowingServices
    {
        private readonly IBorrowingRecord _borrowingRepository;

        public BorrowingServices(IBorrowingRecord borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
        }

        public async Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetAllAsync()
        {
            return await _borrowingRepository.GetAllAsync();
        }

        public async Task<Borrowing.Model.BorrowingRecord?> GetByIdAsync(int id)
        {
            return await _borrowingRepository.GetByIdAsync(id);
        }

        public async Task<Borrowing.Model.BorrowingRecord> AddAsync(Borrowing.Model.BorrowingRecord record)
        {
            return await _borrowingRepository.AddAsync(record);
        }

        public async Task<Borrowing.Model.BorrowingRecord> UpdateAsync(Borrowing.Model.BorrowingRecord record)
        {
            return await _borrowingRepository.UpdateAsync(record);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _borrowingRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetBorrowedBooksAsync()
        {
            return await _borrowingRepository.GetBorrowedBooksAsync();
        }

        public async Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetRecentlyReturnedBooksAsync()
        {
            return await _borrowingRepository.GetRecentlyReturnedBooksAsync();
        }

        public async Task<IEnumerable<Borrowing.Model.BorrowingRecord>> GetNonReturnedBooksAsync()
        {
            return await _borrowingRepository.GetNonReturnedBooksAsync();
        }
    }
}
