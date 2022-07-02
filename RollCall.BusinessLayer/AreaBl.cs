using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Core.Entities;
using AutoMapper;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Interfaces.InterfacesBl;

namespace RollCall.BusinessLayer
{
    public class AreaBl : IAreaBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public AreaBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AreaDtoOut>> GetAsync()
        {
            try
            {
                List<AreaDtoOut> list;
                List<AreaEntity> entities;

                entities = await _repository.Area.GetAsync();
                list = _mapper.Map<List<AreaDtoOut>>(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddAsync(AreaDtoIn dto)
        {
            try
            {
                AreaEntity entity;

                entity = _mapper.Map<AreaEntity>(dto);
                entity.Id = await _repository.Area.AddAsync(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AreaDtoOut> GetAsync(int id)
        {
            try
            {
                AreaDtoOut dto;
                AreaEntity entity;

                entity = await _repository.Area.GetAsync(id);
                dto = _mapper.Map<AreaDtoOut>(entity);

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(AreaDtoIn dto, int id)
        {
            try
            {
                AreaEntity entity;

                entity = await _repository.Area.GetAsync(id);
                entity.Name = dto.Name;
                entity.Description = dto.Description;
                await _repository.Area.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _repository.Area.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }//end class
}
