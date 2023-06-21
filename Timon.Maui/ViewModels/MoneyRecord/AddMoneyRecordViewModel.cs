using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.MoneyRecord;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class AddMoneyRecordViewModel : ObservableValidator
    {
        [Required(ErrorMessage = "Name is Required Field!")]
        [MinLength(5, ErrorMessage = "Name length is minimum 5!")]
        [MaxLength(15, ErrorMessage = "Name length is maximum 15!")]
        [ObservableProperty]
        private string _name;

        [MaxLength(15, ErrorMessage = "Text length is maximum 15!")]
        [ObservableProperty]
        private string _description;

        [Required(ErrorMessage = "Date is required Field!")]
        [ObservableProperty]
        private DateTime _selectedDate;

        [Required(ErrorMessage = "Amount is required Field!")]
        [Range(1,int.MaxValue, ErrorMessage = "Please enter valid amount")]
        [ObservableProperty]
        private int _amount;

        [ObservableProperty]
        private ObservableCollection<Category> _categories = new();

        [Required(ErrorMessage = "Category is required Field!")]
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
        private async void GetLastTransactionFromPlaid()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var moneyRecord = await _moneyRecordService.GetMoneyRecordFromPlaid(user!);
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
