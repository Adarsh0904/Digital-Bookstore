﻿using DigitalBookstoreManagement.Models;

namespace DigitalBookstoreManagement.Services
{
    public interface IBookManagementService
    {

        Task<IEnumerable<BookManagement>> GetAllBooksAsync();
        Task<BookManagement?> GetBookByIdAsync(int bookId);
        Task<IEnumerable<BookManagement>> SearchBooksByTitleAsync(string title);
        Task<IEnumerable<BookManagement>> GetBooksByAuthorNameAsync(string authorName);
        Task<IEnumerable<BookManagement>> GetBooksByCategoryNameAsync(string categoryName);
        Task AddBookAsync(BookManagement book);
        Task UpdateBookAsync(BookManagement book);
        Task DeleteBookAsync(int bookId);
        //Task<string> GetStockAvailability(int stockQuantity);

    }
}