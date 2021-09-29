using AutoMapper;
using RollCall.Dto;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace RollCall.BusinessLayer.Mappers
{
	public class AssistanceMapper
	{
		internal static List<AssistanceDto> GetAll(List<Assistance> entities)
		{
			try
			{
				List<AssistanceDto> list;
				IMapper mapper;

				mapper = GetMapperToDtos();
				list = mapper.Map<List<AssistanceDto>>(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static IMapper GetMapperToDtos()
		{
			IMapper mapper;
			MapperConfiguration configuration;

			configuration = new MapperConfiguration(x => x.CreateMap<Assistance, AssistanceDto>());
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static Assistance Get(AssistanceDto dto)
		{
			try
			{
				Assistance entity;
				IMapper mapper;

				mapper = GetMapperToEntities();
				entity = mapper.Map<Assistance>(dto);

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

			configuration = new MapperConfiguration(x => x.CreateMap<AssistanceDto, Assistance>());
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static AssistanceDto Get(Assistance entity)
		{
			AssistanceDto dto;
			IMapper mapper;

			mapper = GetMapperToDtos();
			dto = mapper.Map<AssistanceDto>(entity);
			
			return dto;
		}
	}
}
