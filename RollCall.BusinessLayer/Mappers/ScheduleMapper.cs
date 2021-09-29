using AutoMapper;
using RollCall.Dto;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace RollCall.BusinessLayer.Mappers
{
	internal class ScheduleMapper
	{
		internal static List<ScheduleDto> GetAll(List<Schedule> entities)
		{
			try
			{
				List<ScheduleDto> list;
				IMapper mapper;

				mapper = GetMapperToDtos();
				list = mapper.Map<List<ScheduleDto>>(entities);

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

			configuration = new MapperConfiguration(x => x.CreateMap<Schedule, ScheduleDto>());
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static ScheduleDto Get(Schedule entity)
		{
			ScheduleDto dto;
			IMapper mapper;

			mapper = GetMapperToDtos();
			dto = mapper.Map<ScheduleDto>(entity);

			return dto;
		}

		internal static Schedule Get(ScheduleDto dto)
		{
			try
			{
				Schedule entity;
				IMapper mapper;

				mapper = GetMapperToEntities();
				entity = mapper.Map<Schedule>(dto);

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

			configuration = new MapperConfiguration(x => x.CreateMap<ScheduleDto, Schedule>());
			mapper = configuration.CreateMapper();

			return mapper;
		}
	}
}
