using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.TimeRecord;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class EditTimeRecordViewModel : ObservableObject
    {
        private readonly ITimeRecordService _timeRecordService;

        public EditTimeRecordViewModel(ITimeRecordService timeRecordService)
        {
            _timeRecordService = timeRecordService;
        }
    }
}
