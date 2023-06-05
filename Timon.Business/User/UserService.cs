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

    public DataAccess.Models.User CreateUser(string username, string email, string password)
    {
        var user = new DataAccess.Models.User()
        {
            UserName = username,
            Email = email,
            Password = password
        };
        _unitOfWork.Users.Insert(user);
        _unitOfWork.Save();
        return user;
    }

    public DataAccess.Models.User DeleteUser(DataAccess.Models.User record)
    {
        _unitOfWork.Users.Delete(record.Id);
        _unitOfWork.Save();
        return record;
    }

    public DataAccess.Models.User UpdateUser(DataAccess.Models.User record)
    {
        _unitOfWork.Users.Update(record);
        _unitOfWork.Save();
        return record;
    }

    public IEnumerable<DataAccess.Models.User> GetAllUsers()
    {
        var users = _unitOfWork.Users.GetAll();
        return users.Result;
    }

    public DataAccess.Models.User? GetUser(int id)
    {
        var user = GetAllUsers().FirstOrDefault(x => x.Id == id);
        return user;
    }
}