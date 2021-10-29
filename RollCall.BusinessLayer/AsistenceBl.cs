using RollCall.BusinessLayer.Mappers;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public class AssistanceBl
	{
		public static async Task<int> AddAsync(AssistanceDto dto)
		{
			try
			{
				Assistance entity;

				entity = AssistanceMapper.Get(dto);
				await AssistanceDao.AddAsync(entity);

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceDto>> GetAllAsync()
		{
			try
			{
				List<AssistanceDto> list;
				List<Assistance> entities;

				entities = await AssistanceDao.GetAllNowAsync();
				list = AssistanceMapper.GetAll(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceDto>> GetAllAsync(int userId, int month)
		{
			try
			{
				List<AssistanceDto> list;
				List<Assistance> entities;

				entities = await AssistanceDao.GetAllAsync(userId, month, DateTime.Now.Year);
				list = AssistanceMapper.GetAll(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> GetTotalOfRecords()
		{
			try
			{
				int totalOfRecords;

				totalOfRecords =await AssistanceDao.GetTotalOfRecordsAsync();

				return totalOfRecords;
			}
			catch (Exception)
			{

				throw;
			}
		}

		//public static async Task<List<AssistanceDto>> GetAllAsync(SearchDto search)
		//{
		//	try
		//	{
		//		List<Assistance> entities;
		//		List<AssistanceDto> dtos;

		//		if (!string.IsNullOrEmpty(search.Name))
		//		{
		//			entities = await AssistanceDao.GetAllAsync(search.Name, search.LastName);
		//		}


		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}
		//}

		//public static async Task<List<AssistanceDto>> GetAllAsync(int page, int numberOfRecordPerPage)
		//{
		//	try
		//	{
		//		List<Assistance> entities;
		//		List<AssistanceDto> dtos;

		//		entities = await AssistanceDao.GetAllAsync(page, numberOfRecordPerPage);
		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}
		//}

		public static async Task<bool> RegisterAsync(AnswerDto answer)
		{
			try
			{
				bool isRegister;
				SecurityQuestionDto securityQuestion;
				Assistance assistance;

				securityQuestion = await SecurityQuestionBl.GetAsync(answer.SecurityQuestionId);
				if (securityQuestion.Answer.ToUpper().Contains(answer.Answer.ToUpper()))
				{
					assistance = new Assistance
					{
						RegistrationDate = DateTime.Now,
						EmployeeId = securityQuestion.EmployeeId
					};
					await AssistanceDao.AddAsync(assistance);
					isRegister = true;
				}
				else
				{
					isRegister = false;
				}

				return isRegister;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
