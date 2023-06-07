namespace Timon.Abstract.Services.Categories;

public interface ICategoryService<TCategory, in TUser>
    where TCategory : class
    where TUser : class
{
    Task<TCategory> CreateCategory(TCategory record);
    Task<TCategory> DeleteCategory(TCategory record);
    Task<TCategory> UpdateCategory(TCategory record);
    Task<IEnumerable<TCategory>> GetAllUsersCategories(TUser user);
    Task<TCategory> GetCategory(int id);
}