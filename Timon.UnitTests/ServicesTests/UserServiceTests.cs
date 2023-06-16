using Timon.Business.Services.User;
using Timon.DataAccess.UnitOfWork;

namespace Timon.UnitTests.ServicesTests;

public class UserServiceTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private UserService _userService;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userService = new UserService(_unitOfWorkMock.Object);
    }

    [Test]
    public async Task CreateUser_ValidUser_Success()
    {
        // Arrange
        var user = new User();

        _unitOfWorkMock.Setup(u => u.Users.Insert(user)).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.Save()).Returns(Task.CompletedTask);

        // Act
        var result = await _userService.CreateUser(user);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(user, result);
    }

    [Test]
    public async Task DeleteUser_ValidUser_Success()
    {
        // Arrange
        var user = new User();

        _unitOfWorkMock.Setup(u => u.Users.Delete(user.Id)).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.Save()).Returns(Task.CompletedTask);

        // Act
        var result = await _userService.DeleteUser(user);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(user, result);
    }

    [Test]
    public async Task UpdateUser_ValidUser_Success()
    {
        // Arrange
        var user = new User();

        _unitOfWorkMock.Setup(u => u.Users.Update(user));
        _unitOfWorkMock.Setup(u => u.Save()).Returns(Task.CompletedTask);

        // Act
        var result = await _userService.UpdateUser(user);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(user, result);
    }

    [Test]
    public async Task GetAllUsers_ValidCall_Success()
    {
        // Arrange
        var users = new List<User> { new User(), new User(), new User() };

        _unitOfWorkMock.Setup(u => u.Users.GetAll(It.IsAny<Expression<Func<User, bool>>>(), null, null)).ReturnsAsync(users);

        // Act
        var result = await _userService.GetAllUsers();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(users.Count, result.Count());
    }
    

    [Test]
    public async Task GetUserByNickname_ValidNickname_Success()
    {
        // Arrange
        var user = new User { UserName = "test" };

        _unitOfWorkMock.Setup(u => u.Users.Get(It.IsAny<Expression<Func<User, bool>>>(), null))
                       .ReturnsAsync(user);

        // Act
        var result = await _userService.GetUserByNickname("test");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(user, result);
    }
}