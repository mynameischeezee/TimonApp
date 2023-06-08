using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Timon.Maui.Properties
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            this.Configure();
        }

        private void Configure()
        {
            CreateMap<DataAccess.Models.User, Business.Dto.User>().ReverseMap();
            CreateMap<DataAccess.Models.Category, Business.Dto.Category>().ReverseMap();
            CreateMap<DataAccess.Models.MoneyRecord, Business.Dto.MoneyRecord>().ReverseMap();
            CreateMap<DataAccess.Models.UserMoneyRecord, Business.Dto.UserMoneyRecord>().ReverseMap();
            CreateMap<DataAccess.Models.TimeRecord, Business.Dto.TimeRecord>().ReverseMap();
            CreateMap<DataAccess.Models.UserTimeRecord, Business.Dto.UserTimeRecord>().ReverseMap();
        }
    }
}
