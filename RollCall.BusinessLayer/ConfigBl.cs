using RollCall.Core.Interfaces.IRepositories;
using RollCall.Persistence.Dao;
using System;

namespace RollCall.BusinessLayer
{
    public class ConfigBl
    {
        private IRepository _repository;

        public ConfigBl(IRepository repository)
        {
            _repository = repository;
        }
        public int GetMaxUsers()
        {
            try
            {
                int maxUser;

                maxUser = _repository.Configuration.GetMaxUsers();

                return maxUser;
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
                int max;

                max = _repository.Configuration.GetMaxEmployees();

                return max;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }//end clas
}
