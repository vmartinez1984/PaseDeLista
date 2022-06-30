using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RollCall.Core.Interfaces.InterfacesBl;
using RollCall.Core.Dtos.Outputs;
using System;
using Microsoft.AspNetCore.Http;
using RollCall.Dto;
using RollCall.Core.Dtos.Inputs;

namespace RollCall.Mvc.Controllers
{
    public class AreasController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public AreasController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        public async Task<IActionResult> Index()
        {

            List<AreaDtoOut> list;

            list = await _unitOfWorkBl.Area.GetAsync();

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name,Description")]AreaDto area)
        public async Task<IActionResult> Create(IFormCollection formCollection)
        {
            try
            {
                AreaDtoIn areaDto = new AreaDtoIn()
                {
                    Name = formCollection["Name"],
                    Description = formCollection["Description"]
                };
                if (ModelState.IsValid)
                {
                    await _unitOfWorkBl.Area.AddAsync(areaDto);

                    return RedirectToAction(nameof(Index));
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                AreaDtoOut dto;

                dto = await _unitOfWorkBl.Area.GetAsync(id);

                return View(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AreaDtoIn dto)
        {
            try
            {
                await _unitOfWorkBl.Area.UpdateAsync(dto, id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
        	try
        	{
        		AreaDtoOut dto;

        		dto = await _unitOfWorkBl.Area.GetAsync(id);

        		return View(dto);
        	}
        	catch (Exception)
        	{

        		throw;
        	}
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AreaDto dto)
        {
        	try
        	{
        		await _unitOfWorkBl.Area.DeleteAsync(dto.Id);

        		return RedirectToAction(nameof(Index));
        	}
        	catch (Exception)
        	{

        		throw;
        	}
        }
    }
}
