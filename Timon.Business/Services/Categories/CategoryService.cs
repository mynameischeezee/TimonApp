using Timon.Abstract.Services.Categories;
using Timon.Business.Dto;
using Timon.DataAccess.Models;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.Services.Categories;

public class CategoryService : ICategoryService<DataAccess.Models.Category, DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataAccess.Models.Category> CreateCategory(DataAccess.Models.Category record)
    {
        record.CreatedAt = DateTime.Now;
        record.UpdatedAt = DateTime.Now;
        await _unitOfWork.Categories.Insert(record);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.Category> DeleteCategory(DataAccess.Models.Category record)
    {
        await _unitOfWork.Categories.Delete(record.Id);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.Category> UpdateCategory(DataAccess.Models.Category record)
    {
        record.UpdatedAt = DateTime.Now;
        _unitOfWork.Categories.Update(record);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<IEnumerable<DataAccess.Models.Category>> GetAllUsersCategories(DataAccess.Models.User user)
    {
        var categories = await _unitOfWork.Categories.GetAll(x => x.User != null && x.User.Id == user.Id);
        return categories;
    }

    public async Task<DataAccess.Models.Category> GetCategory(int id)
    {
        var category = await _unitOfWork.Categories.Get(x => x.Id == id);
        return category;
    }
}