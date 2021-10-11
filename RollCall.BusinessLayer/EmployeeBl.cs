using RollCall.BusinessLayer.Mappers;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public class EmployeeBl
	{
		public static async Task<EmployeeDto> GetAsync(string employeeNumber)
		{
			EmployeeDto dto;
			Employee entity;

			entity = await EmployeeDao.GetAllAsync(employeeNumber);
			dto = EmployeeMapper.Get(entity);

			return dto;
		}

		public static async Task<List<EmployeeDto>> GetAllAsync(bool isActive = true)
		{
			try
			{
				List<EmployeeDto> dtos;
				List<Employee> entities;

				entities = await EmployeeDao.GetAllAsync(isActive);
				dtos = EmployeeMapper.GetAll(entities);

				return dtos;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<EmployeeDto> GetAsync(int id)
		{
			try
			{
				EmployeeDto dto;
				Employee entity;

				entity = await EmployeeDao.GetAsync(id);
				dto = EmployeeMapper.Get(entity);

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> AddAsync(EmployeeDto dto)
		{
			try
			{
				Employee entity;
				DateTime now;

				entity = EmployeeMapper.Get(dto);				
				entity.IsActive = true;
				entity.RegistrationDate = DateTime.Now;
				entity.DischargeDate = null;
				using (var db = new AppDbContext())
				{
					db.Employee.Add(entity);
					await db.SaveChangesAsync();
					now = DateTime.Now;
					entity.EmployeeNumber = $"{now.Year}"+entity.Id.ToString().PadLeft(4, '0');
					await db.SaveChangesAsync();
				}

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static Task DeleteAsync(EmployeeDto dto)
		{
			throw new NotImplementedException();
		}

		public static async Task UpdateAsync(EmployeeDto employeeDto)
		{
			try
			{
				Employee entity;

				entity = await EmployeeDao.GetAsync(employeeDto.Id);
				entity.Name = employeeDto.Name;
				entity.LastName = employeeDto.LastName;
				entity.ScheduleId = employeeDto.ScheduleId;
				entity.AreaId = employeeDto.AreaId;
				entity.PhotoInBase64 = employeeDto.PhotoInBase64;
				await EmployeeDao.UpdateAsync(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task DeleteAsync(int employeeId)
		{
			try
			{
				Employee entity;

				entity = await EmployeeDao.GetAsync(employeeId);
				entity.IsActive = false;
				entity.DischargeDate = DateTime.Now;
				await EmployeeDao.UpdateAsync(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
