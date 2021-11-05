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
					ListAssistances = GetAssitences(assitenceSearchDao.GetListEmployees(), assitenceSearchDao.GetLisAssistences(), searchAssistenceDto.DateStart, searchAssistenceDto.DateStop),
					CurrentPage = searchAssistenceDto.Page,
					NumberOfRecordsPerPage = searchAssistenceDto.NumberOfRecordsPerPage,
					TotalOfRecords = assitenceSearchDao.Count(),
					ListDates = GetListDates(searchAssistenceDto.DateStart, searchAssistenceDto.DateStop)
				};

				return listAssitenceDto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static List<DateTime> GetListDates(DateTime dateStart, DateTime dateStop)
		{
			List<DateTime> dateTimes;

			dateTimes = new List<DateTime>();
			while (dateStart != dateStop.AddDays(1))
			{
				dateTimes.Add(dateStart);
				dateStart = dateStart.AddDays(1);
			}

			return dateTimes;
		}

		private static List<AssistanceDto> GetAssitences(List<EmployeeEntity> employees, List<AssistanceLog> assistances, DateTime dateStart, DateTime dateStop)
		{
			try
			{
				List<AssistanceDto> list;

				list = new List<AssistanceDto>();
				employees.ForEach(employee =>
				{
					list.Add(
						GetAssistenceDto(employee, assistances, dateStart, dateStop)
					);
				});

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static AssistanceDto GetAssistenceDto(EmployeeEntity employee, List<AssistanceLog> assistances, DateTime dateStart, DateTime dateStop)
		{
			AssistanceDto assistanceDto;

			assistanceDto = new AssistanceDto
			{
				EmployeeId = employee.Id,
				EmployeeNumber = employee.EmployeeNumber,
				Name = employee.Name,
				LastName = employee.LastName,
				ListAssistanceDay = GetListAssistanceDay(assistances.Where(x => x.EmployeeId == employee.Id).ToList(), dateStart, dateStop, employee.Schedule.StartTime)
			};

			return assistanceDto;
		}

		private static List<AssistanceDayDto> GetListAssistanceDay(List<AssistanceLog> assistances, DateTime dateStart, DateTime dateStop, DateTime startTime)
		{
			try
			{
				List<AssistanceDayDto> assistanceDays;
				List<DateTime> dateTimes;

				assistances = assistances.OrderBy(x => x.RegistrationDate).ToList();
				//Creamos una lista de dias
				dateTimes = new List<DateTime>();
				while (dateStart != dateStop.AddDays(1))
				{
					dateTimes.Add(dateStart);
					dateStart = dateStart.AddDays(1);
				}
				assistanceDays = new List<AssistanceDayDto>();
				dateTimes.ForEach(date =>
				{
					assistanceDays.Add(new AssistanceDayDto
					{
						Date = date,
						AssitanceStatus = VerifyAssitance(assistances.Where(x => x.RegistrationDate.Date == date).ToList(), startTime),
						Entry = assistances.Where(x => x.AssistenceStatusId == AssistanceStatusDto.Entry && x.RegistrationDate.Date == date).FirstOrDefault() == null? null:
							assistances.Where(x => x.AssistenceStatusId == AssistanceStatusDto.Entry && x.RegistrationDate.Date == date).FirstOrDefault().RegistrationDate
					});
				});

				return assistanceDays;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static string VerifyAssitance(List<AssistanceLog> assistances, DateTime startTime)
		{
			try
			{
				string assistanceStatus;

				if (assistances.Count > 0)
				{
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

					assistanceStatus = GetStatusAssitence(entry, startTime);
				}
				else
				{
					assistanceStatus = "Sin registro";
				}

				return assistanceStatus;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private static string GetStatusAssitence(AssistanceLog entry, DateTime startTime)
		{
			int minutes;
			int toleranceInMinutes;

			toleranceInMinutes = 10;
			minutes = (entry.RegistrationDate.TimeOfDay - startTime.TimeOfDay).Minutes;
			if (0 > minutes)
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