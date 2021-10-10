using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RollCall.BusinessLayer;
using RollCall.Dto;
using RollCall.Mvc.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<ActionResult> Employee(string	employeeNumber)
		{
			try
			{
				EmployeeDto user;

				user = await EmployeeBl.GetAsync(employeeNumber);
				if (user is null)
				{
					ViewBag.Error = "No encontrado";
					return RedirectToAction("Index");
				}
				else
				{
					return View(user);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<IActionResult> Verify(AssistanceDto assistanceDto)
		{
			try
			{
				assistanceDto.RegistrationDate = DateTime.Now;
				await AssistanceBl.AddAsync(assistanceDto);

				ViewBag.Check = "Datos registrados";

				return RedirectToAction("index");
			}
			catch (Exception)
			{

				throw;
			}
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
