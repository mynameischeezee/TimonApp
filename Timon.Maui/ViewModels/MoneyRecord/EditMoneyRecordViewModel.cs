using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.MoneyRecord;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class EditMoneyRecordViewModel : ObservableObject
    {
        private readonly IMoneyRecordService _moneyRecordService;

        public EditMoneyRecordViewModel(IMoneyRecordService moneyRecordService)
        {
            _moneyRecordService = moneyRecordService;
        }
    }
}
