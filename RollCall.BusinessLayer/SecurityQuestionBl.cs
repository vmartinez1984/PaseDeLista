using AutoMapper;
using RollCall.Core.Dtos.Inputs;
using RollCall.Core.Dtos.Outputs;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Dto;
using RollCall.Persistence.Dao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.BusinessLayer
{
    public class SecurityQuestionBl
    {
        private IRepository _repository;
        private IMapper _mapper;

        public SecurityQuestionBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> AddAsync(SecurityQuestionDtoIn dto)
        {
            try
            {
                SecurityQuestionEntity entity;

                entity = _mapper.Map<SecurityQuestionEntity>(dto);
                await _repository.SecurityQuestion.AddAsync(entity);

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
                await _repository.SecurityQuestion.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<SecurityQuestionDtoOut>> GetAllAsync(int employeeId, bool isActive = true)
        {
            try
            {
                List<SecurityQuestionDtoOut> dtos;
                List<SecurityQuestionEntity> entities;

                entities = await _repository.SecurityQuestion.GetAllAsync(employeeId);
                dtos = _mapper.Map<List<SecurityQuestionDtoOut>>(entities);

                return dtos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SecurityQuestionDtoOut> GetAsync(int id)
        {
            try
            {
                SecurityQuestionDtoOut dto;
                SecurityQuestionEntity entity;

                entity = await _repository.SecurityQuestion.GetAsync(id);
                dto = _mapper.Map<SecurityQuestionDtoOut>(entity);

                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(SecurityQuestionDtoOut dto)
        {
            try
            {
                SecurityQuestionEntity entity;
                SecurityQuestionEntity SecurityQuestion;

                entity = _mapper.Map<SecurityQuestionEntity>(dto);
                SecurityQuestion = await _repository.SecurityQuestion.GetAsync(dto.Id);
                entity.IsActive = SecurityQuestion.IsActive;
                entity.DateRegistration = SecurityQuestion.DateRegistration;
                await _repository.SecurityQuestion.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
