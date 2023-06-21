using Timon.Abstract.DataAccess.Repository;
using Timon.Business.Services.TimeRecord;
using Timon.DataAccess.UnitOfWork;

namespace Timon.UnitTests.ServicesTests;

[TestFixture]
public class TimeRecordServiceTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private TimeRecordService _service;
    private User _user;
    private TimeRecord _record;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _service = new TimeRecordService(_unitOfWorkMock.Object);
        _user = new User { Id = 1 };
        _record = new TimeRecord { Id = 1 };
    }

    [Test]
    public async Task CreateTimeRecord_ShouldInsertTimeRecord()
    {
        // Arrange
        _unitOfWorkMock.Setup(u => u.TimeRecords.Insert(It.IsAny<TimeRecord>()))
                       .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.UserTimeRecords.Insert(It.IsAny<UserTimeRecord>()))
                       .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.Save())
                       .Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateTimeRecord(_user, _record);

        // Assert
        _unitOfWorkMock.Verify(u => u.TimeRecords.Insert(It.IsAny<TimeRecord>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.UserTimeRecords.Insert(It.IsAny<UserTimeRecord>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Exactly(2));
        Assert.AreEqual(result.Id, _record.Id);
    }

    [Test]
    public async Task DeleteTimeRecord_ShouldDeleteRecord()
    {
        // Arrange
        var userTimeRecord = new UserTimeRecord { Id = 1, TimeRecordId = _record.Id };

        var userTimeRecordsMock = new Mock<IGenericRepository<UserTimeRecord>>();
        userTimeRecordsMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<UserTimeRecord, bool>>>(), null))
            .ReturnsAsync(userTimeRecord);
        _unitOfWorkMock.SetupGet(u => u.UserTimeRecords).Returns(userTimeRecordsMock.Object);

        _unitOfWorkMock.Setup(u => u.UserTimeRecords.Delete(It.IsAny<int>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.TimeRecords.Delete(It.IsAny<int>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(u => u.Save())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _service.DeleteTimeRecord(_record);

        // Assert
        var actual = result.Id;
        var expected = _record.Id;
        userTimeRecordsMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<UserTimeRecord, bool>>>(), null), Times.Once());
        _unitOfWorkMock.Verify(u => u.UserTimeRecords.Delete(It.IsAny<int>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.TimeRecords.Delete(It.IsAny<int>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Once());

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public async Task UpdateTimeRecord_ShouldUpdateRecord()
    {
        // Arrange
        _unitOfWorkMock.Setup(u => u.TimeRecords.Update(It.IsAny<TimeRecord>()));
        _unitOfWorkMock.Setup(u => u.Save())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _service.UpdateTimeRecord(_record);

        // Assert
        _unitOfWorkMock.Verify(u => u.TimeRecords.Update(It.IsAny<TimeRecord>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Once());
        Assert.AreEqual(result.Id, _record.Id);
    }

    [Test]
    public async Task GetAllUsersTimeRecords_ShouldReturnUsersTimeRecords()
    {
        // Arrange
        var userTimeRecords = new List<UserTimeRecord>
        {
            new UserTimeRecord { UserId = _user.Id, TimeRecordId = _record.Id }
        };

        var userTimeRecordsMock = new Mock<IGenericRepository<UserTimeRecord>>();
        userTimeRecordsMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<UserTimeRecord, bool>>>(), null, null))
            .ReturnsAsync(userTimeRecords);
        _unitOfWorkMock.SetupGet(u => u.UserTimeRecords).Returns(userTimeRecordsMock.Object);

        var timeRecordsMock = new Mock<IGenericRepository<TimeRecord>>();
        timeRecordsMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<TimeRecord, bool>>>(), null, null))
            .ReturnsAsync(new List<TimeRecord> { _record });
        _unitOfWorkMock.SetupGet(u => u.TimeRecords).Returns(timeRecordsMock.Object);

        // Act
        var result = await _service.GetAllUsersTimeRecords(_user);

        // Assert
        var actual = _record.Id;
        var expected = result.First().Id;
        userTimeRecordsMock.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<UserTimeRecord, bool>>>(), null, null), Times.Once());
        timeRecordsMock.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<TimeRecord, bool>>>(), null, null), Times.Once());
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public async Task GetTimeRecord_ShouldReturnTimeRecord()
    {
        // Arrange
        var timeRecordsMock = new Mock<IGenericRepository<TimeRecord>>();
        timeRecordsMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<TimeRecord, bool>>>(), null))
            .ReturnsAsync(_record);
        _unitOfWorkMock.SetupGet(u => u.TimeRecords).Returns(timeRecordsMock.Object);

        // Act
        var result = await _service.GetTimeRecord(_record.Id);

        // Assert
        var expected = result.Id;
        var actual = _record.Id;
        timeRecordsMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<TimeRecord, bool>>>(), null), Times.Once());
        Assert.AreEqual(expected, actual);
    }

}