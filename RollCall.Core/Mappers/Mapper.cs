using AutoMapper;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Entities;

namespace RollCall.Core.Mappers
{
    public class AreaMapper : Profile
    {
        public AreaMapper()
        {
            CreateMap<AreaDtoIn, AreaEntity>().ReverseMap();
            CreateMap<AreaDtoOut, AreaEntity>().ReverseMap();
        }
    }

    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeeDto, EmployeeEntity>().ReverseMap();
            CreateMap<EmployeeDtoIn, EmployeeEntity>().ReverseMap();
        }
    }

    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserDtoIn, UserEntity>();
            CreateMap<UserLoginDto, UserEntity>();
        }
    }

    public class ScheduleMapper : Profile
    {
        public ScheduleMapper()
        {
            CreateMap<ScheduleEntity, ScheduleDto>();
            CreateMap<ScheduleDtoIn, ScheduleEntity>();
        }
    }

    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<RolEntity, RolDto>();
        }
    }
    
}//end namespace