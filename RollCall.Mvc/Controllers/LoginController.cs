using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Interfaces.InterfacesBl;
using RollCall.Dto;
using System;
using System.Threading.Tasks;

namespace RollCall.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public LoginController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

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

                    userDto = await _unitOfWorkBl.Login.LoginAsync(userLogin);
                    if (userDto is null)
                    {
                        ViewBag.Error = "Usuario y/o contraseña no validos";
                        return View();
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("userId", userDto.Id);
                        HttpContext.Session.SetInt32("userRolId", userDto.RolId);
                        HttpContext.Session.SetString("userName", $"{userDto.Name} {userDto.LastName}");

                        switch (userDto.RolId)
                        {
                            case Rol.Administrador:
                                return RedirectToAction("Index", "Administration");
                            //break;
                            case Rol.Empleado:
                                return RedirectToAction("Index", "EmployeeAssistance", new { area = "Employees" });
                            //break;
                            default:
                                return RedirectToAction("Index", "Home");
                                //break;
                        }
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

        [HttpGet]
        public IActionResult LogOut()
        {
        	HttpContext.Session.Clear();

        	return RedirectToAction("Index");
        }
    }
}
