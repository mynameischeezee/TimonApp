using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.TimeRecord;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class TimeRecordsViewModel : ObservableObject
    {
        private readonly ITimeRecordService _timeRecordService;

        public TimeRecordsViewModel(ITimeRecordService timeRecordService)
        {
            _timeRecordService = timeRecordService;
        }
    }
}
