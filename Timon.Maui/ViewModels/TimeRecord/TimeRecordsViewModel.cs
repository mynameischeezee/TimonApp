﻿using CommunityToolkit.Mvvm.ComponentModel;
using Timon.Abstract.Services.TimeRecord;
using Timon.DataAccess.Models;

namespace Timon.Maui.ViewModels.TimeRecord
{
    public partial class TimeRecordsViewModel : ObservableObject
    {
        private readonly ITimeRecordService<DataAccess.Models.TimeRecord, User> _timeRecordService;

        public TimeRecordsViewModel(ITimeRecordService<DataAccess.Models.TimeRecord, User> timeRecordService)
        {
            _timeRecordService = timeRecordService;
        }
    }
}
