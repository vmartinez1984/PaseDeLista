using RollCall.BusinessLayer.Mappers;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
	public class AssistanceBl
	{
		public static async Task<int> AddAsync(AssistanceDto dto)
		{
			try
			{
				Assistance entity;

				entity = AssistanceMapper.Get(dto);
				await AssistanceDao.AddAsync(entity);

				return entity.Id;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static async Task<List<AssistanceDto>> GetAllAsync()
		{
			try
			{
				List<AssistanceDto> list;
				List<Assistance> entities;

				entities = await AssistanceDao.GetAllNowAsync();
				list = AssistanceMapper.GetAll(entities);

				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
