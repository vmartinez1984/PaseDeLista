using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Mvc.Areas.Administrators.Controllers
{
	[Area("Administrators")]
	public class HomeController : Controller
	{
		[Route("Administrators")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
