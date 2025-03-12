using DigitalBookstoreManagement.Models;

namespace DigitalBookstoreManagement.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(string categoryId);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(string categoryId);

        // Save Changes
        //Task<booSaveChangesAsync();
    }
}