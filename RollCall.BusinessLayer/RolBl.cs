using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Interfaces.InterfacesBl;
using RollCall.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public class RolBl : IRoleBl
	{
		public async Task<List<RolDto>> GetAsync()
		{
			try
			{
				return new List<RolDto>
				{
					new RolDto{Id = Rol.Administrador, Name = nameof(Rol.Administrador)},
					new RolDto{Id = Rol.Supervisor, Name = nameof(Rol.Supervisor)},
					//new RolDto{Id = Rol.Empleado, Name = nameof(Rol.Empleado)},
				};
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
