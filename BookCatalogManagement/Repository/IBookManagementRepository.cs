using DigitalBookstoreManagement.Models;

namespace DigitalBookstoreManagement.Repository
{
    public interface IBookManagementRepository
    {
        // Book Operations
        Task<IEnumerable<BookManagement>> GetAllBooksAsync();
        Task<BookManagement?> GetBookByIdAsync(int bookId);
        Task<IEnumerable<BookManagement>> SearchBooksByTitleAsync(string title);
        Task<IEnumerable<BookManagement>> GetBooksByAuthorNameAsync(string authorName);
        Task<IEnumerable<BookManagement>> GetBooksByCategoryNameAsync(string categoryName);
        Task AddBookAsync(BookManagement book);
        Task UpdateBookAsync(BookManagement book);
        Task DeleteBookAsync(int bookId);
        //Task<int> SaveChangesAsync();
        //Task<string> GetStockAvailabilityAync(int stockQuantity);
    }
}
 