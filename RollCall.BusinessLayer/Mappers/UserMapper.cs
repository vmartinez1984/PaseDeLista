﻿using AutoMapper;
using RollCall.Dto;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer.Mappers
{
	public class UserMapper
	{
		internal static List<UserDto> GetAll(List<User> entities)
		{
			try
			{
				List<UserDto> list;
				IMapper mapper;

				mapper = GetMapperToDtos();
				list = mapper.Map<List<UserDto>>(entities);

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

			configuration = new MapperConfiguration(x => x.CreateMap<User, UserDto>());
			mapper = configuration.CreateMapper();

			return mapper;
		}

		internal static UserDto Get(User entity)
		{
			try
			{
				UserDto dto;
				IMapper mapper;

				mapper = GetMapperToDtos();
				dto = mapper.Map<UserDto>(entity);

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		internal static User Get(UserDto dto)
		{
			try
			{
				User entity;
				IMapper mapper;

				mapper = GetMapperToEntities();
				entity = mapper.Map<User>(dto);

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

			configuration = new MapperConfiguration(x => x.CreateMap<UserDto, User>());
			mapper = configuration.CreateMapper();

			return mapper;
		}
	}
}
