using RollCall.Core.Interfaces.IRepositories;
using RollCall.Persistence.Entities;
using System;
using System.Linq;

namespace RollCall.Persistence.Dao
{
    public class ConfigDao : IConfigurationRepository
    {
        private AppDbContext _dbContext;

        public ConfigDao(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GetMaxUsers()
        {
            try
            {
                int total;


                total = _dbContext.Config.Where(x => x.Name == "Users")
                  .Select(x => Convert.ToInt32(x.Value))
                  .FirstOrDefault();


                return total;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetMaxEmployees()
        {
            try
            {
                int total;

                total = _dbContext.Config.Where(x => x.Name == "Employees")
                  .Select(x => Convert.ToInt32(x.Value))
                  .FirstOrDefault();

                return total;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }//End class
}
