using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Interfaces.InterfacesBl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
    public class SchedulesController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public SchedulesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }


        public async Task<IActionResult> Index()
        {
            List<ScheduleDto> list;

            list = await _unitOfWorkBl.Schedule.GetAsync();

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScheduleDtoIn dto)
        {
            try
            {
                await _unitOfWorkBl.Schedule.AddAsync(dto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                ScheduleDto dto;

                dto = await _unitOfWorkBl.Schedule.GetAsync(id);

                return View(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ScheduleDtoIn dto, int id)
        {
            try
            {
                await _unitOfWorkBl.Schedule.UpdateAsync(dto, id);

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
                ScheduleDto dto;

                dto = await _unitOfWorkBl.Schedule.GetAsync(id);

                return View(dto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ScheduleDto dto)
        {
            try
            {
                await _unitOfWorkBl.Schedule.DeleteAsync(dto.Id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }//end class
}