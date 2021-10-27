using AutoMapper;
using RollCall.Dto;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace RollCall.BusinessLayer.Mappers
{
	public class EmployeeMapper
	{
		internal static List<EmployeeDto> GetAll(List<EmployeeEntity> entities)
		{
			try
			{
				List<EmployeeDto> list;
				IMapper mapper;

				mapper = GetMapperToDtos();
				list = mapper.Map<List<EmployeeDto>>(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		internal static IMapper GetMapperToDtos()
		{
			IMapper mapper;
			MapperConfiguration configuration;

			configuration = new MapperConfiguration(x =>
			{
				x.CreateMap<EmployeeEntity, EmployeeDto>();
				x.CreateMap<Area, AreaDto>();
				x.CreateMap<Schedule, ScheduleDto>();
				x.CreateMap<SecurityQuestion, SecurityQuestionDto>();
			});
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static EmployeeDto Get(EmployeeEntity entity)
		{
			try
			{
				EmployeeDto dto;
				IMapper mapper;

				mapper = GetMapperToDtos();
				dto = mapper.Map<EmployeeDto>(entity);

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		internal static EmployeeEntity Get(EmployeeDto dto)
		{
			try
			{
				EmployeeEntity entity;
				IMapper mapper;

				mapper = GetMapperToEntities();
				entity = mapper.Map<EmployeeEntity>(dto);

				return entity;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static IMapper GetMapperToEntities()
		{
			IMapper mapper;
			MapperConfiguration configuration;

			configuration = new MapperConfiguration(x =>
			{
				x.CreateMap<EmployeeDto, EmployeeEntity>();
				x.CreateMap<AreaDto, Area>();
				x.CreateMap<ScheduleDto, Schedule>();
				x.CreateMap<SecurityQuestionDto, SecurityQuestion>();
			});
			mapper = configuration.CreateMapper();

			return mapper;
		}
	}
}
