using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Areas.Administrators.Controllers
{
	[Area("Administrators")]
	public class SecurityQuestionsController : Controller
	{
		// GET: SecurityQuestionsController
		public async Task<ActionResult> Index(int employeeId)
		{
			List<SecurityQuestionDto> list;

			list = await SecurityQuestionBl.GetAllAsync(employeeId);
			ViewBag.EmployeeId = employeeId;

			return View(list);
		}

		// GET: SecurityQuestionsController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}
			
		// POST: SecurityQuestionsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(SecurityQuestionDto securityQuestion)
		{
			try
			{
				await SecurityQuestionBl.AddAsync(securityQuestion);

				return RedirectToAction("Index", "SecurityQuestions", new { employeeId = securityQuestion.EmployeeId });
			}
			catch
			{
				return View();
			}
		}

		// GET: SecurityQuestionsController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SecurityQuestionsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: SecurityQuestionsController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SecurityQuestionsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
