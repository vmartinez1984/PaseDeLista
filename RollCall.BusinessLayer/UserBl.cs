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
    public class UserBl :IUserBl
    {

        private IRepository _repository;
        private IMapper _mapper;

        public UserBl(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAsync()
        {
            try
            {
                List<UserDto> list;
                List<UserEntity> entities;

                entities = await _repository.User.GetAsync();
                list = _mapper.Map<List<UserDto>>(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsMaximum()
        {
            try
            {
                bool isMaximum;

                isMaximum = false;
                await Task.Run(async () =>
                {
                    int users;
                    int maxUsers;

                    users = await _repository.User.CountAsync();
                    maxUsers = _repository.Configuration.GetMaxUsers();
                    if (users == maxUsers)
                        isMaximum = true;
                    else if (users < maxUsers)
                        isMaximum = false;
                    else
                        isMaximum = true;
                });

                return isMaximum;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDto> GetAsync(int id)
        {
            try
            {
                UserDto item;
                UserEntity entity;

                entity = await _repository.User.GetAsync(id);
                item = _mapper.Map<UserDto>(entity);

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddAsync(UserDtoIn dto)
        {
            try
            {
                if (IsMaximum().Result)
                {
                    throw new Exception("Ha alcanzado su limite máximo de usuarios, contacte a su ejecutivo de cuenta.");
                }
                UserEntity entity;

                entity = _mapper.Map<UserEntity>(dto);
                await _repository.User.AddAsync(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(UserDtoIn dto, int id)
        {
            try
            {
                UserEntity entity;

                entity = _mapper.Map<UserEntity>(dto);                
                entity.Id = id;
                await _repository.User.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return await _repository.User.CountAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDto> LoginAsync(UserLoginDto userLoginDto)
        {
            try
            {
                UserDto dto;
                UserEntity entity;

                entity = await _repository.User.GetAsync(userLoginDto.Email);
                if (entity == null)
                    dto = null;
                else
                    dto = _mapper.Map<UserDto>(entity);

                return dto;
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
                await _repository.User.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}