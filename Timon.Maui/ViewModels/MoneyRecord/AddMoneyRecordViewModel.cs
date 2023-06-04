using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.MoneyRecord;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class AddMoneyRecordViewModel : ObservableObject
    {
        private readonly IMoneyRecordService _moneyRecordService;

        public AddMoneyRecordViewModel(IMoneyRecordService moneyRecordService)
        {
            _moneyRecordService = moneyRecordService;
        }
    }
}
