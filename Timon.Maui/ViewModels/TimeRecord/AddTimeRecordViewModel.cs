using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Timon.Abstract.Services.Categories;
using Timon.Abstract.Services.TimeRecord;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class AddTimeRecordViewModel : ObservableValidator
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
                DateFrom = SelectedDate.Date + TimeFrom,
                DateTo = SelectedDate.Date + TimeTo,
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
            TimeFrom = TimeSpan.Zero;
            TimeTo = TimeSpan.Zero;
            SelectedDate = DateTime.Now;
            SelectedCategory = Categories.First();
        }
    }
}
