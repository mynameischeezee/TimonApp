namespace Timon.Abstract.Services.User;

public interface IUserService<TUser> where TUser : class
{
    Task<TUser> CreateUser(TUser record);
    Task<TUser> DeleteUser(TUser record);
    Task<TUser> UpdateUser(TUser record);
    Task<IEnumerable<TUser>> GetAllUsers();
    Task<TUser?> GetUser(int id);
    Task<TUser?> GetUserByNickname(string nickName);
}