using MonoBankApi;
using MonoBankApi.Services;
using Timon.Abstract.DataAccess.Repository;
using Timon.Business.Services.Categories;
using Timon.Business.Services.MoneyRecord;
using Timon.DataAccess.UnitOfWork;

namespace Timon.UnitTests.ServicesTests;

public class MoneyRecordServiceTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private Mock<IMonoPersonal> _connectorMock;
    private MoneyRecordService _service;
    private User _user;
    private MoneyRecord _record;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _connectorMock = new Mock<IMonoPersonal>();
        _service = new MoneyRecordService(_unitOfWorkMock.Object, _connectorMock.Object);
        _user = new User { Id = 1 };
        _record = new MoneyRecord { Id = 1 };
    }

    [Test]
    public async Task CreateMoneyRecord_ShouldCreateMoneyRecord()
    {
        // Arrange
        var moneyRecord = new MoneyRecord();
        _unitOfWorkMock.Setup(u => u.MoneyRecords.Insert(It.IsAny<MoneyRecord>()));
        _unitOfWorkMock.Setup(u => u.UserMoneyRecords.Insert(It.IsAny<UserMoneyRecord>()));
        _unitOfWorkMock.Setup(u => u.Save())
                       .Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateMoneyRecord(_user, moneyRecord);

        // Assert
        _unitOfWorkMock.Verify(u => u.MoneyRecords.Insert(It.IsAny<MoneyRecord>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.UserMoneyRecords.Insert(It.IsAny<UserMoneyRecord>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Exactly(2));
        Assert.AreEqual(result, moneyRecord);
    }

    [Test]
    public async Task DeleteMoneyRecord_ShouldDeleteMoneyRecord()
    {
        // Arrange
        var moneyRecord = new MoneyRecord { Id = 1 };
        var userMoneyRecord = new UserMoneyRecord { MoneyRecord = moneyRecord };
        _unitOfWorkMock.Setup(u => u.UserMoneyRecords.Get(It.IsAny<Expression<Func<UserMoneyRecord, bool>>>(), null))
                       .ReturnsAsync(userMoneyRecord);
        _unitOfWorkMock.Setup(u => u.UserMoneyRecords.Delete(userMoneyRecord.Id));
        _unitOfWorkMock.Setup(u => u.MoneyRecords.Delete(moneyRecord.Id));
        _unitOfWorkMock.Setup(u => u.Save())
                       .Returns(Task.CompletedTask);

        // Act
        var result = await _service.DeleteMoneyRecord(moneyRecord);

        // Assert
        _unitOfWorkMock.Verify(u => u.UserMoneyRecords.Delete(userMoneyRecord.Id), Times.Once());
        _unitOfWorkMock.Verify(u => u.MoneyRecords.Delete(moneyRecord.Id), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Once());
        Assert.AreEqual(result, moneyRecord);
    }

    [Test]
    public async Task UpdateMoneyRecord_ShouldUpdateMoneyRecord()
    {
        // Arrange
        var moneyRecord = new MoneyRecord { Id = 1 };
        _unitOfWorkMock.Setup(u => u.MoneyRecords.Update(moneyRecord));
        _unitOfWorkMock.Setup(u => u.Save())
                       .Returns(Task.CompletedTask);

        // Act
        var result = await _service.UpdateMoneyRecord(moneyRecord);

        // Assert
        _unitOfWorkMock.Verify(u => u.MoneyRecords.Update(moneyRecord), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Once());
        Assert.AreEqual(result, moneyRecord);
    }

    [Test]
    public async Task GetAllUsersMoneyRecords_ShouldReturnAllUsersMoneyRecords()
    {
        // Arrange
        var moneyRecord = new MoneyRecord { Id = 1 };
        var userMoneyRecord = new UserMoneyRecord { MoneyRecordId = moneyRecord.Id, User = _user };
        var userMoneyRecordsMock = new Mock<IGenericRepository<UserMoneyRecord>>();
        userMoneyRecordsMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<UserMoneyRecord, bool>>>(), null, null))
                            .ReturnsAsync(new List<UserMoneyRecord> { userMoneyRecord });
        _unitOfWorkMock.SetupGet(u => u.UserMoneyRecords).Returns(userMoneyRecordsMock.Object);
        var moneyRecordsMock = new Mock<IGenericRepository<MoneyRecord>>();
        moneyRecordsMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<MoneyRecord, bool>>>(), null, null))
                        .ReturnsAsync(new List<MoneyRecord> { moneyRecord });
        _unitOfWorkMock.SetupGet(u => u.MoneyRecords).Returns(moneyRecordsMock.Object);

        // Act
        var result = await _service.GetAllUsersMoneyRecords(_user);

        // Assert
        userMoneyRecordsMock.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<UserMoneyRecord, bool>>>(), null, null), Times.Once());
        moneyRecordsMock.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<MoneyRecord, bool>>>(), null, null), Times.Once());
        Assert.AreEqual(result.First().Id, moneyRecord.Id);
    }

    [Test]
    public async Task GetMoneyRecord_ShouldReturnMoneyRecord()
    {
        // Arrange
        var moneyRecord = new MoneyRecord { Id = 1 };
        var moneyRecordsMock = new Mock<IGenericRepository<MoneyRecord>>();
        moneyRecordsMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<MoneyRecord, bool>>>(), null))
                        .ReturnsAsync(moneyRecord);
        _unitOfWorkMock.SetupGet(u => u.MoneyRecords).Returns(moneyRecordsMock.Object);

        // Act
        var result = await _service.GetMoneyRecord(moneyRecord.Id);

        // Assert
        moneyRecordsMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<MoneyRecord, bool>>>(), null), Times.Once());
        Assert.AreEqual(result, moneyRecord);
    }
}