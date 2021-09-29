using AutoMapper;
using RollCall.Dto;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace RollCall.BusinessLayer.Mappers
{
	public class AreaMapper
	{
		internal static List<AreaDto> GetAll(List<Area> entities)
		{
			try
			{
				List<AreaDto> list;
				IMapper mapper;

				mapper = GetMapperToDtos();
				list = mapper.Map<List<AreaDto>>(entities);

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

			configuration = new MapperConfiguration(x => x.CreateMap<Area, AreaDto>());
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static Area Get(AreaDto dto)
		{
			try
			{
				Area entity;
				IMapper mapper;

				mapper = GetMapperToEntities();
				entity = mapper.Map<Area>(dto);

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

			configuration = new MapperConfiguration(x => x.CreateMap<AreaDto, Area>());
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static AreaDto Get(Area entity)
		{
			AreaDto dto;
			IMapper mapper;

			mapper = GetMapperToDtos();
			dto = mapper.Map<AreaDto>(entity);
			
			return dto;
		}
	}
}
