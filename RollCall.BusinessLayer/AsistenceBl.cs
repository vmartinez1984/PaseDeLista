using AutoMapper;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Entities;
using RollCall.Core.Enums;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Persistence.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
    public class AssistanceBl
	{
        private IMapper _mapper;
        private IRepository _repository;
        private SecurityQuestionBl _securityQuestionBl;

        public AssistanceBl(IRepository repository,IMapper mapper, SecurityQuestionBl securityQuestionBl)
		{
			_mapper = mapper;
			_repository = repository;
			_securityQuestionBl = securityQuestionBl;
		}
		
		public  async Task<int> AddAsync(AssistanceDto dto)
		{
			try
			{
				AssistanceLogEntity entity;

				entity = _mapper.Map<AssistanceLogEntity>(dto);
				await _repository.AssistanceLog.AddAsync(entity);

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<List<AssistanceDto>> GetAllAsync()
		{
			try
			{
				List<AssistanceDto> list;
				List<AssistanceLogEntity> entities;

				entities = await  AssistanceDao.GetAllNowAsync();
				list = _mapper.Map<List<AssistanceDto>>(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public  async Task<List<AssistanceDto>> GetAllAsync(int userId, int month)
		{
			try
			{
				List<AssistanceDto> list;
				List<AssistanceLogEntity> entities;

				entities = await AssistanceDao.GetAllAsync(userId, month, DateTime.Now.Year);
				list = _mapper.Map<List<AssistanceDto>>(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public  async Task<ListAssitenceDto> GetAllAsync(SearchAssistenceDto searchAssistenceDto)
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

		private  List<DateTime> GetListDates(DateTime dateStart, DateTime dateStop)
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

		private  List<AssistanceDto> GetAssitences(List<EmployeeEntity> employees, List<AssistanceLogEntity> assistances, DateTime dateStart, DateTime dateStop)
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

		private  AssistanceDto GetAssistenceDto(EmployeeEntity employee, List<AssistanceLogEntity> assistances, DateTime dateStart, DateTime dateStop)
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

		private  List<AssistanceDayDto> GetListAssistanceDay(List<AssistanceLogEntity> assistances, DateTime dateStart, DateTime dateStop, DateTime startTime)
		{
			try
			{
				List<AssistanceDayDto> assistanceDays;
				List<DateTime> dateTimes;

				assistances = assistances.OrderBy(x => x.DateRegistration).ToList();
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
						AssitanceStatus = VerifyAssitance(assistances.Where(x => x.DateRegistration.Date == date).ToList(), startTime),
						//Entry = assistances.Where(x => x.AssistenceStatusId == AssistanceStatusDto.Entry && x.DateRegistration.Date == date).FirstOrDefault() == null? null:
						// 	assistances.Where(x => x.AssistenceStatusId == AssistanceStatusDto.Entry && x.DateRegistration.Date == date).FirstOrDefault().DateRegistration
					});
				});

				return assistanceDays;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private  string VerifyAssitance(List<AssistanceLogEntity> assistances, DateTime startTime)
		{
			try
			{
				string assistanceStatus;

				if (assistances.Count > 0)
				{
					AssistanceLogEntity entry;
					AssistanceLogEntity exit;
					AssistanceLogEntity lunchTimeDeparture;
					AssistanceLogEntity lunchTimeReturn;
					AssistanceLogEntity assistance;

					assistance = assistances.FirstOrDefault();
					entry = assistances.Where(x => x.AssistenceStatusId == AssistanceStatus.Entry).FirstOrDefault();
					exit = assistances.Where(x => x.AssistenceStatusId == AssistanceStatus.Exit).LastOrDefault();
					lunchTimeDeparture = assistances.Where(x => x.AssistenceStatusId == AssistanceStatus.LunchTimeDeparture).FirstOrDefault();
					lunchTimeReturn = assistances.Where(x => x.AssistenceStatusId == AssistanceStatus.LunchTimeReturn).FirstOrDefault();
					entry = new AssistanceLogEntity();
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

		private  string GetStatusAssitence(AssistanceLogEntity entry, DateTime startTime)
		{
			int minutes;
			int toleranceInMinutes;

			toleranceInMinutes = 10;
			minutes = (entry.DateRegistration.TimeOfDay - startTime.TimeOfDay).Minutes;
			if (0 > minutes)
				return "Asistencia";
			if (minutes <= toleranceInMinutes)
				return "Asistencia";
			else
				return "Retardo";
		}

		private  SearchAssitence Get(SearchAssistenceDto searchAssistenceDto)
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

		public  async Task<bool> RegisterAsync(AnswerDto answer)
		{
			try
			{
				bool isRegister;
				SecurityQuestionDtoOut securityQuestion;
				AssistanceLogEntity assistance;


				securityQuestion = await _securityQuestionBl.GetAsync(answer.SecurityQuestionId);
				if (securityQuestion.Answer.ToUpper().Contains(answer.Answer.ToUpper()))
				{
					assistance = new AssistanceLogEntity
					{
						DateRegistration = DateTime.Now,
						EmployeeId = securityQuestion.EmployeeId,
						AssistenceStatusId = answer.AsistanceStatusId
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

	}//end class
}