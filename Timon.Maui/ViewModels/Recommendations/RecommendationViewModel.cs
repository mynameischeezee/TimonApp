using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.Services.Recommendations;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.Recommendations;

public partial class RecommendationViewModel : ObservableObject
{
    [ObservableProperty]
    private string _userName;

    [ObservableProperty] 
    private string _worstCategories;

    [ObservableProperty] 
    private string _worstMoneyCategory;

    [ObservableProperty]
    private string _worstTimeCategory;

    private readonly IUserService<User> _userService;
    private readonly IRecommendationsService<User> _recommendationsService;  
    public RecommendationViewModel(IRecommendationsService<User> recommendationsService, IUserService<User> userService)
    {
        _recommendationsService = recommendationsService;
        _userService = userService;
    }

    public async void Update()
    {
        var currentUserNickName = CurrentSession.CurrentUserNickname!;
        UserName = currentUserNickName;
        var user = await _userService.GetUserByNickname(currentUserNickName);
        var worstCategories = (await _recommendationsService.GetTwoWorstCategoriesNames(user!)).ToList();
        WorstCategories = $"{worstCategories[0]} and {worstCategories[1]}.";
        WorstTimeCategory = $"{worstCategories[0]} category.";
        WorstMoneyCategory = $"{worstCategories[1]} category.";
    }
}