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
    public class ScheduleDao : IScheduleRepository
    {
        private AppDbContext _appDbContext;

        public ScheduleDao(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
		
        public async Task<List<ScheduleEntity>> GetAsync()
        {
            try
            {
                List<ScheduleEntity> list;

                list = await _appDbContext.Schedule.Where(x => x.IsActive).ToListAsync();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ScheduleEntity> GetAsync(int id)
        {
            try
            {
                ScheduleEntity item;

                item = await _appDbContext.Schedule.Where(x => x.Id == id).FirstOrDefaultAsync();

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddAsync(ScheduleEntity item)
        {
            try
            {
                _appDbContext.Schedule.Add(item);
                await _appDbContext.SaveChangesAsync();

                return item.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(ScheduleEntity item)
        {
            try
            {
                _appDbContext.Entry<ScheduleEntity>(item).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _appDbContext.Schedule.Where(x=> x.Id == id).FirstAsync();
            entity.IsActive = false;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
