using RollCall.BusinessLayer.Mappers;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
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

		public static async Task<ListAssitenceDto> GetAllAsync(SearchAssistenceDto searchAssistenceDto)
		{
			try
			{
				ListAssitenceDto listAssitenceDto;
				SearchAssitence searchAssitence;
				AssitenceSearchDao assitenceSearchDao;


				searchAssitence = Get(searchAssistenceDto);
				assitenceSearchDao = new AssitenceSearchDao(searchAssitence);
				listAssitenceDto = new ListAssitenceDto
				{
					ListAssistances = AssistanceMapper.GetAll(await assitenceSearchDao.GetAllAsync()),
					CurrentPage = searchAssistenceDto.Page,
					NumberOfRecordsPerPage = searchAssistenceDto.NumberOfRecordsPerPage,
					TotalOfRecords = assitenceSearchDao.Count()
				};

				return listAssitenceDto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static SearchAssitence Get(SearchAssistenceDto searchAssistenceDto)
		{
			SearchAssitence searchAssitence;

			searchAssitence = new SearchAssitence
			{
				 AreaId = searchAssistenceDto.AreaId,
				 DateStart = searchAssistenceDto.DateStart,
				 DateStop = searchAssistenceDto.DateStop,
				 IsActive = searchAssistenceDto.IsActive,	
				 LastName = searchAssistenceDto.LastName,
				 Name = searchAssistenceDto.Name,
				 NumberOfRecordsPerPage = searchAssistenceDto.NumberOfRecordsPerPage,
				 Page = searchAssistenceDto.Page,	
				 ScheduleId =searchAssistenceDto.ScheduleId
			};

			return searchAssitence;
		}

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