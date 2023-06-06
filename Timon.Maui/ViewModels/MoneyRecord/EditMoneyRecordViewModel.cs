using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.MoneyRecord;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.MoneyRecord
{
    public partial class EditMoneyRecordViewModel : ObservableObject
    {
        private readonly IMoneyRecordService<DataAccess.Models.MoneyRecord, User> _moneyRecordService;

        public EditMoneyRecordViewModel(IMoneyRecordService<DataAccess.Models.MoneyRecord, User> moneyRecordService)
        {
            _moneyRecordService = moneyRecordService;
        }
    }
}
