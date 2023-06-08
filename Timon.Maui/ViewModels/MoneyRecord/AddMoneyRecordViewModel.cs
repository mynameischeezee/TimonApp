using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Timon.Abstract.Services.MoneyRecord;
using Timon.DataAccess.Models;

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
        private ObservableCollection<string> _categories = new();

        [ObservableProperty] 
        private string _selectedCategory;

        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, User> _moneyRecordService;

        public AddMoneyRecordViewModel(IMoneyRecordService<DataAccess.Models.MoneyRecord, User> moneyRecordService)
        {
            _moneyRecordService = moneyRecordService;
        }

        [RelayCommand]
        private async void Save()
        {
            var moneyRecord = new DataAccess.Models.MoneyRecord()
            {

            }
            await _moneyRecordService.CreateMoneyRecord();
        }

        [RelayCommand]
        private async void GetLastTransactionFromBank()
        {

        }

        [RelayCommand]
        private async void NavigateToCategoryCreation()
        {

        }

        public void Update()
        {

        }
    }
}
