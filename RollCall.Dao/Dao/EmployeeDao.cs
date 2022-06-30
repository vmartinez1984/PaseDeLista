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
    public class EmployeeDao : IEmployeeRepository
    {
        private AppDbContext _appDbContext;

        public EmployeeDao(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<EmployeeEntity>> GetAsync(bool isActive = true)
        {
            try
            {
                List<EmployeeEntity> list;

                list = await _appDbContext.Employee
                  .Include(x => x.Schedule)
                  .Where(x => x.IsActive == isActive).ToListAsync();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EmployeeEntity> GetAsync(string employeeNumber)
        {
            try
            {
                EmployeeEntity item;


                item = await _appDbContext.Employee
                  .Where(x => x.EmployeeNumber == employeeNumber)
                  .Where(x => x.IsActive == true)
                  .FirstOrDefaultAsync();


                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // public async Task<List<EmployeeEntity>> GetAsync(bool isActive)
        // {
        //     try
        //     {
        //         List<EmployeeEntity> list;

        //         using (var db = new AppDbContext())
        //         {
        //             list = await db.Employee
        //               .Include(x => x.ListSecurityQuestions.Where(x => x.IsActive))
        //               .Include(x => x.Area)
        //               .Include(x => x.Schedule)
        //               .Where(x => x.IsActive == isActive && x.Id != 1).ToListAsync();
        //         }

        //         return list;
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }
        // }

        public async Task<EmployeeEntity> GetAsync(int id)
        {
            try
            {
                EmployeeEntity item;

                item = await _appDbContext.Employee
                  .Include(x => x.Area)
                  .Include(x => x.Schedule)
                  .Include(x => x.ListSecurityQuestions.Where(x => x.IsActive))
                  .Where(x => x.Id == id)
                  .FirstOrDefaultAsync();

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddAsync(EmployeeEntity entity)
        {
            try
            {

                entity.IsActive = true;
                entity.DateRegistration = DateTime.Now;
                _appDbContext.Employee.Add(entity);
                await _appDbContext.SaveChangesAsync();


                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(EmployeeEntity entity)
        {
            try
            {
                _appDbContext.Entry<EmployeeEntity>(entity).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task<int> CountAsync()
        {
            try
            {
                int total;
                
                total = await _appDbContext.User.CountAsync(x => x.IsActive == true);                

                return total;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<EmployeeEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }//end class
}