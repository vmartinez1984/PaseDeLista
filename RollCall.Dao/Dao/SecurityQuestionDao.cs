using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
    public class SecurityQuestionDao: ISecurityQuestionRepository
    {
        private AppDbContext _appDbContext;

        public SecurityQuestionDao(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<SecurityQuestionEntity> GetAsync(int id)
        {
            try
            {
                SecurityQuestionEntity entity;

                entity = await _appDbContext.SecurityQuestions.FindAsync(id);

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(SecurityQuestionEntity entity)
        {
            try
            {
                _appDbContext.Entry(entity).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddAsync(SecurityQuestionEntity entity)
        {
            try
            {

                _appDbContext.SecurityQuestions.Add(entity);
                await _appDbContext.SaveChangesAsync();

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SecurityQuestionEntity>> GetAllAsync(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
