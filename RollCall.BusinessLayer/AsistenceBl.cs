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
				AssistanceLog entity;

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
				List<AssistanceLog> entities;

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
				List<AssistanceLog> entities;

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
				await assitenceSearchDao.GetAllAsync();
				listAssitenceDto = new ListAssitenceDto
				{
					ListAssistances = GetAssitences(assitenceSearchDao.GetListEmployees(), assitenceSearchDao.GetLisAssistences()),
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

		private static List<AssistanceDto> GetAssitences(List<EmployeeEntity> entities, List<AssistanceLog> assistances)
		{
			try
			{
				List<AssistanceDto> list;
				List<int> days;

				days = assistances.Select(x => x.RegistrationDate.Day).Distinct().ToList();
				list = new List<AssistanceDto>();
				entities.ForEach(entity =>
				{
					list.AddRange(GetAssitence(entity, assistances.Where(x => x.EmployeeId == entity.Id).ToList(), days));
				});

				return list.OrderBy(x=>x.RegistrationDate).ToList();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static List<AssistanceDto> GetAssitence(EmployeeEntity employee, List<AssistanceLog> assistances, List<int> days)
		{
			try
			{
				List<AssistanceDto> list;

				list = new List<AssistanceDto>();
				days.ForEach(day =>
				{
					list.Add(
						GetAssistenceDto(employee, assistances.Where(x => x.RegistrationDate.Day == day).ToList())
					);
				});

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static AssistanceDto GetAssistenceDto(EmployeeEntity employee, List<AssistanceLog> assistances)
		{
			AssistanceDto assistanceDto;
			AssistanceLog entry;
			AssistanceLog exit;
			AssistanceLog lunchTimeDeparture;
			AssistanceLog lunchTimeReturn;
			AssistanceLog assistance;

			assistance = assistances.FirstOrDefault();
			entry = assistances.Where(x => x.AssistenceStatusId == AssistanceStatusDto.Entry).FirstOrDefault();
			exit = assistances.Where(x => x.AssistenceStatusId == AssistanceStatusDto.Exit).LastOrDefault();
			lunchTimeDeparture = assistances.Where(x => x.AssistenceStatusId == AssistanceStatusDto.LunchTimeDeparture).FirstOrDefault();
			lunchTimeReturn = assistances.Where(x => x.AssistenceStatusId == AssistanceStatusDto.LunchTimeReturn).FirstOrDefault();
			assistanceDto = new AssistanceDto
			{
				EmployeeNumber = employee.EmployeeNumber,
				Name = employee.Name,
				LastName = employee.LastName,
				RegistrationDate = assistance.RegistrationDate.Date,
				Entry = entry is null ? null : entry.RegistrationDate,
				LunchTimeDeparture = lunchTimeDeparture is null ? null : lunchTimeDeparture.RegistrationDate,
				LunchTimeReturn = lunchTimeReturn is null ? null : lunchTimeReturn.RegistrationDate,
				Exit = exit is null ? null : exit.RegistrationDate,
				LunchMinutes = lunchTimeReturn is null && lunchTimeDeparture is null ? 0 :
				(lunchTimeReturn.RegistrationDate - lunchTimeDeparture.RegistrationDate).Minutes
				+ (lunchTimeReturn.RegistrationDate - lunchTimeDeparture.RegistrationDate).Hours * 60,
				Assitence = GetStatusAssitence(entry, employee.Schedule.StartTime)
			};

			return assistanceDto;
		}

		private static string GetStatusAssitence(AssistanceLog entry, DateTime startTime)
		{
			int minutes;
			int toleranceInMinutes;

			toleranceInMinutes = 10;
			minutes = (entry.RegistrationDate.TimeOfDay - startTime.TimeOfDay).Minutes;
			if( 0 > minutes)
				return "Asistencia";
			if (minutes <= toleranceInMinutes)
				return "Asistencia";
			else
				return "Retardo";
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
				EmployeeNumber = searchAssistenceDto.EmployeeNumber,
				NumberOfRecordsPerPage = searchAssistenceDto.NumberOfRecordsPerPage,
				Page = searchAssistenceDto.Page,
				ScheduleId = searchAssistenceDto.ScheduleId
			};

			return searchAssitence;
		}

		public static async Task<bool> RegisterAsync(AnswerDto answer)
		{
			try
			{
				bool isRegister;
				SecurityQuestionDto securityQuestion;
				AssistanceLog assistance;

				securityQuestion = await SecurityQuestionBl.GetAsync(answer.SecurityQuestionId);
				if (securityQuestion.Answer.ToUpper().Contains(answer.Answer.ToUpper()))
				{
					assistance = new AssistanceLog
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