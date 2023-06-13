using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.TimeRecord;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class EditTimeRecordViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private DateTime _selectedDate;

        [ObservableProperty]
        private TimeSpan _timeFrom;

        [ObservableProperty]
        private TimeSpan _timeTo;

        [ObservableProperty]
        private ObservableCollection<Category> _categories = new();

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
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var timeRecord = await _timeRecordService.GetTimeRecord(CurrentSession.CurrentTimeRecord!);
            timeRecord!.Name = this.Name;
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
