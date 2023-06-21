using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.TimeRecord;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class EditTimeRecordViewModel : ObservableValidator
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

        [Required(ErrorMessage = "Time from is required Field!")]
        [ObservableProperty]
        private TimeSpan _timeFrom;

        [Required(ErrorMessage = "Time to is required Field!")]
        [ObservableProperty]
        private TimeSpan _timeTo;

        [ObservableProperty]
        private ObservableCollection<Category> _categories = new();

        [Required(ErrorMessage = "Category is required Field!")]
        [ObservableProperty]
        private Category _selectedCategory;

        private readonly ITimeRecordService<DataAccess.Models.TimeRecord, User> _timeRecordService;
        private readonly IUserService<DataAccess.Models.User> _userService;
        private readonly ICategoryService<DataAccess.Models.Category, DataAccess.Models.User> _categoryService;

        public EditTimeRecordViewModel(ITimeRecordService<DataAccess.Models.TimeRecord, User> timeRecordService,
            IUserService<User> userService,
            ICategoryService<Category, User> categoryService)
        {
            _timeRecordService = timeRecordService;
            _userService = userService;
            _categoryService = categoryService;
        }
        [RelayCommand]
        private async void SaveTimeRecord()
        {
            ValidateAllProperties();
            if (HasErrors) return;
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var timeRecord = await _timeRecordService.GetTimeRecord(CurrentSession.CurrentTimeRecord!);
            timeRecord!.Name = Name;
            timeRecord.DateFrom = SelectedDate.Date + TimeFrom;
            timeRecord.DateTo = SelectedDate.Date + TimeTo;
            timeRecord.Description = this.Description;
            timeRecord.CategoryId = SelectedCategory.Id;
            await _timeRecordService.UpdateTimeRecord(timeRecord);
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        private async void DeleteTimeRecord()
        {
            var timeRecord = await _timeRecordService.GetTimeRecord(CurrentSession.CurrentTimeRecord!);
            await _timeRecordService.DeleteTimeRecord(timeRecord!);
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
        }

        public async void Update()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var categories = await _categoryService.GetAllUsersCategories(user!);
            var timeRecord = await _timeRecordService.GetTimeRecord(CurrentSession.CurrentTimeRecord!);
            Categories = new ObservableCollection<DataAccess.Models.Category>(categories);
            Name = timeRecord!.Name;
            SelectedDate = timeRecord.DateFrom.Date;
            TimeFrom = timeRecord.DateFrom - timeRecord.DateFrom.Date;
            TimeTo = timeRecord.DateTo - timeRecord.DateTo.Date;
            Description = timeRecord.Description!;
            SelectedCategory = Categories.First(x => x.Id == timeRecord.CategoryId);
        }
    }
}
