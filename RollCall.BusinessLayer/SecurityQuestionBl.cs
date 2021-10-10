using RollCall.BusinessLayer.Mappers;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public class SecurityQuestionBl
	{
		public static async Task<int> AddAsync(SecurityQuestionDto dto)
		{
			try
			{
				SecurityQuestion entity;

				entity = SecurityQuestionMapper.Get(dto);
				entity.IsActive = true;
				entity.RegistrationDate = DateTime.Now;
				await SecurityQuestionDao.AddAsync(entity);

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task DeleteAsync(SecurityQuestionDto dto)
		{
			try
			{
				SecurityQuestion entity;

				entity = await SecurityQuestionDao.GetAsync(dto.Id);
				entity.IsActive = false;
				await SecurityQuestionDao.UpdateAsync(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<SecurityQuestionDto>> GetAllAsync(int employeeId, bool isActive = true)
		{
			try
			{
				List<SecurityQuestionDto> dtos;
				List<SecurityQuestion> entities;

				entities = await SecurityQuestionDao.GetAllAsync(employeeId, isActive);
				dtos = SecurityQuestionMapper.GetAll(entities);

				return dtos;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<SecurityQuestionDto> GetAsync(int id)
		{
			try
			{
				SecurityQuestionDto dto;
				SecurityQuestion entity;

				entity = await SecurityQuestionDao.GetAsync(id);
				dto = SecurityQuestionMapper.Get(entity);

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task UpdateAsync(SecurityQuestionDto dto)
		{
			try
			{
				SecurityQuestion entity;
				SecurityQuestion SecurityQuestion;

				entity = SecurityQuestionMapper.Get(dto);
				SecurityQuestion = await SecurityQuestionDao.GetAsync(dto.Id);
				entity.IsActive = SecurityQuestion.IsActive;
				entity.RegistrationDate = SecurityQuestion.RegistrationDate;
				await SecurityQuestionDao.UpdateAsync(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
