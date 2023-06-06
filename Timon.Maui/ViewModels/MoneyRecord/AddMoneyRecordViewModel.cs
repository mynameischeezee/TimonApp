using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.MoneyRecord;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class AddMoneyRecordViewModel : ObservableObject
    {
        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, User> _moneyRecordService;

        public AddMoneyRecordViewModel(IMoneyRecordService<DataAccess.Models.MoneyRecord, User> moneyRecordService)
        {
            _moneyRecordService = moneyRecordService;
        }
    }
}
