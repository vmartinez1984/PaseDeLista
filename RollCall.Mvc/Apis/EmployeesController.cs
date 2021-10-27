﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Threading.Tasks;

namespace RollCall.Mvc.Apis
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		[HttpGet("{employeeNumber}")]
		public async Task<IActionResult> Get(string employeeNumber)
		{
			try
			{
				EmployeeDto employee;

				employee = await EmployeeBl.GetAsync(employeeNumber);

				return Ok(employee);
			}
			catch (Exception)
			{

				throw;
			}
		}	
	}
}
