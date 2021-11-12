using RollCall.Persistence.Dao;
using System;

namespace RollCall.BusinessLayer
{
  public class ConfigBl
  {
    public static int GetMaxUsers()
    {
      try
      {
        int maxUser;

        maxUser = ConfigDao.GetMaxUsers();

        return maxUser;
      }
      catch (Exception)
      {

        throw;
      }
    }

    public static int GetMaxEmployees()
    {
      try
      {
        int max;

        max = ConfigDao.GetMaxEmployees();

        return max;
      }
      catch (Exception)
      {

        throw;
      }
    }

  }//end clas
}
