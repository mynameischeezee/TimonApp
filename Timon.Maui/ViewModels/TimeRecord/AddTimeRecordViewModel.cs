using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.TimeRecord;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class AddTimeRecordViewModel : ObservableObject
    {
        private readonly ITimeRecordService _timeRecordService;

        public AddTimeRecordViewModel(ITimeRecordService timeRecordService)
        {
            _timeRecordService = timeRecordService;
        }
    }
}
