using RollCall.BusinessLayer.Mappers;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public class ScheduleBl
	{
		public static async Task<int> AddAsync(ScheduleDto dto)
		{
			try
			{
				Schedule entity;

				entity = ScheduleMapper.Get(dto);
				entity.IsActive = true;
				entity.RegistrationDate = DateTime.Now;
				await ScheduleDao.AddAsync(entity);

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task DeleteAsync(ScheduleDto dto)
		{
			try
			{
				Schedule entity;

				entity = await ScheduleDao.GetAsync(dto.Id);
				entity.IsActive = false;
				ScheduleDao.Update(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<ScheduleDto>> GetAllAsync()
		{
			try
			{
				List<ScheduleDto> dtos;
				List<Schedule> entities;

				entities = await ScheduleDao.GetAllAsync(true);
				dtos = ScheduleMapper.GetAll(entities);

				return dtos;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<ScheduleDto> GetAsync(int id)
		{
			try
			{
				ScheduleDto dto;
				Schedule entity;

				entity = await ScheduleDao.GetAsync(id);
				dto = ScheduleMapper.Get(entity);

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task UpdateAsync(ScheduleDto dto)
		{
			try
			{
				Schedule entity;
				Schedule schedule;

				entity = ScheduleMapper.Get(dto);
				schedule = await ScheduleDao.GetAsync(dto.Id);
				entity.IsActive = schedule.IsActive;
				entity.RegistrationDate = schedule.RegistrationDate;
				ScheduleDao.Update(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
