using Timon.Abstract.User;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.User;

public class UserService : IUserService<DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DataAccess.Models.User> CreateUser(string username, string email, string password)
    {
        var user = new DataAccess.Models.User()
        {
            UserName = username,
            Email = email,
            Password = password,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        await _unitOfWork.Users.Insert(user);
        await _unitOfWork.Save();
        return user;
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