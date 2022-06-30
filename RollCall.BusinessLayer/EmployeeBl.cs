using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces.InterfacesBl;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
    public class EmployeeBl  //: IEmployeeBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public EmployeeBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetAsync(string employeeNumber)
        {
            EmployeeDto dto;
            EmployeeEntity entity;

            entity = await _repository.Employee.GetAsync(employeeNumber);
            dto = _mapper.Map<EmployeeDto>(entity);

            return dto;
        }

        public async Task<bool> IsMaximum()
        {
            try
            {
                bool isMaximum;

                isMaximum = false;

                int employees;
                int maxEmployees;

                employees = await _repository.Employee.CountAsync();
                maxEmployees = ConfigBl.GetMaxEmployees();
                if (employees == maxEmployees)
                    isMaximum = true;
                else if (employees < maxEmployees)
                    isMaximum = false;
                else
                    isMaximum = true;


                return isMaximum;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ListEmployeeDto> GetAsync(SearchEmployeeDto searchEmployeeDto)
        {
            try
            {
                ListEmployeeDto dto;
                List<EmployeeEntity> entities;
                SearchEmployee searchEmployee;
                EmployeeSearchDao employeeSearchDao;

                searchEmployee = new SearchEmployee
                {
                    Page = searchEmployeeDto.Page,
                    IsActive = searchEmployeeDto.IsActive,
                    NumberOfRecordsPerPage = searchEmployeeDto.NumberOfRecordsPerPage,
                    Name = searchEmployeeDto.Name,
                    LastName = searchEmployeeDto.LastName,
                    DateStart = searchEmployeeDto.DateBegin,
                    DateStop = searchEmployeeDto.DateEnd
                };
                employeeSearchDao = new EmployeeSearchDao(searchEmployee);
                entities = await employeeSearchDao.GetAllAsync();
                dto = new ListEmployeeDto
                {
                    ListEmployee = _mapper.Map<List<EmployeeDto>>(entities),
                    NumberOfRecordsPerPage = searchEmployeeDto.NumberOfRecordsPerPage,
                    TotalOfRecords = employeeSearchDao.Count(),
                    CurrentPage = searchEmployeeDto.Page
                };

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> CountAsync(bool isActive = true)
        {
            try
            {
                int totalOfRecords;

                using (var db = new AppDbContext())
                {
                    totalOfRecords = await db.Employee
                      .Where(x => x.IsActive == isActive)
                      .CountAsync();
                }

                return totalOfRecords;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<EmployeeDto>> GetAllAsync(bool isActive = true)
        {
            try
            {
                List<EmployeeDto> dtos;
                List<EmployeeEntity> entities;

                entities = await _repository.Employee.GetAsync();
                dtos = _mapper.Map<List<EmployeeDto>>(entities);

                return dtos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeDto> GetAsync(int id)
        {
            try
            {
                EmployeeDto dto;
                EmployeeEntity entity;

                entity = await _repository.Employee.GetAsync(id);
                dto = _mapper.Map<EmployeeDto>(entity);

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddAsync(EmployeeDto dto)
        {
            try
            {
                if (IsMaximum().Result)
                {
                    throw new Exception("Ha alcanzado su limite máximo de usuarios, contacte a su ejecutivo de cuenta.");
                }

                EmployeeEntity entity;
                DateTime now;

                entity = _mapper.Map<EmployeeEntity>(dto);
                entity.DischargeDate = null;
                using (var db = new AppDbContext())
                {
                    db.Employee.Add(entity);
                    await db.SaveChangesAsync();
                    now = DateTime.Now;
                    entity.EmployeeNumber = $"{now.Year}" + entity.Id.ToString().PadLeft(4, '0');
                    await db.SaveChangesAsync();
                }
                dto.ListSecurityQuestions.ForEach(async item =>
                {
                    SecurityQuestionEntity securityQuestionEntity;

                    securityQuestionEntity = new SecurityQuestionEntity
                    {
                        Answer = item.Answer,
                        EmployeeId = entity.Id,
                        Question = item.Question,
                    };
                    await _repository.SecurityQuestion.AddAsync(securityQuestionEntity);
                });

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<int> CountAsync()
        {
            try
            {
                int total;

                total = await _repository.Employee.CountAsync();

                return total;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(EmployeeDto dto)
        {
            try
            {
                EmployeeEntity entity;

                entity = _mapper.Map<EmployeeEntity>(dto);
                await _repository.Employee.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(EmployeeDto employeeDto)
        {
            try
            {
                EmployeeEntity entity;

                entity = await _repository.Employee.GetAsync(employeeDto.Id);
                entity.Name = employeeDto.Name;
                entity.LastName = employeeDto.LastName;
                entity.ScheduleId = employeeDto.ScheduleId;
                entity.AreaId = employeeDto.AreaId;
                entity.PhotoInBase64 = employeeDto.PhotoInBase64;
                await _repository.Employee.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int employeeId)
        {
            try
            {
                EmployeeEntity entity;

                entity = await _repository.Employee.GetAsync(employeeId);
                entity.IsActive = false;
                entity.DischargeDate = DateTime.Now;
                await _repository.Employee.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }//end class
}