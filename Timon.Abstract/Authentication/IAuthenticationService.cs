namespace Timon.Abstract.Authentication;

public interface IAuthenticationService
{
    void Login(string username, string password);

    void Register(string username, string password);

    void SignOut();
}