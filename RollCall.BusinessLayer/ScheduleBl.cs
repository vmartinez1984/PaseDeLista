using AutoMapper;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
    public class ScheduleBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public ScheduleBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ScheduleDto dto)
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

        public async Task DeleteAsync(ScheduleDto dto)
        {
            try
            {
                await _repository.Schedule.DeleteAsync(dto.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ScheduleDto>> GetAllAsync(bool isActive = true)
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

        public async Task UpdateAsync(ScheduleDto dto)
        {
            try
            {
                ScheduleEntity entity;
                //ScheduleEntity schedule;

                entity = _mapper.Map<ScheduleEntity>(dto);
                //schedule = await _repository.Schedule.GetAsync(dto.Id);
                entity.Id = dto.Id;
                await _repository.Schedule.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int scheduleId)
        {
            try
            {
                ScheduleEntity entity;

                entity = await _repository.Schedule.GetAsync(scheduleId);
                entity.IsActive = false;
                
                await _repository.Schedule.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
