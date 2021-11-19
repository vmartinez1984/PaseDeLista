using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RollCall.Mvc.Controllers
{
    public class AdministrationController : Controller
    {
		private readonly ILogger<HomeController> _logger;

		public AdministrationController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
