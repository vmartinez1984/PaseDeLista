using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Interfaces.InterfacesBl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public UsersController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }
        //GET: UsersController		
        public async Task<ActionResult> Index()
        {
            try
            {
                List<UserDto> list;

                list = await _unitOfWorkBl.User.GetAsync();
                ViewBag.IsMaximum = await _unitOfWorkBl.User.IsMaximum();

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

                userDto = await _unitOfWorkBl.User.GetAsync(id);

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
                ViewBag.ListRoles = await _unitOfWorkBl.Role.GetAsync();

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
        public async Task<ActionResult> Create(UserDtoIn user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWorkBl.User.AddAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ListRoles = _unitOfWorkBl.Role.GetAsync();
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

                userDto = await _unitOfWorkBl.User.GetAsync(id);
                ViewBag.ListRoles = await _unitOfWorkBl.Role.GetAsync();

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
        public async Task<ActionResult> Edit(UserDtoIn user, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWorkBl.User.UpdateAsync(user, id);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ListRoles = await _unitOfWorkBl.Role.GetAsync();

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

                userDto = await _unitOfWorkBl.User.GetAsync(id);

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
                await _unitOfWorkBl.User.DeleteAsync(user.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}