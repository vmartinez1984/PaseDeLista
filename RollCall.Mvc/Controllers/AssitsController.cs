using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
	public class AssitsController : Controller
	{
		public async Task<ActionResult> Index(SearchAssistenceDto searchAssistenceDto)
		{
			try
			{
				ListAssitenceDto listAssitenceDto;

				listAssitenceDto = await AssistanceBl.GetAllAsync(searchAssistenceDto);
				ViewBag.ListAreas = await AreaBl.GetAllAsync();
				ViewBag.ListSchedules = await ScheduleBl.GetAllAsync();

				return View(listAssitenceDto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		
	}
}
