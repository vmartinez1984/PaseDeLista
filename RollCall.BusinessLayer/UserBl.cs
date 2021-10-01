using RollCall.BusinessLayer.Mappers;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public class UserBl
	{
		public static async Task<List<UserDto>> GetAllAsync(bool isActive = true)
		{
			try
			{
				List<UserDto> list;
				List<User> entities;

				entities = await UserDao.GetAllAsync(isActive);
				list = UserMapper.GetAll(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<UserDto> GetAsync(int id)
		{
			try
			{
				UserDto item;
				User entity;

				entity = await UserDao.GetAsync(id);
				item = UserMapper.Get(entity);

				return item;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> AddAsync(UserDto dto)
		{
			try
			{
				User entity;

				entity = UserMapper.Get(dto);
				await UserDao.AddAsync(entity);

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task UpdateAsync(UserDto dto)
		{
			try
			{
				User entity;

				entity = UserMapper.Get(dto);
				await UserDao.UpdateAsync(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<UserDto> LoginAsync(UserLoginDto userLoginDto)
		{
			try
			{
				UserDto dto;
				User entity;

				entity = await UserDao.Login(userLoginDto.Email, userLoginDto.Password);
				if (entity == null)
					dto = null;
				else
					dto = UserMapper.Get(entity);

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task DeleteAsync(UserDto dto)
		{
			try
			{
				User user;

				user = await UserDao.GetAsync(dto.Id);
				user.IsActive = false;
				user.DischargeDate = DateTime.Now;
				await UserDao.UpdateAsync(user);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}