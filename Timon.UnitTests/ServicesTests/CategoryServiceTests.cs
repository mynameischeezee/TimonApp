using Timon.Abstract.DataAccess.Repository;
using Timon.Business.Services.Categories;
using Timon.Business.Services.TimeRecord;
using Timon.DataAccess.UnitOfWork;

namespace Timon.UnitTests.ServicesTests;

public class CategoryServiceTests
{
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private CategoryService _service;
    private User _user;
    private Category _record;

    [SetUp]
    public void Setup()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _service = new CategoryService(_unitOfWorkMock.Object);
        _user = new User { Id = 1 };
        _record = new Category { Id = 1 };
    }

    [Test]
    public async Task CreateCategory_ShouldCreateCategory()
    {
        // Arrange
        var category = new Category();
        _unitOfWorkMock.Setup(u => u.Category.Insert(It.IsAny<Category>()));
        _unitOfWorkMock.Setup(u => u.Save())
                       .Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateCategory(_user, category);

        // Assert
        _unitOfWorkMock.Verify(u => u.Category.Insert(It.IsAny<Category>()), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Once());
        Assert.AreEqual(result, category);
    }

    [Test]
    public async Task DeleteCategory_ShouldDeleteCategory()
    {
        // Arrange
        var category = new Category { Id = 1 };
        _unitOfWorkMock.Setup(u => u.Category.Delete(category.Id));
        _unitOfWorkMock.Setup(u => u.Save())
                       .Returns(Task.CompletedTask);

        // Act
        var result = await _service.DeleteCategory(category);

        // Assert
        _unitOfWorkMock.Verify(u => u.Category.Delete(category.Id), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Once());
        Assert.AreEqual(result, category);
    }

    [Test]
    public async Task UpdateCategory_ShouldUpdateCategory()
    {
        // Arrange
        var category = new Category { Id = 1 };
        _unitOfWorkMock.Setup(u => u.Category.Update(category));
        _unitOfWorkMock.Setup(u => u.Save())
                       .Returns(Task.CompletedTask);

        // Act
        var result = await _service.UpdateCategory(category);

        // Assert
        _unitOfWorkMock.Verify(u => u.Category.Update(category), Times.Once());
        _unitOfWorkMock.Verify(u => u.Save(), Times.Once());
        Assert.AreEqual(result, category);
    }

    [Test]
    public async Task GetAllUsersCategories_ShouldReturnAllUsersCategories()
    {
        // Arrange
        var category = new Category { UserId = _user.Id };
        var categoriesMock = new Mock<IGenericRepository<Category>>();
        categoriesMock.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Category, bool>>>(), null, null))
                      .ReturnsAsync(new List<Category> { category });
        _unitOfWorkMock.SetupGet(u => u.Category).Returns(categoriesMock.Object);

        // Act
        var result = await _service.GetAllUsersCategories(_user);

        // Assert
        categoriesMock.Verify(repo => repo.GetAll(It.IsAny<Expression<Func<Category, bool>>>(), null, null), Times.Exactly(2));
        Assert.AreEqual(result.First().Id, category.Id);
    }

    [Test]
    public async Task GetCategory_ShouldReturnCategory()
    {
        // Arrange
        var category = new Category { Id = 1 };
        var categoriesMock = new Mock<IGenericRepository<Category>>();
        categoriesMock.Setup(repo => repo.Get(It.IsAny<Expression<Func<Category, bool>>>(), null))
                      .ReturnsAsync(category);
        _unitOfWorkMock.SetupGet(u => u.Category).Returns(categoriesMock.Object);

        // Act
        var result = await _service.GetCategory(category.Id);

        // Assert
        categoriesMock.Verify(repo => repo.Get(It.IsAny<Expression<Func<Category, bool>>>(), null), Times.Once());
        Assert.AreEqual(result, category);
    }

}