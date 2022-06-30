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
    public class UserDao : IUserRepository
    {
        private AppDbContext _appDbContext;

        public UserDao(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<UserEntity>> GetAsync()
        {
            try
            {
                List<UserEntity> list;

                list = await _appDbContext.User.Where(x => x.IsActive == true).ToListAsync();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserEntity>> GetAsync(bool isActive)
        {
            try
            {
                List<UserEntity> list;

                list = await _appDbContext.User.Where(x => x.IsActive == true).ToListAsync();

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserEntity> GetAsync(int id)
        {
            try
            {
                UserEntity item;

                item = await _appDbContext.User.Where(x => x.Id == id)
                  .Include(x => x.Rol)
                  .FirstOrDefaultAsync();

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AddAsync(UserEntity user)
        {
            try
            {
                user.IsActive = true;
                user.DateRegistration = DateTime.Now;
                _appDbContext.User.Add(user);
                await _appDbContext.SaveChangesAsync();

                return user.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(UserEntity user)
        {
            try
            {
                _appDbContext.Entry<UserEntity>(user).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
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
                int total;

                total = await _appDbContext.User.CountAsync(x => x.IsActive == true);

                return total;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserEntity> GetAsync(string email)
        {
            try
            {
                UserEntity item;

                item = await _appDbContext.User
                  .Where(x => x.Email == email && x.IsActive == true)
                  .FirstOrDefaultAsync();

                return item;
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
    }//end class
}