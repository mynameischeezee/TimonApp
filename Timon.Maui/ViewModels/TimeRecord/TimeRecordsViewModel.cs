using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Timon.Abstract.Services.TimeRecord;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class TimeRecordsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<DataAccess.Models.TimeRecord> _timeRecords;

        private readonly ITimeRecordService<DataAccess.Models.TimeRecord, User> _timeRecordService;
        private readonly IUserService<DataAccess.Models.User> _userService;

        public TimeRecordsViewModel(ITimeRecordService<DataAccess.Models.TimeRecord, User> timeRecordService,
            IUserService<DataAccess.Models.User> userService)
        {
            _timeRecordService = timeRecordService;
            _userService = userService;
        }

        [RelayCommand]
        private async void NavigateToDetails(int id)
        {
            CurrentSession.CurrentTimeRecord = id;
            await Shell.Current.GoToAsync("TimeRecord/editTimeRecord");
        }

        [RelayCommand]
        private async void AddNewTimeRecord()
        {
            await Shell.Current.GoToAsync("TimeRecord/addTimeRecord");
        }

        public async void Update()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var timeRecords = await _timeRecordService.GetAllUsersTimeRecords(user!);
            TimeRecords = new ObservableCollection<DataAccess.Models.TimeRecord>(timeRecords);
        }
    }
}
