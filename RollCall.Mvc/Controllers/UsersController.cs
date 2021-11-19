using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.BusinessLayer;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
	public class UsersController : Controller
	{
		// GET: UsersController
		//[Route("{}")]
		public async Task<ActionResult> Index()
		{
			try
			{
				List<UserDto> list;

				list = await UserBl.GetAllAsync();
				ViewBag.IsMaximum = await UserBl.IsMaximum();

				return View(list);
			}
			catch (Exception)
			{

				throw;
			}
		}

		// GET: UsersController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			try
			{
				UserDto userDto;

				userDto = await UserBl.GetAsync(id);

				return View(userDto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		// GET: UsersController/Create
		public async Task<ActionResult> Create()
		{
			try
			{
				ViewBag.ListRoles = await RolBl.GetAllAsync();

				return View();
			}
			catch (Exception)
			{

				throw;
			}
		}

		// POST: UsersController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(UserDto user)
		{
			try
			{				
				if (ModelState.IsValid)
				{
					await UserBl.AddAsync(user);
					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.ListRoles = await RolBl.GetAllAsync();
					return View();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		// GET: UsersController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			try
			{
				UserDto userDto;

				userDto = await UserBl.GetAsync(id);
				ViewBag.ListRoles = await RolBl.GetAllAsync();

				return View(userDto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		// POST: UsersController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(UserDto user)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await UserBl.UpdateAsync(user);

					return RedirectToAction(nameof(Index));
				}
				else
				{
					ViewBag.ListRoles = await RolBl.GetAllAsync();

					return View();
				}
			}
			catch
			{
				throw;
			}
		}

		// GET: UsersController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			try
			{
				UserDto userDto;

				userDto = await UserBl.GetAsync(id);

				return View(userDto);
			}
			catch (Exception)
			{

				throw;
			}
		}

		// POST: UsersController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(UserDto user)
		{
			try
			{
				await UserBl.DeleteAsync(user);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}