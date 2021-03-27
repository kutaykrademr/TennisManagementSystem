using AutoMapper;

using Helpers;
using TennisManagementSystemApi.Models;

namespace TennisManagementSystemApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationLog, ApplicationLogsDto>();
            CreateMap<ApplicationLogsDto, ApplicationLog>();

            CreateMap<ErrorLog, ErrorLogsDto>();
            CreateMap<ErrorLogsDto, ErrorLog>();


            CreateMap<QueryLog, QueryLogsDto>();
            CreateMap<QueryLogsDto, QueryLog>();

            CreateMap<UserLog, UserLogsDto>();
            CreateMap<UserLogsDto, UserLog>();

        }
    }
}
