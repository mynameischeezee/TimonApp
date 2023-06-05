namespace Timon.Abstract.User;

public interface IUserService<T> where T : class
{
    T CreateUser(string username, string email, string password);
    T DeleteUser(T record);
    T UpdateUser(T record);
    IEnumerable<T> GetAllUsers();
    T GetUser(int id);
}