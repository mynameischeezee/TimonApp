using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.Services.MoneyRecord;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class MoneyRecordsViewModel : ObservableObject
    {
        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, User> _moneyRecordService;

        public MoneyRecordsViewModel(IMoneyRecordService<DataAccess.Models.MoneyRecord, User> moneyRecordService)
        {
            _moneyRecordService = moneyRecordService;
        }
    }
}
