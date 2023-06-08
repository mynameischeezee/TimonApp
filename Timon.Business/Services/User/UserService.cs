using Microsoft.Maui.ApplicationModel.Communication;
using Timon.Abstract.Services.User;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.Services.User;

public class UserService : IUserService<DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<DataAccess.Models.User> CreateUser(DataAccess.Models.User record)
    {
        record.CreatedAt = DateTime.Now;
        record.UpdatedAt = DateTime.Now;
        await _unitOfWork.Users.Insert(record);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.User> DeleteUser(DataAccess.Models.User record)
    {
        await _unitOfWork.Users.Delete(record.Id);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<DataAccess.Models.User> UpdateUser(DataAccess.Models.User record)
    {
        record.UpdatedAt = DateTime.Now;
        _unitOfWork.Users.Update(record);
        await _unitOfWork.Save();
        return record;
    }

    public async Task<IEnumerable<DataAccess.Models.User>> GetAllUsers()
    {
        var users = await _unitOfWork.Users.GetAll();
        return users.ToList();
    }

    public async Task<DataAccess.Models.User?> GetUser(int id)
    {
        var user = await GetAllUsers();
        var currentUser = user.ToList().FirstOrDefault(x => x.Id == id);
        return currentUser;
    }
}