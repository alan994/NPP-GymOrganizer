using AutoMapper;
using GymOrganizer.Data.Model;
using GymOrganizer.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymOrganizer.Web.Utils
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<User, UserVM>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(x => (int)x.Type))
                .ReverseMap();

                config.CreateMap<Schedule, ScheduleVM>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(x => x.User))
                .ReverseMap();
            });
        }
    }
}
