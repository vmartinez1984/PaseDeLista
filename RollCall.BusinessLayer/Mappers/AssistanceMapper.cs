using AutoMapper;
using RollCall.Dto;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace RollCall.BusinessLayer.Mappers
{
	public class AssistanceMapper
	{
		internal static List<AssistanceDto> GetAll(List<AssistanceLog> entities)
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

			configuration = new MapperConfiguration(x => x.CreateMap<AssistanceLog, AssistanceDto>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Employee.Name))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Employee.LastName))
				.ForMember(dest => dest.EmployeeNumber, opt => opt.MapFrom(src => src.Employee.EmployeeNumber))	
			);
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static AssistanceLog Get(AssistanceDto dto)
		{
			try
			{
				AssistanceLog entity;
				IMapper mapper;

				mapper = GetMapperToEntities();
				entity = mapper.Map<AssistanceLog>(dto);

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

			configuration = new MapperConfiguration(x => x.CreateMap<AssistanceDto, AssistanceLog>());
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static AssistanceDto Get(AssistanceLog entity)
		{
			AssistanceDto dto;
			IMapper mapper;

			mapper = GetMapperToDtos();
			dto = mapper.Map<AssistanceDto>(entity);
			
			return dto;
		}
	}
}
