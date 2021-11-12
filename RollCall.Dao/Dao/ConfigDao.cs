using RollCall.Persistence.Entities;
using System;
using System.Linq;

namespace RollCall.Persistence.Dao
{
  public class ConfigDao
  {
    public static int GetMaxUsers()
    {
      try
      {
        int total;

        using (var db = new AppDbContext())
        {
          total = db.Config.Where(x => x.Name == "Users")
            .Select(x => Convert.ToInt32( x.Value))
            .FirstOrDefault();
        }

        return total;
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
        int total;

        using (var db = new AppDbContext())
        {
          total = db.Config.Where(x => x.Name == "Employees")
            .Select(x => Convert.ToInt32( x.Value))
            .FirstOrDefault();
        }

        return total;
      }
      catch (Exception)
      {

        throw;
      }
    }

  }//End class
}
