﻿using Microsoft.EntityFrameworkCore;
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
	public class EmployeeBl
	{
		public static async Task<EmployeeDto> GetAsync(string employeeNumber)
		{
			EmployeeDto dto;
			EmployeeEntity entity;

			entity = await EmployeeDao.GetAsync(employeeNumber);
			dto = EmployeeMapper.Get(entity);

			return dto;
		}

		public static async Task<ListEmployeeDto> GetAllAsync(SearchEmployeeDto searchEmployeeDto)
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
					ListEmployee = EmployeeMapper.GetAll(entities),
					NumberOfRecordsPerPage = searchEmployeeDto.NumberOfRecordsPerPage,
					TotalOfRecords =  employeeSearchDao.Count(),
					CurrentPage = searchEmployeeDto.Page
				};

				return dto;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<int> CountAsync(bool isActive = true)
		{
			try
			{
				int totalOfRecords;

				using (var db = new AppDbContext())
				{
					totalOfRecords = await db.Employee
						.Where(x=>x.IsActive == isActive)
						.CountAsync();
				}

				return totalOfRecords;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<EmployeeDto>> GetAllAsync(bool isActive = true)
		{
			try
			{
				List<EmployeeDto> dtos;
				List<EmployeeEntity> entities;

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
				EmployeeEntity entity;

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
				EmployeeEntity entity;
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
					entity.EmployeeNumber = $"{now.Year}" + entity.Id.ToString().PadLeft(4, '0');
					await db.SaveChangesAsync();
				}
				dto.ListSecurityQuestions.ForEach(item =>
				{
					SecurityQuestion securityQuestion;

					securityQuestion = new SecurityQuestion
					{
						Answer = item.Answer,
						EmployeeId = entity.Id,
						IsActive = true,
						Question = item.Question,
						RegistrationDate = now,
					};
					SecurityQuestionDao.Add(securityQuestion);
				});

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task DeleteAsync(EmployeeDto dto)
		{
			try
			{
				EmployeeEntity entity;

				entity = await EmployeeDao.GetAsync(dto.Id);
				entity.IsActive = false;
				await EmployeeDao.UpdateAsync(entity);
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task UpdateAsync(EmployeeDto employeeDto)
		{
			try
			{
				EmployeeEntity entity;

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
				EmployeeEntity entity;

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
