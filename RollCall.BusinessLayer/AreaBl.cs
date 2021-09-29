using RollCall.BusinessLayer.Mappers;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public class AreaBl
	{
		public static async Task<List<AreaDto>> GetAllAsync(bool isActive = true)
		{
			try
			{
				List<AreaDto> list;
				List<Area> entities;

				entities = await AreaDao.GetAllAsync(isActive);
				list = AreaMapper.GetAll(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task AddAsync(AreaDto dto)
		{
			try
			{
				Area entity;

				entity = AreaMapper.Get(dto);
				entity.IsActive = true;
				await AreaDao.AddAsync(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<AreaDto> GetAsync(int id)
		{
			try
			{
				AreaDto dto;
				Area entity;

				entity = await AreaDao.GetAsync(id);
				dto = AreaMapper.Get(entity);

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task UpdateAsync(AreaDto dto)
		{
			try
			{
				Area entity;

				entity = AreaMapper.Get(dto);
				entity.IsActive = true;
				await AreaDao.Update(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task DeleteAsync(int id)
		{
			try
			{
				Area entity;

				entity = await AreaDao.GetAsync(id);
				entity.IsActive = false;
				await AreaDao.Update(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
