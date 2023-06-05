namespace Timon.Abstract.Authentication;

public interface IAuthenticationService<TUser> where TUser : class
{
    TUser Login(string username, string password);

    TUser Register(string username, string password);

    TUser SignOut();
}