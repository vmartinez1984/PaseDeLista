using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollCall.Persistence.Dao
{
    public class AreaDao : IAreaRepository
    {
        private AppDbContext _dbContext;

        public AreaDao(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AreaEntity>> GetAsync()
        {
            try
            {
                List<AreaEntity> list;

                list = await _dbContext.Area.Where(x => x.IsActive == true).ToListAsync();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AreaEntity> GetAsync(int id)
        {
            try
            {
                AreaEntity item;

                item = await _dbContext.Area.Where(x => x.Id == id).FirstOrDefaultAsync();

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddAsync(AreaEntity item)
        {
            try
            {
                _dbContext.Area.Add(item);
                await _dbContext.SaveChangesAsync();

                return item.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(AreaEntity item)
        {
            try
            {
                _dbContext.Entry<AreaEntity>(item).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            AreaEntity entity;

            entity = _dbContext.Area.Where(x => x.Id == id).First();
            entity.IsActive = false;

            await _dbContext.SaveChangesAsync();
        }
    }
}
