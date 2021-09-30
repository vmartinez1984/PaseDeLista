using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserLoginDto userLogin)
		{
			try
			{
				if (ModelState.IsValid)
				{
					UserDto userDto;

					userDto = await UserBl.LoginAsync(userLogin);
					if (userDto is null)
					{
						return View();
					}
					else
					{
						HttpContext.Session.SetInt32("userId", userDto.Id);
						HttpContext.Session.SetInt32("userRolId", userDto.RolId);
						HttpContext.Session.SetString("userName", $"{userDto.Name} {userDto.LastName}");

						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					return View();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public IActionResult LogOut()
		{
			HttpContext.Session.Clear();

			return RedirectToAction("Index");
		}
	}
}
