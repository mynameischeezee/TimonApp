using Timon.Abstract.Authentication;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthenticationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Login(string username, string password)
    {
        
    }

    public void Register(string username, string password)
    {
        
        
    }

    public void SignOut()
    {
        
    }
}