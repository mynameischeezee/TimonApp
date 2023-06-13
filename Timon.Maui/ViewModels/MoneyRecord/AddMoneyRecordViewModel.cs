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
    public partial class AddMoneyRecordViewModel : ObservableObject
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
        private ObservableCollection<Category> _categories = new();

        [ObservableProperty]
        private Category _selectedCategory;

        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, User> _moneyRecordService;
        private readonly IUserService<DataAccess.Models.User> _userService;
        private readonly ICategoryService<DataAccess.Models.Category, DataAccess.Models.User> _categoryService;

        public AddMoneyRecordViewModel(IMoneyRecordService<DataAccess.Models.MoneyRecord,
            User> moneyRecordService, IUserService<User> userService, ICategoryService<Category, User> categoryService)
        {
            _moneyRecordService = moneyRecordService;
            _userService = userService;
            _categoryService = categoryService;
        }

        [RelayCommand]
        private async void SaveMoneyRecord()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var moneyRecord = new DataAccess.Models.MoneyRecord()
            {
                Name = this.Name,
                Description = this.Description,
                Amount = this.Amount,
                Date = this.SelectedDate,
                CategoryId = this.SelectedCategory.Id
            };
            await _moneyRecordService.CreateMoneyRecord(user!, moneyRecord);
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        private async void GetLastTransactionFromBank()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var moneyRecord = await _moneyRecordService.GetLastTransactionFromBank(user!);
            Name = moneyRecord.Name;
            Description = moneyRecord.Description!;
            Amount = moneyRecord.Amount;
            SelectedDate = moneyRecord.Date;
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
            Categories = new ObservableCollection<Category>(categories);
            SelectedCategory = Categories.First();
            SelectedDate = DateTime.Now;
        }
    }
}
