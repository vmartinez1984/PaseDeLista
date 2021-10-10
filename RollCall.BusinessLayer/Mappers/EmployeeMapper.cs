using AutoMapper;
using RollCall.Dto;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace RollCall.BusinessLayer.Mappers
{
	public class EmployeeMapper
	{
		internal static List<EmployeeDto> GetAll(List<Employee> entities)
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

			configuration = new MapperConfiguration(x => {
				x.CreateMap<Employee, EmployeeDto>();
				x.CreateMap<Area, AreaDto>();
				x.CreateMap<Schedule, ScheduleDto>();
				x.CreateMap<SecurityQuestion, SecurityQuestionDto>();
			});
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static EmployeeDto Get(Employee entity)
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

		internal static Employee Get(EmployeeDto dto)
		{
			try
			{
				Employee entity;
				IMapper mapper;

				mapper = GetMapperToEntities();
				entity = mapper.Map<Employee>(dto);

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

			configuration = new MapperConfiguration(x => x.CreateMap<EmployeeDto, Employee>());
			mapper = configuration.CreateMapper();

			return mapper;
		}
	}
}
