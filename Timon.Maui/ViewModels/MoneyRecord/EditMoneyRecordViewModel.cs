using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.MoneyRecord;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class EditMoneyRecordViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private DateTime _selectedDate;

        [ObservableProperty]
        private int _amount;

        [ObservableProperty]
        private ObservableCollection<DataAccess.Models.Category> _categories = new();

        [ObservableProperty]
        private DataAccess.Models.Category _selectedCategory;

        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, DataAccess.Models.User> _moneyRecordService;
        private readonly IUserService<DataAccess.Models.User> _userService;
        private readonly ICategoryService<DataAccess.Models.Category, DataAccess.Models.User> _categoryService;

        public EditMoneyRecordViewModel(IMoneyRecordService<DataAccess.Models.MoneyRecord, User> moneyRecordService,
            IUserService<User> userService, ICategoryService<Category, User> categoryService)
        {
            _moneyRecordService = moneyRecordService;
            _userService = userService;
            _categoryService = categoryService;
            Update();
        }

        [RelayCommand]
        private async void SaveMoneyRecord()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var moneyRecord = await _moneyRecordService.GetMoneyRecord(CurrentSession.CurrentMoneyRecord!);
            moneyRecord!.Name = Name;
            moneyRecord.Date = SelectedDate;
            moneyRecord.Amount = Amount;
            moneyRecord.Description = Description;
            moneyRecord.CategoryId = SelectedCategory.Id;
            await _moneyRecordService.UpdateMoneyRecord(moneyRecord);
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        private async void DeleteMoneyRecord()
        {
            var moneyRecord = await _moneyRecordService.GetMoneyRecord(CurrentSession.CurrentMoneyRecord!);
            await _moneyRecordService.DeleteMoneyRecord(moneyRecord!);
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        private async void NavigateToCategoryCreation()
        {
            await Shell.Current.GoToAsync("Categories/addCategory");
        }

        public async void Update()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var categories = await _categoryService.GetAllUsersCategories(user!);
            var moneyRecord = await _moneyRecordService.GetMoneyRecord(CurrentSession.CurrentMoneyRecord!);
            Categories = new ObservableCollection<DataAccess.Models.Category>(categories);
            Name = moneyRecord!.Name;
            SelectedDate = moneyRecord.Date;
            Amount = moneyRecord.Amount;
            Description = moneyRecord.Description!;
            SelectedCategory = Categories.First(x => x.Id == moneyRecord.CategoryId);
        }
    }
}
