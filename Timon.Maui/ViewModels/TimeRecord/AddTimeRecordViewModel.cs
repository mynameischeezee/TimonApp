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
    public partial class AddTimeRecordViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private DateTime _selectedDate;

        [ObservableProperty]
        private DateTime _timeFrom;

        [ObservableProperty]
        private DateTime _timeTo;

        [ObservableProperty]
        private ObservableCollection<Category> _categories = new();

        [ObservableProperty]
        private Category _selectedCategory;

        private readonly ITimeRecordService<DataAccess.Models.TimeRecord, User> _timeRecordService;
        private readonly IUserService<DataAccess.Models.User> _userService;
        private readonly ICategoryService<DataAccess.Models.Category, DataAccess.Models.User> _categoryService;

        public AddTimeRecordViewModel(ITimeRecordService<DataAccess.Models.TimeRecord, User> timeRecordService,
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
            var timeRecord = new DataAccess.Models.TimeRecord()
            {
                Name = this.Name,
                Description = this.Description,
                DateFrom = SelectedDate.Date.Add(TimeSpan.FromHours(TimeFrom.Hour) + TimeSpan.FromMinutes(TimeFrom.Minute)),
                DateTo = SelectedDate.Date.Add(TimeSpan.FromHours(TimeTo.Hour) + TimeSpan.FromMinutes(TimeTo.Minute)),
                CategoryId = SelectedCategory.Id,
            };
            await _timeRecordService.CreateTimeRecord(user!, timeRecord);
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        private async void NavigateToNewCategoryCreation()
        {
            await Shell.Current.GoToAsync("Categories/addCategory");
        }

        public async void Update()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var categories = await _categoryService.GetAllUsersCategories(user!);
            Categories = new ObservableCollection<Category>(categories);
            TimeFrom = DateTime.Now;
            TimeTo = DateTime.Now;
            SelectedDate = DateTime.Now;
            SelectedCategory = Categories.First();
        }
    }
}
