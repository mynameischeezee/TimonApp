namespace Timon.Abstract.User;

public interface IUserService<TUser> where TUser : class
{
    Task<TUser> CreateUser(string username, string email, string password);
    Task<TUser> DeleteUser(TUser record);
    Task <TUser> UpdateUser(TUser record);
    Task<IEnumerable<TUser>> GetAllUsers();
    Task<TUser?> GetUser(int id);
}