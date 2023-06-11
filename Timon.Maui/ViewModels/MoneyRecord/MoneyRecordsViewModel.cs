using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.Services.MoneyRecord;
using Timon.Abstract.Services.User;
using Timon.DataAccess.Models;
using Timon.Maui.Properties;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class MoneyRecordsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<DataAccess.Models.MoneyRecord> _moneyRecords;

        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, User> _moneyRecordService;
        private readonly IUserService<DataAccess.Models.User> _userService;

        public MoneyRecordsViewModel(IMoneyRecordService<DataAccess.Models.MoneyRecord, User> moneyRecordService, IUserService<User> userService)
        {
            _moneyRecordService = moneyRecordService;
            _userService = userService;
        }

        [RelayCommand]
        private async void NavigateToDetails(int id)
        {
            CurrentSession.CurrentMoneyRecord = id;
            await Shell.Current.GoToAsync("MoneyRecord/editMoneyRecord");
        }

        [RelayCommand]
        private async void AddNewMoneyRecord()
        {
            await Shell.Current.GoToAsync("MoneyRecord/addMoneyRecord");
        }

        public async void Update()
        {
            var user = await _userService.GetUserByNickname(CurrentSession.CurrentUserNickname!);
            var moneyRecords = await _moneyRecordService.GetAllUsersMoneyRecords(user!);
            MoneyRecords = new ObservableCollection<DataAccess.Models.MoneyRecord>(moneyRecords);
        }
    }
}
