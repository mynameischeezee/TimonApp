using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.MoneyRecord;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class MoneyRecordsViewModel : ObservableObject
    {
        private readonly IMoneyRecordService _moneyRecordService;

        public MoneyRecordsViewModel(IMoneyRecordService moneyRecordService)
        {
            _moneyRecordService = moneyRecordService;
        }
    }
}
