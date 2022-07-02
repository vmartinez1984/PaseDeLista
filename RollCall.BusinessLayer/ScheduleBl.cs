using AutoMapper;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces.InterfacesBl;
using RollCall.Core.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
    public class ScheduleBl: IScheduleBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public ScheduleBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ScheduleDtoIn dto)
        {
            try
            {
                ScheduleEntity entity;

                entity = _mapper.Map<ScheduleEntity>(dto);

                await _repository.Schedule.AddAsync(entity);

                return entity.Id;
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
                await _repository.Schedule.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ScheduleDto>> GetAsync()
        {
            try
            {
                List<ScheduleDto> dtos;
                List<ScheduleEntity> entities;

                entities = await _repository.Schedule.GetAsync();
                dtos = _mapper.Map<List<ScheduleDto>>(entities);

                return dtos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ScheduleDto> GetAsync(int id)
        {
            try
            {
                ScheduleDto dto;
                ScheduleEntity entity;

                entity = await _repository.Schedule.GetAsync(id);
                dto = _mapper.Map<ScheduleDto>(entity);

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(ScheduleDtoIn dto, int id)
        {
            try
            {
                ScheduleEntity entity;
                //ScheduleEntity schedule;

                entity = _mapper.Map<ScheduleEntity>(dto);
                //schedule = await _repository.Schedule.GetAsync(dto.Id);
                entity.Id = id;
                await _repository.Schedule.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }//end class
}
