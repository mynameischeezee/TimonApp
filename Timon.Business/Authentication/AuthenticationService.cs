using Timon.Abstract.Authentication;
using Timon.DataAccess.UnitOfWork;

namespace Timon.Business.Authentication;

public class AuthenticationService : IAuthenticationService<DataAccess.Models.User>
{
    private readonly IUnitOfWork _unitOfWork;
    public AuthenticationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public DataAccess.Models.User Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.User Register(string username, string password)
    {
        throw new NotImplementedException();
    }

    public DataAccess.Models.User SignOut()
    {
        throw new NotImplementedException();
    }
}