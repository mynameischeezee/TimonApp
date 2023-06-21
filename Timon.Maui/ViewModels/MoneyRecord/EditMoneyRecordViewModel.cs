using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.MoneyRecord;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class EditMoneyRecordViewModel : ObservableValidator
    {
        [Required(ErrorMessage = "Name is Required Field!")]
        [MinLength(5, ErrorMessage = "Name length is minimum 5!")]
        [MaxLength(15, ErrorMessage = "Name length is maximum 15!")]
        [ObservableProperty]
        private string _name;

        [ObservableProperty] private string _nameError;
        [ObservableProperty] private bool _isNameValid;

        [MaxLength(15, ErrorMessage = "Text length is maximum 15!")]
        [ObservableProperty]
        private string _description;

        [ObservableProperty] private string _descriptionError;
        [ObservableProperty] private bool _isDescriptionValid;

        [Required(ErrorMessage = "Date is required Field!")]
        [ObservableProperty]
        private DateTime _selectedDate;

        [ObservableProperty] private string _selectedDateError;
        [ObservableProperty] private bool _isSelectedDateValid;

        [Required(ErrorMessage = "Amount is required Field!")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid amount")]
        [ObservableProperty]
        private int _amount;

        [ObservableProperty] private string _amountError;
        [ObservableProperty] private bool _isAmountValid;

        [ObservableProperty]
        private ObservableCollection<Category> _categories = new();

        [Required(ErrorMessage = "Category is required Field!")]
        [ObservableProperty]
        private Category _selectedCategory;

        [ObservableProperty] private string _selectedCategoryError;
        [ObservableProperty] private bool _isSelectedCategoryValid;

        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, User> _moneyRecordService;
        private readonly IUserService<User> _userService;
        private readonly ICategoryService<Category, User> _categoryService;

        public EditMoneyRecordViewModel(IMoneyRecordService<DataAccess.Models.MoneyRecord, User> moneyRecordService,
            IUserService<User> userService, ICategoryService<Category, User> categoryService)
        {
            _moneyRecordService = moneyRecordService;
            _userService = userService;
            _categoryService = categoryService;
        }

        [RelayCommand]
        private async void SaveMoneyRecord()
        {
            Validate();
            if (HasErrors) return;
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

        [RelayCommand]
        void Validate()
        {
            ValidateAllProperties();

            if (HasErrors)
            {
                IsNameValid =
                    (GetErrors().ToDictionary(k => k.MemberNames.First(), v => v.ErrorMessage) ??
                     new Dictionary<string, string?>()).TryGetValue(nameof(Name), out var error);
            }


        }

        public async void Update()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var categories = await _categoryService.GetAllUsersCategories(user!);
            var moneyRecord = await _moneyRecordService.GetMoneyRecord(CurrentSession.CurrentMoneyRecord!);
            Categories = new ObservableCollection<Category>(categories);
            Name = moneyRecord!.Name;
            SelectedDate = moneyRecord.Date;
            Amount = moneyRecord.Amount;
            Description = moneyRecord.Description!;
            SelectedCategory = Categories.First(x => x.Id == moneyRecord.CategoryId);
        }
    }
}
