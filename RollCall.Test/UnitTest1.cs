using NUnit.Framework;
using RollCall.BusinessLayer;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace RollCall.Test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void AddAssistence()
		{
			List<EmployeeEntity> list;

			list = EmployeeDao.GetAll();

			list.ForEach(entity =>
			{
				SetEntries(entity.Id, entity.Schedule.StartTime);
				SetExits(entity.Id, entity.Schedule.StopTime);
				SetLunchTime(entity.Id, entity.Schedule.StartTime, entity.Schedule.StopTime);
			});

			Assert.Pass();
		}

		private void SetLunchTime(int employeeId, DateTime startTime, DateTime stopTime)
		{
			try
			{
				int month;
				int year;

				month = 10;
				year = 2021;
				using (var db = new AppDbContext())
				{
					AssistanceLog assistance;
					for (int day = 1; day < 32; day++)
					{
						assistance = new AssistanceLog
						{
							EmployeeId = employeeId,
							RegistrationDate = new DateTime(year, month, day, ((startTime.Hour + stopTime.Hour) / 2), stopTime.Minute, 0).AddSeconds(GetSecondsRandom()),
							AssistenceStatusId = 3
						};
						db.AssistanceLog.Add(assistance);
						assistance = new AssistanceLog
						{
							EmployeeId = employeeId,
							RegistrationDate = new DateTime(year, month, day, ((startTime.Hour + stopTime.Hour) / 2) + 1, stopTime.Minute, 0).AddSeconds(GetSecondsRandom()),
							AssistenceStatusId = 4
						};
						db.AssistanceLog.Add(assistance);
					}
					db.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void SetExits(int employeeId, DateTime stopTime)
		{
			try
			{
				int month;
				int year;

				month = 10;
				year = 2021;
				using (var db = new AppDbContext())
				{
					for (int day = 1; day < 32; day++)
					{
						AssistanceLog assistance = new AssistanceLog
						{
							EmployeeId = employeeId,
							RegistrationDate = new DateTime(year, month, day, stopTime.Hour, stopTime.Minute, 0).AddSeconds(GetSecondsRandom()),
							AssistenceStatusId = 2
						};
						db.AssistanceLog.Add(assistance);
					}
					db.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void SetEntries(int employeeId, DateTime startTime)
		{
			try
			{
				int month;
				int year;

				month = 10;
				year = 2021;
				using (var db = new AppDbContext())
				{
					for (int day = 1; day < 32; day++)
					{
						AssistanceLog assistance = new AssistanceLog
						{
							EmployeeId = employeeId,
							RegistrationDate = new DateTime(year, month, day, startTime.Hour, startTime.Minute, 0).AddSeconds(GetSecondsRandom()),
							AssistenceStatusId = 1							
						};
						db.AssistanceLog.Add(assistance);
					}
					db.SaveChanges();
				}

			}
			catch (Exception)
			{

				throw;
			}
		}

		private double GetSecondsRandom()
		{
			Random random = new Random();

			return random.Next(-300, 900);
		}
	}
}