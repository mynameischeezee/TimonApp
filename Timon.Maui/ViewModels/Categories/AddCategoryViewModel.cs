using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.Categories;

public partial class AddCategoryViewModel : ObservableObject
{
    [ObservableProperty]
    private int _categoryPriority;

    [ObservableProperty]
    private string _categoryName;

    private readonly ICategoryService<Category, User> _categoryService;
    private readonly IUserService<User> _userService;

    public AddCategoryViewModel(ICategoryService<Category, User> categoryService, IUserService<User> userService)
    {
        _categoryService = categoryService;
        _userService = userService;
    }

    [RelayCommand]
    private async void SaveCategory()
    {
        var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
        var category = new Category()
        {
            UserId = user!.Id,
            Name = CategoryName,
            Priority = CategoryPriority,
        };
        await _categoryService.CreateCategory(user!, category);
        await Shell.Current.GoToAsync("../");
    }
}