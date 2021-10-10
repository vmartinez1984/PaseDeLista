using AutoMapper;
using RollCall.Dto;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace RollCall.BusinessLayer.Mappers
{
	internal class SecurityQuestionMapper
	{
		internal static List<SecurityQuestionDto> GetAll(List<SecurityQuestion> entities)
		{
			try
			{
				List<SecurityQuestionDto> list;
				IMapper mapper;

				mapper = GetMapperToDtos();
				list = mapper.Map<List<SecurityQuestionDto>>(entities);

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

			configuration = new MapperConfiguration(x => x.CreateMap<SecurityQuestion, SecurityQuestionDto>());
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static SecurityQuestionDto Get(SecurityQuestion entity)
		{
			try
			{
				SecurityQuestionDto dto;
				IMapper mapper;

				mapper = GetMapperToDtos();
				dto = mapper.Map<SecurityQuestionDto>(entity);

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		internal static SecurityQuestion Get(SecurityQuestionDto dto)
		{
			try
			{
				SecurityQuestion entity;
				IMapper mapper;

				mapper = GetMapperToEntities();
				entity = mapper.Map<SecurityQuestion>(dto);

				return entity;
			}
			catch (Exception)
			{

				throw;
			}
		}

		internal static IMapper GetMapperToEntities()
		{
			IMapper mapper;
			MapperConfiguration configuration;

			configuration = new MapperConfiguration(x => x.CreateMap<SecurityQuestionDto, SecurityQuestion>());
			mapper = configuration.CreateMapper();

			return mapper;
		}
	}
}
