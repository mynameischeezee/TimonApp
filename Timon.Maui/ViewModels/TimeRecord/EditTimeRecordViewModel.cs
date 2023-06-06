using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.TimeRecord;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class EditTimeRecordViewModel : ObservableObject
    {
        private readonly ITimeRecordService<DataAccess.Models.TimeRecord, User> _timeRecordService;

        public EditTimeRecordViewModel(ITimeRecordService<DataAccess.Models.TimeRecord, User> timeRecordService)
        {
            _timeRecordService = timeRecordService;
        }
    }
}
