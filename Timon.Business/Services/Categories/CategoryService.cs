using Timon.Abstract.Services.Categories;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.Services.Categories;

public class CategoryService : ICategoryService<DataAccess.Models.Category, DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataAccess.Models.Category> CreateCategory(DataAccess.Models.User user, DataAccess.Models.Category record)
    {
        record.CreatedAt = DateTime.Now;
        record.UpdatedAt = DateTime.Now;
        await _unitOfWork.Category.Insert(record);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.Category> DeleteCategory(DataAccess.Models.Category record)
    {
        await _unitOfWork.Category.Delete(record.Id);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.Category> UpdateCategory(DataAccess.Models.Category record)
    {
        record.UpdatedAt = DateTime.Now;
        _unitOfWork.Category.Update(record);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<IEnumerable<DataAccess.Models.Category>> GetAllUsersCategories(DataAccess.Models.User user)
    {
        var userCategories = await _unitOfWork.Category.GetAll(x => x.UserId == user.Id);
        var userCategoriesId = userCategories.Select(x => x.Id);
        var categories = await _unitOfWork.Category.GetAll(x => userCategoriesId.Contains(x.Id));
        return categories.ToList();
    }

    public async Task<DataAccess.Models.Category> GetCategory(int id)
    {
        var category = await _unitOfWork.Category.Get(x => x.Id == id);
        return category;
    }
}